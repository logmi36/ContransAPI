using CtrApp8.Models;
using CtrApp8.Models.cita;
using CtrApp8.Models.notificacion;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CtrApp8.Data
{
    public class NotificacionDA : Connection
    {

        public async Task<DocItem> Insertar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.not_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 6)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuToken", SqlDbType.VarChar, 256)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuEmail", SqlDbType.VarChar, 256)).Value = item.des;
            cmd.Parameters.Add(new SqlParameter("@vch_titNot", SqlDbType.VarChar, 256)).Value = item.tip;
            cmd.Parameters.Add(new SqlParameter("@vch_cueNot", SqlDbType.VarChar, 256)).Value = item.com;
            cmd.Parameters.Add(new SqlParameter("@vhr_autorEmail", SqlDbType.VarChar, 32)).Value = item.rem;

            DocItem res = new DocItem();

            res.num = "0";

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                res.num = "1";
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
                res.num = "0";
            }
            finally
            {
                conContrans.Close();
            }

            return res;

        }



        public async Task<List<NotificacionA>> Listar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.not_sel", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuEmail", SqlDbType.VarChar, 32)).Value = item.num;

            List<NotificacionA> items;
            items = new List<NotificacionA>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    NotificacionA im = new NotificacionA();
                    im.f01 = dr["int_nroCita"].ToString();
                    im.f02 = dr["vhr_usuEmail"].ToString();
                    im.f03 = dr["vch_titNot"].ToString();
                    im.f04 = dr["vch_cueNot"].ToString();
                    im.f05 = Convert.ToDateTime(dr["dtt_FechaRegistro"].ToString()).ToString("dd-MM-yyyy HH:mm:ss");
                   
                    items.Add(im);
                }
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conContrans.Close();
            }

            return items;

        }

    }
}
