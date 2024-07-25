using CtrApp8.Data;
using CtrApp8.Models;
using CtrApp8.Models.notificacion;
using Microsoft.AspNetCore.Mvc;

namespace CtrApp8.Controllers
{
    [ApiController]
    [Route("api/notificacion")]

    public class NotificacionController : Controller
    {
        NotificacionDA data;


        public NotificacionController()
        {
            data = new NotificacionDA();
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<DocItem> Insertar(DocItem item)
        {
            var res = await data.Insertar(item);
            return res;
        }


        [HttpPost]
        [Route("listar")]
        public async Task<List<NotificacionA>> Listar(DocItem item)
        {
            var res = await data.Listar(item);
            return res;
        }



    }
}
