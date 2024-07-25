using System.Data.SqlClient;
using System.Data;
using CtrApp8.Models;
using CtrApp8.Models.vehiculo;
using CtrApp8.Helpers;

namespace CtrApp8.Data
{
    public class VehiculoDA : Connection
    {

        public async Task<DocItem> tmp_ins(DocItem item)
        {

            SqlCommand cmd = new SqlCommand("dbo.tmp_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@num", SqlDbType.VarChar, 255)).Value = item.num;

            DocItem im = new DocItem();

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                conContrans.Close();
                im.num = "1";
            }
            catch (Exception ex)
            {
                conContrans.Close();
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\logs\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt");
                File.WriteAllText(path, ex.Message + "\n" + ex.StackTrace + "\n" + ex.Source + "\n" + ex.Data + "\n" + ex.HResult);
                im.num = "0";
            }
            finally
            {
                conContrans.Close();
            }

            return im;

        }


        public async Task<List<VehiculoA>> Vehiculo_Sel(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.veh_sel3", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pla", SqlDbType.VarChar, 255)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@eml", SqlDbType.VarChar, 255)).Value = item.ser;

            List<VehiculoA> items;
            items = new List<VehiculoA>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    VehiculoA im = new VehiculoA();
                    im.f01 = dr["chr_VehiCodigo"].ToString();
                    im.f02 = dr["vch_VehiPlaca"].ToString();
                    im.f03 = dr["chr_VehiEstado"].ToString();
                    im.f04 = dr["dtt_RegistroCreado"].ToString();
                    im.f05 = dr["chr_VehiRegistroMTC"].ToString();
                    im.f06 = dr["chr_codDocImg"].ToString();
                    im.f07 = ImgConv.ImageToString("vehiculo", dr["chr_codDocImg"].ToString(), "90x90");
                    //im.f07 = "00000";
                    im.f08 = dr["vch_UsuCorreo"].ToString();
                    im.f09 = dr["vch_ChofNombre"].ToString();
                    im.f10 = dr["chr_ChofCodigo"].ToString();
                    items.Add(im);
                }
            }
            catch (Exception ex)
            {

                //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\logs\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt");
                //File.WriteAllText(path, ex.Message + "\n" + ex.StackTrace + "\n" + ex.Source + "\n" + ex.Data + "\n" + ex.HResult);

                conContrans.Close();
                items = new List<VehiculoA>();
                return items;

            }
            finally
            {
                conContrans.Close();
            }

            return items;

        }



        public async Task<List<VehiculoA>> Vehiculo_Sel2()
        {

            List<VehiculoA> items;
            items = new List<VehiculoA>();

            VehiculoA item = new VehiculoA();
            item.f01 = "059779";
            item.f02 = "ARX356";
            item.f03 = "H";
            item.f04="17/06/2024 11:16:55 PM";
            item.f05="";
            item.f06="000000";
            item.f07="00000";
            item.f08="lperez132@gmail.com";
            item.f09="DAVID OMAR BARRETO OLMOS";
            item.f10="042133";

            items.Add (item);

            item = new VehiculoA();
            item.f01 = "059780";
            item.f02="ARX995";  
            item.f03="H";
            item.f04="17/06/2024 11:17:14 PM";
            item.f05="";
            item.f06="000000";
            item.f07="00000";
            item.f08="lperez132@gmail.com";
            item.f09="DAVID OMAR BARRETO OLMOS";
            item.f10="042133";

            items.Add(item);


            return items;

        }




        public async Task<VehiculoB> Vehiculo_Bus(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.veh_sel4", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_VehiCodigo", SqlDbType.Char, 6)).Value = item.num;

            VehiculoB im2;
            im2 = new VehiculoB();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {

                    im2.f01 = dv[0]["chr_VehiCodigo"].ToString();
                    im2.f02 = dv[0]["vch_VehiPlaca"].ToString();
                    im2.f03 = dv[0]["dtt_RegistroCreado1"].ToString();
                    im2.f04 = dv[0]["vch_ChofNombre"].ToString();
                    im2.f05 = dv[0]["vch_ChofBrevete"].ToString();
                    im2.f06 = dv[0]["chr_ChofEstado"].ToString();
                    im2.f07 = dv[0]["dtt_RegistroCreado2"].ToString();

                    im2.f08 = dv[0]["vch_VehiTipoDescripcion"].ToString();
                    im2.f09 = dv[0]["vch_VehiMarca"].ToString();
                    im2.f10 = dv[0]["chr_VehiRegistroMTC"].ToString();
                    im2.f11 = dv[0]["chr_EjeNombre"].ToString();
                    im2.f12 = dv[0]["chr_codDocImg"].ToString();
                    im2.f13 = ImgConv.ImageToString("vehiculo", dv[0]["chr_codDocImg"].ToString(), "360x360");
                    im2.f14 = dv[0]["vch_UsuCorreo"].ToString();
                    im2.f15 = dv[0]["chr_ChofCodigo"].ToString();
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


        public async Task<string> ImagenInsertar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.veh_img_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_VehiCodigo", SqlDbType.Char, 6)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@bin_VehiImg", SqlDbType.VarBinary)).Value = Convert.FromBase64String(item.ser);
            cmd.Parameters.Add(new SqlParameter("@chr_codDocImg", SqlDbType.Char, 6));
            cmd.Parameters["@chr_codDocImg"].Direction = ParameterDirection.Output;

            string ans;
            ans = "000000";

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                ans = Convert.ToString(cmd.Parameters["@chr_codDocImg"].Value);
                
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
                ans = "000000";
                
            }
            finally
            {
                conContrans.Close();
            }

            return ans;
        }



        public async Task<List<VehiculoC>> Veh_img_list(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.veh_img_list", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_VehiCodigo", SqlDbType.Char, 6)).Value = item.num;

            List<VehiculoC> items;
            items = new List<VehiculoC>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    VehiculoC im = new VehiculoC();
                    im.f01 = dr["chr_VehiCodigo"].ToString();
                    im.f02 = dr["chr_codDocImg"].ToString();
                    im.f03 = dr["dtt_RegistroCreado"].ToString();
                    im.f04 = ImgConv.ImageToString("vehiculo", dr["chr_codDocImg"].ToString(), "360x360");
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



        public async Task<DocItem> ImagenEliminar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.veh_img_upd", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_codDocImg", SqlDbType.Char, 6)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@bit_std", SqlDbType.Int));
            cmd.Parameters["@bit_std"].Direction = ParameterDirection.Output;

            DocItem im = new DocItem();

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                im.num = Convert.ToString(cmd.Parameters["@bit_std"].Value);
                
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
                im.num = "000000";
            }
            finally
            {
                conContrans.Close();
            }

            return im;

        }



        public async Task<DocItem> ImagenLimpiarTodos(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.veh_img_clear", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_VehiCodigo", SqlDbType.Char, 6)).Value = item.num;
            
            DocItem im = new DocItem();

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                conContrans.Close();
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


        public async Task<VehiculoA> Insertar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.grl_vehiculo_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_EntiCodigoTransportista", SqlDbType.VarChar, 256)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vch_VehiPlaca", SqlDbType.VarChar, 256)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@chr_ChofCodigo", SqlDbType.VarChar, 16)).Value = item.des;
            cmd.Parameters.Add(new SqlParameter("@vch_UsuCorreo", SqlDbType.VarChar, 256)).Value = item.tip;


            VehiculoA im1;
            im1 = null;

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {
                    im1 = new VehiculoA();
                    im1.f01 = dv[0]["chr_VehiCodigo"].ToString();
                    im1.f02 = dv[0]["vch_VehiPlaca"].ToString();
                    im1.f03 = dv[0]["chr_VehiEstado"].ToString();
                    im1.f04 = dv[0]["dtt_RegistroCreado"].ToString();
                    im1.f05 = dv[0]["chr_VehiRegistroMTC"].ToString();
                    im1.f06 = dv[0]["chr_codDocImg"].ToString();
                    im1.f07 = ImgConv.ImageToString("vehiculo", dv[0]["chr_codDocImg"].ToString(), "90x90");
                    im1.f08 = dv[0]["vch_UsuCorreo"].ToString();
                    im1.f09 = dv[0]["vch_ChofNombre"].ToString();
                    im1.f10 = dv[0]["chr_ChofCodigo"].ToString();
                }
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
                return im1;
            }
            finally
            {
                conContrans.Close();
            }

            return im1;

        }



        public async Task<List<VehiculoA>> ChoferListar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.veh_sel5", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_ChofCodigo", SqlDbType.VarChar, 255)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vch_UsuCorreo", SqlDbType.VarChar, 255)).Value = item.ser;

            List<VehiculoA> items;
            items = new List<VehiculoA>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    VehiculoA im = new VehiculoA();
                    im.f01 = dr["chr_VehiCodigo"].ToString();
                    im.f02 = dr["vch_VehiPlaca"].ToString();
                    im.f03 = dr["chr_VehiEstado"].ToString();
                    im.f04 = dr["dtt_RegistroCreado"].ToString();
                    im.f05 = dr["chr_VehiRegistroMTC"].ToString();
                    im.f06 = dr["chr_codDocImg"].ToString();
                    im.f07 = ImgConv.ImageToString("vehiculo", dr["chr_codDocImg"].ToString(), "90x90");
                    im.f08 = dr["vch_UsuCorreo"].ToString();
                    im.f09 = dr["vch_ChofNombre"].ToString();
                    im.f10 = dr["chr_ChofCodigo"].ToString();
                    items.Add(im);
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

            return items;

        }


    }
}
