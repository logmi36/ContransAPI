using CtrApp8.Data;
using CtrApp8.Models.cita;
using CtrApp8.Models;
using Microsoft.AspNetCore.Mvc;
using CtrApp8.Helpers;

namespace CtrApp8.Controllers
{

    [ApiController]
    [Route("api/cita")]

    public class CitaController : ControllerBase
    {

        CitaDA citaDA;

        public CitaController()
        {
            citaDA = new CitaDA();
        }





        [HttpPost]
        [Route("mostrar")]
        public async Task<CitaA> ConductorListar(DocItem item)
        {
            var res = await citaDA.CitaMostrar(item);
            return res;
        }

        //===========================================================================


        [HttpPost]
        [Route("actualizararribo")]
        public async Task<DocItem> ActualizarArribo(DocItem item)
        {
            var res = await citaDA.ActualizarArribo(item);
            return res;
        }


        [HttpPost]
        [Route("actualizaringreso")]
        public async Task<DocItem> ActualizarIngreso(DocItem item)
        {
            var res = await citaDA.ActualizarIngreso(item);
            return res;
        }


        [HttpPost]
        [Route("actualizarsalida")]
        public async Task<DocItem> ActualizarSalida(DocItem item)
        {
            var res = await citaDA.ActualizarSalida(item);
            return res;
        }



        [HttpPost]
        [Route("listar")]
        public async Task<List<CitaB>> ListarCitasCliente(DocItem item)
        {
            var res = await citaDA.ListarCitasxCliente(item);
            return res;
        }




        [HttpPost]
        [Route("mostrarxid")]
        public async Task<CitaB> MostrarxId(DocItem item)
        {
            var res = await citaDA.CitaMostrarxId(item);
            return res;
        }



        [HttpPost]
        [Route("imprimir")]
        public async Task<DocItem> Imprimir(DocItem item)
        {
            CitaRep rep = new CitaRep();
            CitaB im = await citaDA.CitaMostrarxId(item);
            string res = await rep.Imprimir(im);

            string nm = item.num + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\wwwroot\Documents\cita");
            path = path.Replace("..", "");

            //string path = @"C:\inetpub\wwwroot\contrans\Documents\cita";
            path = path + @"\" + nm + ".pdf";

            string url = "Documents/cita/" + nm + ".pdf";

            var byteArray = Convert.FromBase64String(res);

            System.IO.File.WriteAllBytes(path, byteArray);

            item.ser = url;
            item.des = nm + ".pdf";

            citaDA.InsertarLog(item);

            return item;
        }



        [HttpPost]
        [Route("insertar")]
        public async Task<DocItem> Insertar(CitaC item)
        {
            var res = await citaDA.Insertar(item);
            return res;
        }


        [HttpPost]
        [Route("eliminar")]
        public async Task<DocItem> Eliminar(DocItem item)
        {
            var res = await citaDA.Eliminar(item);
            return res;
        }



        [HttpPost]
        [Route("editar")]
        public async Task<DocItem> Editar(DocItem item)
        {
            var res = await citaDA.Editar(item);
            return res;
        }


        //============================================================


        


        [HttpGet]
        [Route("listar/matricula/{id}")]
        public async Task<List<CitaD>> ListarCitasxMatricula(string id)
        {
            //string id = "arx999";
            var res = await citaDA.ListarxMatricula(id);
            return res;
        }
        

    }
}
