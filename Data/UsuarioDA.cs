using CtrApp8.Models.usuario;
using CtrApp8.Models;
using System.Data;
using System.Data.SqlClient;

namespace CtrApp8.Data
{
    public class UsuarioDA : Connection
    {

        public async Task<DocItem> Registrar(UsuarioA item)
        {
            SqlCommand cmd = new SqlCommand("app.usuApp_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuMail", SqlDbType.VarChar, 256)).Value = item.f01;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuNick", SqlDbType.VarChar, 256)).Value = item.f02;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuNombres", SqlDbType.VarChar, 256)).Value = item.f03;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuApellidos", SqlDbType.VarChar, 256)).Value = item.f04;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuDNI", SqlDbType.VarChar, 256)).Value = item.f05;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuTelefono", SqlDbType.VarChar, 256)).Value = item.f06;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuPass", SqlDbType.VarChar, 256)).Value = item.f07;
            cmd.Parameters.Add(new SqlParameter("@dtt_fecReg", SqlDbType.VarChar, 256)).Value = item.f12;
            cmd.Parameters.Add(new SqlParameter("@chr_ClieCodigo", SqlDbType.Char, 6)).Value = item.f13;
            cmd.Parameters.Add(new SqlParameter("@vhr_mobModelo", SqlDbType.VarChar, 256)).Value = item.f15;
            cmd.Parameters.Add(new SqlParameter("@vhr_mobSerie", SqlDbType.VarChar, 256)).Value = item.f16;
            cmd.Parameters.Add(new SqlParameter("@vhr_mobCodigo", SqlDbType.VarChar, 256)).Value = item.f17;
            cmd.Parameters.Add(new SqlParameter("@vhr_mobSdk", SqlDbType.VarChar, 256)).Value = item.f18;
            cmd.Parameters.Add(new SqlParameter("@vhr_token", SqlDbType.VarChar, 1024)).Value = item.f20;

            DocItem im;
            im = new DocItem();
            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {
                    im = new DocItem();
                    im.num = dv[0]["chr_usuCod"].ToString();
                }
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);


                im = null;
            }
            finally
            {
                conContrans.Close();

            }

            return im;

        }

    }
}
