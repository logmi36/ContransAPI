using CtrApp8.Data;
using CtrApp8.Models.empresa;
using CtrApp8.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrApp8.Controllers
{

    [ApiController]
    [Route("api/empresa")]


    public class EmpresaController : ControllerBase
    {
        EmpresaDA empresaDA;


        public EmpresaController()
        {
            empresaDA = new EmpresaDA();
        }


        [HttpPost]
        [Route("listar")]
        public async Task<List<EmpresaA>> Listar(DocItem item)
        {
            var res = await empresaDA.Listar(item);
            return res;
        }
    }
}
