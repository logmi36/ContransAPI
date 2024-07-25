using CtrApp8.Helpers;
using CtrApp8.Models;
using CtrApp8.Models.conductor;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CtrApp8.Data
{
    public class ConductorDA : Connection
    {

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public async Task<List<ConductorA>> Listar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.vis_lis", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nom", SqlDbType.VarChar, 255)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@usr", SqlDbType.VarChar, 255)).Value = item.ser;

            List<ConductorA> items;
            items = new List<ConductorA>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    ConductorA im = new ConductorA();
                    im.f01 = dr["chr_ChofCodigo"].ToString();
                    im.f02 = dr["chr_PersCodigo"].ToString();
                    im.f03 = textInfo.ToTitleCase(dr["vch_ChofNombre"].ToString().ToLower());
                    im.f04 = dr["vch_ChofBrevete"].ToString().Trim();
                    im.f05 = dr["chr_ChofDNI"].ToString().Trim();
                    im.f06 = dr["chr_ChofEstado"].ToString();
                    im.f07 = dr["dtt_RegistroCreado"].ToString();
                    im.f08 = dr["chr_UsuarioCreado"].ToString();
                    im.f09 = ImgConv.ImageToString("personal", dr["chr_PersCodigo"].ToString(), "90x90");
                    im.f10 = dr["vch_UsuCorreo"].ToString();
                    im.f11 = dr["vhr_ChofTelefono"].ToString();

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



        public async Task<ConductorB> Mostrar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.vis_get2", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_ChofCodigo", SqlDbType.Char, 6)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vch_UsuCorreo", SqlDbType.VarChar, 256)).Value = item.ser;

            ConductorB im2;
            im2 = null;

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {
                    im2 = new ConductorB();
                    im2.f01 = dv[0]["chr_ChofCodigo"].ToString();
                    im2.f02 = dv[0]["chr_PersCodigo"].ToString();
                    im2.f03 = textInfo.ToTitleCase(dv[0]["vch_ChofNombre"].ToString().ToLower());
                    im2.f04 = dv[0]["vch_ChofBrevete"].ToString().Trim();
                    im2.f05 = dv[0]["chr_ChofDNI"].ToString().Trim();
                    im2.f06 = dv[0]["chr_ChofEstado"].ToString().Trim();
                    im2.f07 = dv[0]["dtt_RegistroCreado2"].ToString();
                    im2.f08 = dv[0]["chr_VehiCodigo"].ToString();
                    im2.f09 = dv[0]["vch_VehiPlaca"].ToString();
                    im2.f10 = dv[0]["vch_VehiTipoDescripcion"].ToString();
                    im2.f11 = dv[0]["dtt_RegistroCreado1"].ToString();
                    im2.f12 = textInfo.ToTitleCase(dv[0]["vch_ClieSocial"].ToString().ToLower());
                    im2.f13 = dv[0]["vch_ClieRuc"].ToString();
                    im2.f14 = textInfo.ToTitleCase(dv[0]["vch_ClieDireccion"].ToString().ToLower());
                    im2.f15 = dv[0]["dtt_RegistroCreado3"].ToString();
                    im2.f16 = ImgConv.ImageToString("personal", dv[0]["chr_PersCodigo"].ToString(), "1024x1024");
                    im2.f17 = dv[0]["vhr_ChofTelefono"].ToString();
                }


            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                conContrans.Close();
            }

            return im2;

        }


        public string InsertarImagen(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.vis_img_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_ChofCodigo", SqlDbType.Char, 6)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vch_UsuCorreo", SqlDbType.VarChar, 256)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@img_Foto", SqlDbType.VarBinary)).Value = Convert.FromBase64String(item.des);

            string ans = "000000";

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {
                    ans = dv[0]["chr_PersCodigo"].ToString();
                }
                return ans;
            }
            catch (Exception ex)
            {
                conContrans.Close();
                return ans;
            }
            finally
            {
                conContrans.Close();
            }

        }


        public async Task<ConductorA> Insertar(DocItem item)
        {

            SqlCommand cmd = new SqlCommand("app.grl_chofer_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vch_ChofNombre", SqlDbType.VarChar, 256)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@chr_ChofDNI", SqlDbType.VarChar, 256)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@vch_ChofBrevete", SqlDbType.VarChar, 256)).Value = item.des;
            cmd.Parameters.Add(new SqlParameter("@vch_UsuCorreo", SqlDbType.VarChar, 256)).Value = item.tip;

            ConductorA im = new ConductorA();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {
                    im = new ConductorA();
                    im.f01 = dv[0]["chr_ChofCodigo"].ToString();
                    im.f02 = dv[0]["chr_PersCodigo"].ToString();
                    im.f03 = textInfo.ToTitleCase(dv[0]["vch_ChofNombre"].ToString().ToLower());
                    im.f04 = dv[0]["vch_ChofBrevete"].ToString().Trim();
                    im.f05 = dv[0]["chr_ChofDNI"].ToString().Trim();
                    im.f06 = dv[0]["chr_ChofEstado"].ToString();
                    im.f07 = dv[0]["dtt_RegistroCreado"].ToString();
                    im.f08 = dv[0]["chr_UsuarioCreado"].ToString();
                    im.f09 = ImgConv.ImageToString("personal", dv[0]["chr_PersCodigo"].ToString(), "90x90");
                    im.f10 = dv[0]["vch_UsuCorreo"].ToString();
                    im.f11 = dv[0]["vhr_ChofTelefono"].ToString();
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


        public async Task<DocItem> InsertarVehiculo(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.veh_chof_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_VehiCodigo", SqlDbType.Char, 6)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@chr_EntiCodigoTransportista", SqlDbType.Char, 6)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@chr_ChofCodigo", SqlDbType.Char, 6)).Value = item.des;
            cmd.Parameters.Add(new SqlParameter("@vch_UsuCorreo", SqlDbType.VarChar, 256)).Value = item.tip;

            DocItem im = new DocItem();

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                im.num = "1";
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
                im.num = "0";
            }
            finally
            {
                conContrans.Close();
            }
            return im;

        }



        public async Task<DocItem> Actualizar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.vis_updB", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@num", SqlDbType.Int)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@ser", SqlDbType.VarChar, 256)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@des", SqlDbType.VarChar, 256)).Value = item.des;
            cmd.Parameters.Add(new SqlParameter("@tip", SqlDbType.VarChar, 256)).Value = item.tip;
            cmd.Parameters.Add(new SqlParameter("@com", SqlDbType.VarChar, 256)).Value = item.com;
            cmd.Parameters.Add(new SqlParameter("@rem", SqlDbType.VarChar, 256)).Value = item.rem;

            DocItem im = new DocItem();

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                im.num = "1";
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
                im.num = "0";
            }
            finally
            {
                conContrans.Close();
            }
            return im;

        }



    }
}
