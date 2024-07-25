using CtrApp8.Data;
using CtrApp8.Helpers;
using CtrApp8.Models.usuario;
using CtrApp8.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrApp8.Controllers
{


    [ApiController]
    [Route("api/usuario")]


    public class UsuarioController : ControllerBase
    {
        UsuarioDA usuarioDA;


        public UsuarioController()
        {
            usuarioDA = new UsuarioDA();
        }


        [HttpPost]
        [Route("registrar")]
        public async Task<DocItem> Registrar([FromBody] UsuarioA item)
        {

            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\usuario");
            path1 = path1.Replace("..", "");

            string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\usuario\45x45");
            path2 = path2.Replace("..", "");

            string path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\usuario\90x90");
            path3 = path3.Replace("..", "");

            string path4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\usuario\180x180");
            path4 = path4.Replace("..", "");

            string path5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\usuario\360x360");
            path5 = path5.Replace("..", "");

            string path6 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\usuario\1024x1024");
            path6 = path6.Replace("..", "");


            DocItem im;
            im = new DocItem();
            try
            {

                im = await usuarioDA.Registrar(item);

                path1 = path1 + @"\" + im.num + ".jpg";
                path2 = path2 + @"\" + im.num + ".jpg";
                path3 = path3 + @"\" + im.num + ".jpg";
                path4 = path4 + @"\" + im.num + ".jpg";
                path5 = path5 + @"\" + im.num + ".jpg";
                path6 = path6 + @"\" + im.num + ".jpg";


                System.IO.File.WriteAllBytes(path1, Convert.FromBase64String(item.f11));


                //ImgWriter.Save(item.f11, 45, path2);
                //ImgWriter.Save(item.f11, 90, path3);
                //ImgWriter.Save(item.f11, 180, path4);
                //ImgWriter.Save(item.f11, 360, path5);
                //ImgWriter.Save(item.f11, 1024, path6);

                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 45, 45, path2);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 90, 90, path3);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 180, 180, path4);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 360, 360, path5);
                ImagerLib.PerformImageResizeAndPutOnCanvas(path1, 1024, 1024, path6);

                return im;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return im;
            }

        }

    }
}
