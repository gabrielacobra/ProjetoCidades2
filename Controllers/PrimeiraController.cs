using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    [Route("api/[controller]")]
    public class PrimeiraController : Controller
    {
        DAOCidades dao = new DAOCidades();

        [HttpGet]
        public IEnumerable<Cidades> Get()
        {
            return dao.Listar();
        }

        [HttpGet("{id}",Name="CidadeAtual")]
        public Cidades Get(int id)
        {
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cidades cidades){ //poderia ser com void e não iactionresult
            dao.Cadastrar(cidades);
            return CreatedAtRoute("CidadeAtual",new{id=cidades.Id},cidades);            
        }

        [HttpPut]
        public IActionResult Put ([FromBody] Cidades cidades){
            dao.Atualizar(cidades);
            return CreatedAtRoute("CidadeAtual",new{id=cidades.Id},cidades);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id){
            dao.Deletar(id);
            return CreatedAtRoute("CidadeAtual",id);
        }
    }
}