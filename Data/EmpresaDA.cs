using CtrApp8.Helpers;
using CtrApp8.Models.empresa;
using CtrApp8.Models;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace CtrApp8.Data
{
    public class EmpresaDA : Connection
    {

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public async Task<List<EmpresaA>> Listar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cli_sel", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vch_ClieSocial", SqlDbType.VarChar, 255)).Value = item.num;

            List<EmpresaA> items;
            items = new List<EmpresaA>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    EmpresaA im = new EmpresaA();
                    im.f01 = dr["chr_ClieCodigo"].ToString();
                    im.f02 = dr["vch_ClieRuc"].ToString();
                    im.f03 = textInfo.ToTitleCase(dr["vch_ClieSocial"].ToString().ToLower());
                    im.f04 = dr["vch_ClieDocumento"].ToString().Trim();
                    im.f05 = ImgConv.ImageToString("empresa", dr["vch_ClieRuc"].ToString(), "45x45");
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
