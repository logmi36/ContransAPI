using CtrApp8.Helpers;
using CtrApp8.Models.contenedor;
using CtrApp8.Models;
using System.Data;
using System.Data.SqlClient;

namespace CtrApp8.Data
{
    public class ContenedorDA : Connection
    {

        public async Task<List<ContenedorA>> ContenedorListar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.grl_contenedor_lis", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@num", SqlDbType.VarChar, 255)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@ser", SqlDbType.VarChar, 255)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@des", SqlDbType.VarChar, 255)).Value = item.des;

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
                    im.f13 = dr["vch_numDoc"].ToString();
                    im.f14 = dr["vch_UsuCorreo"].ToString();

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



        public async Task<ContenedorB> ContenedorMostrar(DocItem item)
        {

            SqlCommand cmd = new SqlCommand("app.grl_contenedor_bus", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@wchr_contcargcodigo", SqlDbType.VarChar, 256)).Value = item.num;

            ContenedorB im;

            im = new ContenedorB();

            try
            {

                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                im.f01 = dv[0]["wchr_contcargcodigo"].ToString();
                im.f02 = dv[0]["wchr_linea"].ToString();
                im.f03 = dv[0]["wchr_serie_ctn"].ToString();
                im.f04 = dv[0]["wchr_nro_ctn"].ToString();
                im.f05 = dv[0]["wchr_tipo_ctn"].ToString();
                im.f06 = dv[0]["wint_size_ctn"].ToString();
                im.f07 = dv[0]["wchr_fec_operacion"].ToString();
                im.f08 = dv[0]["wchr_est_fisi"].ToString();
                im.f09 = dv[0]["wnum_tara"].ToString();
                im.f10 = dv[0]["wnum_payload"].ToString();
                im.f11 = dv[0]["wchr_cod_nave"].ToString();
                im.f12 = dv[0]["wchr_nro_viaje"].ToString();
                im.f13 = dv[0]["wint_nro_bk"].ToString();
                im.f14 = dv[0]["wchr_cliente"].ToString();
                im.f15 = dv[0]["wchr_tipo_movim"].ToString();
                im.f16 = dv[0]["wnum_mon_total_erp"].ToString();
                im.f17 = dv[0]["wchr_obse"].ToString();
                im.f18 = dv[0]["wchr_puerto"].ToString();
                im.f19 = dv[0]["wchr_depo"].ToString();
                im.f20 = dv[0]["wchr_nro_eir"].ToString();
                im.f21 = dv[0]["wchr_clase_ctn"].ToString();
                im.f22 = dv[0]["wvch_contimgcod"].ToString();
                im.f23 = ImgConv.ImageToString("contenedor", dv[0]["wvch_contimgcod"].ToString(), "360x360");

                return im;

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


        }



        public async Task<string> ImagenInsertar(DocItem item)
        {

            SqlCommand cmd = new SqlCommand("app.grl_contenedor_img_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@wchr_contcargcodigo", SqlDbType.Char, 6)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@wchr_usercod", SqlDbType.Char, 4)).Value = item.ser;

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
                    ans = dv[0]["num"].ToString();
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

            return ans;

        }



        public async Task<List<ContenedorC>> ContenedorImagenListar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.grl_contenedor_img_lis", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@wchr_contcargcodigo", SqlDbType.Char, 6)).Value = item.num;

            List<ContenedorC> items;
            items = new List<ContenedorC>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    ContenedorC im = new ContenedorC();
                    im.f01 = dr["wchr_contcargcodigo"].ToString();
                    im.f02 = dr["wvch_contimgcod"].ToString();
                    im.f03 = dr["wdtt_contimreg"].ToString();
                    im.f04 = dr["wint_contst"].ToString();
                    im.f05 = ImgConv.ImageToString("contenedor", dr["wvch_contimgcod"].ToString(), "360x360");
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
