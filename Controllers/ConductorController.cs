using CtrApp8.Data;
using CtrApp8.Helpers;
using CtrApp8.Models.conductor;
using CtrApp8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;

namespace CtrApp8.Controllers
{

    [ApiController]
    [Route("api/conductor")]


    public class ConductorController : ControllerBase
    {

        ConductorDA conductorDA;

        public ConductorController()
        {
            conductorDA = new ConductorDA();
        }



        [HttpPost]
        [Route("listar")]
        public async Task<List<ConductorA>> ConductorListar(DocItem item)
        {
            var res = await conductorDA.Listar(item);
            return res;
        }



        
        [HttpPost]
        [Route("obtener")]
        public async Task<ConductorB> ConductorMostrar(DocItem item)
        {
            var res = await conductorDA.Mostrar(item);
            return res;
        }


        
        [HttpPost]
        [Route("imagenregistrar")]
        public async Task<DocItem> ImagenRegistrar([FromBody] DocItem item)
        {

            DocItem im = new DocItem();
            im = null;

            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\personal");
            path1 = path1.Replace("..", "");

            string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\personal\45x45");
            path2 = path2.Replace("..", "");

            string path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\personal\90x90");
            path3 = path3.Replace("..", "");

            string path4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\personal\180x180");
            path4 = path4.Replace("..", "");

            string path5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\personal\360x360");
            path5 = path5.Replace("..", "");

            string path6 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\personal\1024x1024");
            path6 = path6.Replace("..", "");


            try
            {
                im = new DocItem();

                im.num = conductorDA.InsertarImagen(item);

                path1 = path1 + @"\" + im.num + ".jpg";
                path2 = path2 + @"\" + im.num + ".jpg";
                path3 = path3 + @"\" + im.num + ".jpg";
                path4 = path4 + @"\" + im.num + ".jpg";
                path5 = path5 + @"\" + im.num + ".jpg";
                path6 = path6 + @"\" + im.num + ".jpg";

                var byteArray = Convert.FromBase64String(item.des);

                 System.IO.File.WriteAllBytes(path1, byteArray);

                //ImgWriter.Save(item.des, 45, path2);
                //ImgWriter.Save(item.des, 90, path3);
                //ImgWriter.Save(item.des, 180, path4);
                //ImgWriter.Save(item.des, 360, path5);
                //ImgWriter.Save(item.des, 1024, path6);

                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 45, 45, path2);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 90, 90, path3);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 180, 180, path4);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 360, 360, path5);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 1024, 1024, path6);


            }
            catch (Exception ex)
            {

                //string path00 = Path.Combine(@"C:\Users\pc\Documents\taller", DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt");
                //System.IO.File.WriteAllText(path00, ex.Message + "\n" + ex.StackTrace + "\n" + ex.Source + "\n" + ex.Data + "\n" + ex.HResult);

                Console.WriteLine(ex.ToString());
                im = null;
                
            }

            return im;

        }





        
        [HttpPost]
        [Route("registrar")]
        public async Task<ConductorA> Registrar(DocItem item)
        {

            ConductorD im1 = new ConductorD();
            im1 = new ConductorD();
            

            ConductorA im2 = new ConductorA();
            im2 = null;

            try
            {

                string ans;
                //ans= await ser.consultaRUCAsync(id, "rterrones@arellanomarketing.com", "UE1-937-N17-S6D", "");
                //return ans;


                //https://dniruc.apisperu.com/api/v1/dni/44835568?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxvZ21pMzZAZ21haWwuY29tIn0.N5XZDaKDnKlalliu12ETZeXywDteSbdeXRTT0NmQEtE
                
                string url = @"https://dniruc.apisperu.com/api/v1/dni/"+ item.num+ @"?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxvZ21pMzZAZ21haWwuY29tIn0.N5XZDaKDnKlalliu12ETZeXywDteSbdeXRTT0NmQEtE";


                //https://api.perudevs.com/api/v1/dni/simple?document=44835564&key=cGVydWRldnMucHJvZHVjdGlvbi5maXRjb2RlcnMuNjY2NzlkNzRkNDFiOTQxMTE0OGI1ODIx

                //string url = @"https://api.perudevs.com/api/v1/dni/simple?document=" + item.num + @"&key=cGVydWRldnMucHJvZHVjdGlvbi5maXRjb2RlcnMuNjY2NzlkNzRkNDFiOTQxMTE0OGI1ODIx";



                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";
                request.UserAgent = "";
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                var content = string.Empty;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            content = sr.ReadToEnd();
                        }
                    }
                }


                im1.success = false;
                im1 = JsonConvert.DeserializeObject<ConductorD>(content);

                if (im1 != null) {
                    if (im1.success)
                    {
                        DocItem im = new DocItem { num = im1.nombres + " " + im1.apellidoPaterno + " " + im1.apellidoMaterno, ser = im1.dni, des = im1.dni, tip = item.ser };
                        im2 = await conductorDA.Insertar(im);
                    }
                }
                

                //if (im1.code.ToLower().Equals("EN0008"))
                //{
                //    string path = @"C:\inetpub\wwwroot\contrans\logs\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt";
                //    File.WriteAllText(path, "no existe conexion con API");
                //}


            }
            catch (Exception ex)
            {
                im2 = null;
            }

            return im2;

        }




        
        [HttpPost]
        [Route("actualizar")]
        public async Task<DocItem> Actualizar(DocItem item)
        {
            var res = await conductorDA.Actualizar(item);
            return res;
        }


        
        [HttpPost]
        [Route("agregarvehiculo")]
        public async Task<DocItem> InsertarVehiculo(DocItem item)
        {
            var res = await conductorDA.InsertarVehiculo(item);
            return res;
        }

    }
}
