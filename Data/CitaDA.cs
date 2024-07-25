using CtrApp8.Models.cita;
using CtrApp8.Models;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace CtrApp8.Data
{
    public class CitaDA : Connection
    {

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public async Task<CitaA> CitaMostrar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_sel", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vhr_codBarra", SqlDbType.VarChar, 256)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 16)).Value = item.ser;

            CitaA im2;
            im2 = new CitaA();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;
                im2 = null;

                if (dv.Count > 0)
                {
                    im2 = new CitaA();
                    im2.f01 = dv[0]["int_nroCita"].ToString();
                    im2.f02 = dv[0]["dtt_FechaProgramacion"].ToString();
                    im2.f03 = dv[0]["chr_codBl"].ToString();
                    im2.f04 = dv[0]["wchr_serie_ctn"].ToString();
                    im2.f05 = dv[0]["wchr_nro_ctn"].ToString();
                    im2.f06 = dv[0]["wchr_tipo_ctn"].ToString();
                    im2.f07 = dv[0]["wint_size_ctn"].ToString();
                    im2.f08 = dv[0]["vch_ClieSocial"].ToString();
                    im2.f09 = dv[0]["vhr_descripcion"].ToString();
                    im2.f10 = dv[0]["vch_VehiPlaca"].ToString();
                    im2.f11 = dv[0]["vch_ChofBrevete"].ToString();
                    im2.f12 = textInfo.ToTitleCase(dv[0]["vch_ChofNombre"].ToString());
                    im2.f13 = dv[0]["vhr_desAlmacen"].ToString();
                    im2.f14 = dv[0]["vhr_tipoCarga"].ToString();
                    im2.f15 = (dv[0]["dtt_FechaArribo"].ToString().Equals("")) ? "" : dv[0]["dtt_FechaArribo"].ToString().Substring(11, 5);
                    im2.f16 = (dv[0]["dtt_FechaIngreso"].ToString().Equals("")) ? "" : dv[0]["dtt_FechaIngreso"].ToString().Substring(11, 5);
                    im2.f17 = (dv[0]["dtt_FechaSalida"].ToString().Equals("")) ? "" : dv[0]["dtt_FechaSalida"].ToString().Substring(11, 5);

                }

            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);

                im2 = null;
            }
            finally
            {
                conContrans.Close();
            }

            return im2;

        }



        public async Task<DocItem> ActualizarArribo(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_upd_a", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 16)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vhr_autorEmail", SqlDbType.VarChar, 32)).Value = item.ser;

            DocItem im = new DocItem();
            im.num = "";

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {
                    im.num= (dv[0]["dtt_FechaArribo"].ToString().Equals("")) ? "" : Convert.ToDateTime(dv[0]["dtt_FechaArribo"].ToString()).ToString("HH:mm");
                    im.ser= (dv[0]["dtt_FechaArribo"].ToString().Equals("")) ? "" : Convert.ToDateTime(dv[0]["dtt_FechaArribo"].ToString()).ToString("dd-MM-yyyy");
                    

                }

            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);

                im.num = "";
            }
            finally
            {
                conContrans.Close();
            }

            return im;

        }

        public async Task<DocItem> ActualizarIngreso(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_upd_i", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 16)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vhr_autorEmail", SqlDbType.VarChar, 32)).Value = item.ser;

            DocItem im = new DocItem();
            im.num = "";

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {
                    im.num = (dv[0]["dtt_FechaIngreso"].ToString().Equals("")) ? "" : Convert.ToDateTime(dv[0]["dtt_FechaIngreso"].ToString()).ToString("HH:mm");
                    im.ser = (dv[0]["dtt_FechaIngreso"].ToString().Equals("")) ? "" : Convert.ToDateTime(dv[0]["dtt_FechaIngreso"].ToString()).ToString("dd-MM-yyyy");
                }

            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);

                im.num = "";
            }
            finally
            {
                conContrans.Close();
            }

            return im;

        }


        public async Task<DocItem> ActualizarSalida(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_upd_s", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 16)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vhr_autorEmail", SqlDbType.VarChar, 32)).Value = item.ser;

            DocItem im = new DocItem();
            im.num = "";

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                if (dv.Count > 0)
                {

                    im.num = (dv[0]["dtt_FechaSalida"].ToString().Equals("")) ? "" : Convert.ToDateTime(dv[0]["dtt_FechaSalida"].ToString()).ToString("HH:mm");
                    im.ser = (dv[0]["dtt_FechaSalida"].ToString().Equals("")) ? "" : Convert.ToDateTime(dv[0]["dtt_FechaSalida"].ToString()).ToString("dd-MM-yyyy");
                }

            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);

                im.num = "";
            }
            finally
            {
                conContrans.Close();
            }

            return im;

        }



        public async Task<List<CitaB>> ListarCitasxCliente(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_sel2", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuEmail", SqlDbType.VarChar, 255)).Value = item.num;

            List<CitaB> items;
            items = new List<CitaB>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    CitaB im = new CitaB();
                    im.f01 = dr["int_nroCita"].ToString();
                    im.f02 = Convert.ToDateTime(dr["dtt_FechaProgramacion"].ToString()).ToString("dd-MM-yyyy HH:mm");
                    im.f03 = dr["chr_codBl"].ToString();
                    im.f04 = dr["wchr_serie_ctn"].ToString();
                    im.f05 = dr["wchr_nro_ctn"].ToString();
                    im.f06 = dr["wchr_tipo_ctn"].ToString();
                    im.f07 = dr["wint_size_ctn"].ToString();
                    im.f08 = textInfo.ToTitleCase(dr["vch_ClieSocial"].ToString().ToLower());
                    im.f09 = dr["vhr_descripcion"].ToString();
                    im.f10 = dr["vch_VehiPlaca"].ToString();
                    im.f11 = dr["vch_ChofBrevete"].ToString();
                    im.f12 = textInfo.ToTitleCase(dr["vch_ChofNombre"].ToString().ToLower());
                    im.f13 = dr["vhr_desAlmacen"].ToString();
                    im.f14 = dr["vhr_tipoCarga"].ToString();
                    im.f15 = dr["dtt_FechaArribo"].ToString();
                    im.f16 = dr["dtt_FechaIngreso"].ToString();
                    im.f17 = dr["dtt_FechaSalida"].ToString();
                    im.f18 = dr["vhr_codBarra"].ToString();

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


        public async Task<CitaB> CitaMostrarxId(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_get", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 16)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuEmail", SqlDbType.VarChar, 16)).Value = item.ser;
            CitaB im2;
            im2 = new CitaB();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;
                im2 = null;

                if (dv.Count > 0)
                {
                    im2 = new CitaB();
                    im2.f01 = dv[0]["int_nroCita"].ToString();
                    im2.f02 = dv[0]["dtt_FechaProgramacion"].ToString();
                    im2.f03 = dv[0]["chr_codBl"].ToString();
                    im2.f04 = dv[0]["wchr_serie_ctn"].ToString();
                    im2.f05 = dv[0]["wchr_nro_ctn"].ToString();
                    im2.f06 = dv[0]["wchr_tipo_ctn"].ToString();
                    im2.f07 = dv[0]["wint_size_ctn"].ToString();
                    im2.f08 = dv[0]["vch_ClieSocial"].ToString();
                    im2.f09 = dv[0]["vhr_descripcion"].ToString();
                    im2.f10 = dv[0]["vch_VehiPlaca"].ToString();
                    im2.f11 = dv[0]["vch_ChofBrevete"].ToString();
                    im2.f12 = textInfo.ToTitleCase(dv[0]["vch_ChofNombre"].ToString());
                    im2.f13 = dv[0]["vhr_desAlmacen"].ToString();
                    im2.f14 = dv[0]["vhr_tipoCarga"].ToString();
                    im2.f15 = dv[0]["dtt_FechaArribo"].ToString();
                    im2.f16 = dv[0]["dtt_FechaIngreso"].ToString();
                    im2.f17 = dv[0]["dtt_FechaSalida"].ToString();
                    im2.f18 = dv[0]["vhr_codBarra"].ToString();
                }

            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);

                im2 = null;
            }
            finally
            {
                conContrans.Close();
            }

            return im2;

        }



        public Boolean InsertarLog(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.grl_citaRepLog_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuMail", SqlDbType.VarChar, 256)).Value = item.tip;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 16)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@vhr_repNombre", SqlDbType.VarChar, 256)).Value = item.des;

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                conContrans.Close();
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conContrans.Close();
            }

        }


        public async Task<DocItem> Insertar(CitaC item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_ins", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@chr_ClieCodigo", SqlDbType.Char, 6)).Value = item.f11;
            cmd.Parameters.Add(new SqlParameter("@chr_contcargcodigo", SqlDbType.Char, 6)).Value = item.f04;
            cmd.Parameters.Add(new SqlParameter("@vhr_codBarra", SqlDbType.VarChar, 32)).Value = item.f09;
            cmd.Parameters.Add(new SqlParameter("@dtt_FechaProgramacion", SqlDbType.VarChar, 32)).Value = item.f05;
            cmd.Parameters.Add(new SqlParameter("@vhr_tipoCarga", SqlDbType.Char, 2)).Value = item.f01;
            cmd.Parameters.Add(new SqlParameter("@chr_codAlmacen", SqlDbType.Char, 2)).Value = item.f02;
            cmd.Parameters.Add(new SqlParameter("@chr_idTipo", SqlDbType.Char, 2)).Value = item.f03;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuEmail", SqlDbType.VarChar, 256)).Value = item.f10;
            cmd.Parameters.Add(new SqlParameter("@vhr_ChofBrevete", SqlDbType.VarChar, 256)).Value = item.f07;
            cmd.Parameters.Add(new SqlParameter("@vhr_vehiPlaca", SqlDbType.VarChar, 256)).Value = item.f06;
            cmd.Parameters.Add(new SqlParameter("@vhr_obsCliente", SqlDbType.VarChar, 256)).Value = item.f08;
            cmd.Parameters.Add(new SqlParameter("@chr_VehiCodigo", SqlDbType.Char, 6)).Value = item.f12;
            cmd.Parameters.Add(new SqlParameter("@chr_ChofCodigo", SqlDbType.Char, 6)).Value = item.f13;
            cmd.Parameters.Add(new SqlParameter("@chr_codBl", SqlDbType.VarChar, 256)).Value = item.f14;
            cmd.Parameters.Add(new SqlParameter("@vhr_ChofNombre", SqlDbType.VarChar, 256)).Value = item.f15;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuToken", SqlDbType.VarChar, 256)).Value = item.f16;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuNombres", SqlDbType.VarChar, 256)).Value = item.f17;
            cmd.Parameters.Add(new SqlParameter("@vhr_serieNroCtn", SqlDbType.VarChar, 16)).Value = item.f18;
            cmd.Parameters.Add(new SqlParameter("@vhr_desCarga", SqlDbType.VarChar, 16)).Value = item.f19;
            cmd.Parameters.Add(new SqlParameter("@vhr_desAlmacen", SqlDbType.VarChar, 16)).Value = item.f20;
            cmd.Parameters.Add(new SqlParameter("@vhr_desTipo", SqlDbType.VarChar, 16)).Value = item.f21;

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




        public async Task<DocItem> Eliminar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_del", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 6)).Value = item.num;

            DocItem res = new DocItem();

            res.num = "0";

            try
            {
                conContrans.Open();
                cmd.ExecuteNonQuery();
                res.num="1";
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





        public async Task<DocItem> Editar(DocItem item)
        {
            SqlCommand cmd = new SqlCommand("app.cita_upd", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@int_nroCita", SqlDbType.VarChar, 6)).Value = item.num;
            cmd.Parameters.Add(new SqlParameter("@chr_VehiCodigo", SqlDbType.Char, 6)).Value = item.ser;
            cmd.Parameters.Add(new SqlParameter("@chr_ChofCodigo", SqlDbType.Char, 6)).Value = item.des;
            cmd.Parameters.Add(new SqlParameter("@vhr_ChofBrevete", SqlDbType.VarChar, 256)).Value = item.tip;
            cmd.Parameters.Add(new SqlParameter("@vhr_vehiPlaca", SqlDbType.VarChar, 256)).Value = item.com;
            cmd.Parameters.Add(new SqlParameter("@vhr_usuEmail", SqlDbType.VarChar, 256)).Value = item.rem;

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


        //=========================================================================




        

        //240721

        public async Task<List<CitaD>> ListarxMatricula(string id)
        {
            SqlCommand cmd = new SqlCommand("app.cita_sel3", conContrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@vhr_vehiPlaca", SqlDbType.VarChar, 16)).Value = id;

            List<CitaD> items;
            items = new List<CitaD>();

            try
            {
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                dv = ds.Tables[0].DefaultView;

                foreach (DataRowView dr in dv)
                {
                    CitaD im = new CitaD();
                    im.f01 = dr["int_nroCita"].ToString();
                    im.f02 = dr["dtt_FechaProgramacion"].ToString();
                    im.f03 = dr["vhr_usuToken"].ToString();
                    im.f04 = dr["vhr_usuEmail"].ToString();
                    im.f05 = dr["dtt_FechaArribo"].ToString();
                    im.f06 = dr["dtt_FechaIngreso"].ToString();
                    im.f07 = dr["dtt_FechaSalida"].ToString();
                    im.f08 = dr["int_ArriboNot"].ToString();
                    im.f09 = dr["int_IngresoNot"].ToString();
                    im.f10 = dr["int_SalidaNot"].ToString();

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
