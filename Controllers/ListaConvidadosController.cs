using ListaConvidados.Context;
using ListaConvidados.DTOs;
using ListaConvidados.Enumerators;
using ListaConvidados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaConvidados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaConvidadosController : ControllerBase
    {
        private readonly ListaConvidadosContext listaConvidados;
        public ListaConvidadosController(ListaConvidadosContext listaConvidados)
        {
            this.listaConvidados = listaConvidados;
        }

        [HttpPost("AdicionarNaLista")]
        public ActionResult Adcionar([FromBody] AdicionarConvidadoDTO ConvidadoDTO)
        {
            foreach (var convidado in listaConvidados.TodosConvidados)
            {
                if (convidado.Nome == ConvidadoDTO.Nome)
                {
                    return BadRequest("Já tem um convidado com esse nome cadastrado, diferencie");
                }
            }
            ConvidadosModel Convidado = new ConvidadosModel();
            Convidado.Nome = ConvidadoDTO.Nome;
            Convidado.Resposta = ConvidadoDTO.Resposta;
            listaConvidados.TodosConvidados.Add(Convidado);
            listaConvidados.SaveChanges();
            return Ok("Confirmado!");
        }

        [HttpPut("Confirmar/{nome}")]
        public ActionResult Confirmar(string nome, [FromQuery] Resposta resposta)
        {
            foreach (var convidado in listaConvidados.TodosConvidados)
            {
                if (convidado.Nome == nome)
                {
                    convidado.Resposta = resposta;
                    listaConvidados.TodosConvidados.Attach(convidado);
                    listaConvidados.SaveChanges();
                    return Ok("Confirmado!");
                }
            }
            return BadRequest("Não tem esse nome na lista");
        }

        [HttpGet("Todos_Convidados")]
        public ActionResult TodosConvidados()
        {
            List<ConvidadosModel> convidados = new List<ConvidadosModel>();
            foreach (var convidado in listaConvidados.TodosConvidados)
            {
                convidados.Add(convidado);
            }
            return Ok(convidados);
        }

        [HttpGet("ConvidadoPeloNome/{nome}")]
        public ActionResult ConvidadoNome(string nome)
        {
            foreach (var convidado in listaConvidados.TodosConvidados)
            {
                if (convidado.Nome == nome)
                {
                    return Ok(convidado);
                }
            }
            return BadRequest("Não tem esse nome na lista");
        }

        [HttpGet("Confirmados")]
        public ActionResult Confirmado()
        {
            List<ConvidadosModel> confirmados = new List<ConvidadosModel>();
            foreach (var convidado in listaConvidados.TodosConvidados)
            {
                if (convidado.Resposta == Enumerators.Resposta.Sim)
                {
                    confirmados.Add(convidado);
                }
            }
            return Ok(confirmados);
        }

        [HttpGet("NaoConfirmados")]
        public ActionResult NaoConfirmado()
        {
            List<ConvidadosModel> naoConfirmados = new List<ConvidadosModel>();
            foreach (var convidado in listaConvidados.TodosConvidados)
            {
                if (convidado.Resposta == Enumerators.Resposta.Nao)
                {
                    naoConfirmados.Add(convidado);
                }
            }
            return Ok(naoConfirmados);
        }

        [HttpGet("NumeroConvidados")]
        public ActionResult NumeroConvidados()
        {
            return Ok($"Foram convidados ao todos {listaConvidados.TodosConvidados.Count()}");
        }

        [HttpDelete("TirarDaLista/{nome}")]
        public ActionResult Delete(string nome)
        {
            foreach (var convidado in listaConvidados.TodosConvidados)
            {
                if (convidado.Nome == nome)
                {
                    listaConvidados.TodosConvidados.Remove(convidado);
                    listaConvidados.SaveChanges();
                    return Ok("Excluido da lista");
                }
            }
            return BadRequest("Não ta na lista");
        }
    }
}
