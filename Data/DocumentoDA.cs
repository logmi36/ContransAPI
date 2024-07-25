using CtrApp8.Helpers;
using CtrApp8.Models.contenedor;
using CtrApp8.Models.documento;
using CtrApp8.Models;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace CtrApp8.Data
{
    public class DocumentoDA : Connection
    {

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public async Task<List<DocumentoA>> Listar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.grl_documentoCli_lis", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nom", SqlDbType.VarChar, 255)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@usr", SqlDbType.VarChar, 255)).Value = item.ser;

            List<DocumentoA> items;
            items = new List<DocumentoA>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    DocumentoA im = new DocumentoA();
                    im.f01 = dr["int_codDoc"].ToString();
                    im.f02 = dr["vch_numDoc"].ToString();
                    im.f03 = textInfo.ToTitleCase(dr["vch_ClieSocial"].ToString().ToLower());
                    im.f04 = dr["vch_ClieRuc"].ToString().Trim();
                    im.f05 = dr["vch_UsuCorreo"].ToString().Trim();
                    im.f06 = ImgConv.ImageToString("empresa", dr["vch_ClieRuc"].ToString(), "90x90");
                    im.f07 = dr["chr_docTipo"].ToString().Trim();


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




        public async Task<DocumentoA> Insertar(DocItem item)
        {

            SqlCommand cmd = new SqlCommand("app.grl_documentoCli_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vch_numDoc", SqlDbType.VarChar, 256)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@chr_ClieCodigo", SqlDbType.Char, 6)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@vch_UsuCorreo", SqlDbType.VarChar, 256)).Value = item.des;

            DocumentoA im = new DocumentoA();
            im = null;

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {
                    im = new DocumentoA();
                    im.f01 = dv[0]["int_codDoc"].ToString();
                    im.f02 = dv[0]["vch_numDoc"].ToString();
                    im.f03 = textInfo.ToTitleCase(dv[0]["vch_ClieSocial"].ToString().ToLower());
                    im.f04 = dv[0]["vch_ClieRuc"].ToString().Trim();
                    im.f05 = dv[0]["vch_UsuCorreo"].ToString().Trim();
                    im.f06 = ImgConv.ImageToString("empresa", dv[0]["vch_ClieRuc"].ToString(), "90x90");
                    im.f07 = dv[0]["chr_docTipo"].ToString().Trim();
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


        public async Task<List<ContenedorA>> ContenedorListar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.grl_documentoCli_bus", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vch_numDoc", SqlDbType.VarChar, 256)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vch_UsuCorreo", SqlDbType.VarChar, 256)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@vch_numCont", SqlDbType.VarChar, 256)).Value = item.des;

            List<ContenedorA> items;
            items = new List<ContenedorA>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    ContenedorA im = new ContenedorA();
                    im.f01 = dr["wchr_contcargcodigo"].ToString();
                    im.f02 = dr["wchr_linea"].ToString();
                    im.f03 = dr["wchr_serie_ctn"].ToString();
                    im.f04 = dr["wchr_nro_ctn"].ToString();
                    im.f05 = dr["wchr_tipo_ctn"].ToString();
                    im.f06 = dr["wint_size_ctn"].ToString();
                    im.f07 = dr["wchr_fec_operacion"].ToString();
                    im.f08 = dr["wnum_tara"].ToString();
                    im.f09 = dr["wnum_payload"].ToString();
                    im.f10 = dr["wchr_cod_nave"].ToString();
                    im.f11 = dr["wvch_contimgcod"].ToString();
                    im.f12 = ImgConv.ImageToString("contenedor", dr["wvch_contimgcod"].ToString(), "90x90");
                    im.f13 = dr["vch_UsuCorreo"].ToString();
                    im.f14 = dr["vch_numDoc"].ToString();

                    items.Add(im);
                }
            }
            catch (Exception ex)
            {
                ContenedorA im = new ContenedorA();
                im.f01 = ex.Message.ToString();
                items.Add(im);
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
