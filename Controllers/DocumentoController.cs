using CtrApp8.Data;
using CtrApp8.Models.contenedor;
using CtrApp8.Models.documento;
using CtrApp8.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrApp8.Controllers
{


    [ApiController]
    [Route("api/documento")]


    public class DocumentoController : ControllerBase
    {

        DocumentoDA documentoDA;


        public DocumentoController()
        {
            documentoDA = new DocumentoDA();
        }




        
        [HttpPost]
        [Route("listar")]
        public async Task<List<DocumentoA>> ConductorListar(DocItem item)
        {
            var res = await documentoDA.Listar(item);
            return res;
        }


        
        [HttpPost]
        [Route("insertar")]
        public async Task<DocumentoA> Insertar(DocItem item)
        {
            var res = await documentoDA.Insertar(item);
            return res;
        }


        
        [HttpPost]
        [Route("listarcontenedor")]
        public async Task<List<ContenedorA>> ContenedorListar(DocItem item)
        {
            var res = await documentoDA.ContenedorListar(item);
            return res;
        }




    }
}
