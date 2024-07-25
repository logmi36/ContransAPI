using CtrApp8.Data;
using CtrApp8.Helpers;
using CtrApp8.Models.contenedor;
using CtrApp8.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrApp8.Controllers
{

    [ApiController]
    [Route("api/contenedor")]

    public class ContenedorController : ControllerBase
    {

        ContenedorDA contenedorDA;

        public ContenedorController()
        {
            contenedorDA = new ContenedorDA();
        }


        
        [HttpPost]
        [Route("listar")]
        public async Task<List<ContenedorA>> ConductorListar(DocItem item)
        {
            //DocItem item = new DocItem();
            //item.num = "1212310";
            var res = await contenedorDA.ContenedorListar(item);
            return res;
        }



        
        [HttpPost]
        [Route("mostrar")]
        public async Task<ContenedorB> ContenedorMostrar(DocItem item)
        {
            var res = await contenedorDA.ContenedorMostrar(item);
            return res;
        }

        
        [HttpPost]
        [Route("imagenregistrar")]
        public async Task<DocItem> ImagenInsertar(DocItem item)
        {

            DocItem im = new DocItem();

            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\contenedor");
            path1 = path1.Replace("..", "");

            string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\contenedor\45x45");
            path2 = path2.Replace("..", "");

            string path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\contenedor\90x90");
            path3 = path3.Replace("..", "");

            string path4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\contenedor\180x180");
            path4 = path4.Replace("..", "");

            string path5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\contenedor\360x360");
            path5 = path5.Replace("..", "");

            string path6 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\contenedor\1024x1024");
            path6 = path6.Replace("..", "");


            im.num = "000000";

            try
            {

                im.num = await contenedorDA.ImagenInsertar(item);

                path1 = path1 + @"\" + im.num  + ".jpg";
                path2 = path2 + @"\" + im.num  + ".jpg";
                path3 = path3 + @"\" + im.num  + ".jpg";
                path4 = path4 + @"\" + im.num  + ".jpg";
                path5 = path5 + @"\" + im.num  + ".jpg";
                path6 = path6 + @"\" + im.num  + ".jpg";

                var byteArray = Convert.FromBase64String(item.des);

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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                im.num = "000000";
            }

            return im;

        }


        
        [HttpPost]
        [Route("imagenlistar")]
        public async Task<List<ContenedorC>> ContenedorImagenListar(DocItem item)
        {
            var ans = await contenedorDA.ContenedorImagenListar(item);
            return ans;
        }

    }
}
