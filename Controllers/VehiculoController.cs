using CtrApp8.Data;
using CtrApp8.Helpers;
using CtrApp8.Models;
using CtrApp8.Models.vehiculo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace CtrApp8.Controllers
{

    [ApiController]
    [Route("api/vehiculo")]

    public class VehiculoController : ControllerBase
    {

        VehiculoDA vehiculoDA;

        public VehiculoController() {
            vehiculoDA = new VehiculoDA();
        }


        [HttpGet]
        [Route("listar1")]
        public async Task<List<VehiculoA>> Get1() {
            DocItem im = new DocItem { num = "", ser = "lperez132@gmail.com" };
            var ans = await vehiculoDA.Vehiculo_Sel(im);
            return ans;
        }


        [HttpGet]
        [Route("listar2")]
        public async Task<List<VehiculoA>> Get2()
        {
            var ans = await vehiculoDA.Vehiculo_Sel2();
            return ans;
        }

        [HttpPost]
        [Route("insertar2")]
        public async Task<DocItem> Post(DocItem item) { 
            var ans = await vehiculoDA.tmp_ins(item);
            return ans;
        }


        //==========================================================



        [HttpPost]
        [Route("buscar")]
        public async Task<List<VehiculoA>> Vehiculo_Sel([FromBody] DocItem item)
        {
            var res = await vehiculoDA.Vehiculo_Sel(item);
            return res;
        }



        [HttpGet]
        [Route("listar")]
        public async Task<List<VehiculoA>> Vehiculo_Sel2()
        {
            DocItem im = new DocItem();
            im.num = "";
            im.ser = "lperez132@gmail.com";
            im.des = "";
            im.tip = "";
            im.com = "";
            im.rem = "";

            var items = await vehiculoDA.Vehiculo_Sel(im);

            return items;

        }


        [HttpPost]
        [Route("mostrar")]
        public async Task<VehiculoB> Vehiculo_Bus(DocItem item)
        {
            var res = await vehiculoDA.Vehiculo_Bus(item);
            return res;
        }




        [HttpPost]
        [Route("imagenregistrar")]
        public async Task<DocItem> ImagenRegistrar([FromBody] DocItem item)
        {

            DocItem im = new DocItem();

            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\vehiculo");
            path1 = path1.Replace("..", "");

            string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\vehiculo\45x45");
            path2 = path2.Replace("..", "");

            string path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\vehiculo\90x90");
            path3 = path3.Replace("..", "");

            string path4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\vehiculo\180x180");
            path4 = path4.Replace("..", "");

            string path5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\vehiculo\360x360");
            path5 = path5.Replace("..", "");

            string path6 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\vehiculo\1024x1024");
            path6 = path6.Replace("..", "");

            //var path1 = @"C:\inetpub\wwwroot\contrans\Images\vehiculo";
            //var path2 = @"C:\inetpub\wwwroot\contrans\Images\vehiculo\45x45";
            //var path3 = @"C:\inetpub\wwwroot\contrans\Images\vehiculo\90x90";
            //var path4 = @"C:\inetpub\wwwroot\contrans\Images\vehiculo\180x180";
            //var path5 = @"C:\inetpub\wwwroot\contrans\Images\vehiculo\360x360";
            //var path6 = @"C:\inetpub\wwwroot\contrans\Images\vehiculo\1024x1024";

            try
            {

                string ans = await vehiculoDA.ImagenInsertar(item);

                path1 = path1 + @"\" + ans + ".jpg";
                path2 = path2 + @"\" + ans + ".jpg";
                path3 = path3 + @"\" + ans + ".jpg";
                path4 = path4 + @"\" + ans + ".jpg";
                path5 = path5 + @"\" + ans + ".jpg";
                path6 = path6 + @"\" + ans + ".jpg";

                var byteArray = Convert.FromBase64String(item.ser);

                System.IO.File.WriteAllBytes(path1, byteArray);

                Console.WriteLine("path1====");
                Console.WriteLine(path1);
                Console.WriteLine("path2====");
                Console.WriteLine(path2);

                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 45, 45, path2);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 90, 90, path3);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 180, 180, path4);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 360, 360, path5);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 1024, 1024, path6);

                im.num = ans;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                im.num = "000000";
            }

            return im;
        }


        [HttpPost]
        [Route("imageneslistar")]
        public async Task<List<VehiculoC>> Veh_img_list(DocItem item)
        {
            var ans = await vehiculoDA.Veh_img_list(item);
            return ans;
        }



        [HttpPost]
        [Route("imagenenliminar")]
        public async Task<DocItem> ImagenEliminar(DocItem item)
        {
            var ans = await vehiculoDA.ImagenEliminar(item);
            return ans;
        }


        [HttpPost]
        [Route("imagenenliminartodos")]
        public async Task<DocItem> ImagenLimpiarTodos(DocItem item)
        {
            var ans = await vehiculoDA.ImagenLimpiarTodos(item);
            return ans;
        }



        [HttpPost]
        [Route("insertar")]
        public async Task<VehiculoA> Insertar(DocItem item)
        {
            var ans = await vehiculoDA.Insertar(item);
            return ans;
        }



        [HttpPost]
        [Route("choferlistar")]
        public async Task<List<VehiculoA>> ChoferListar([FromBody] DocItem item)
        {
            var res = await vehiculoDA.ChoferListar(item);
            return res;
        }


    }
}
