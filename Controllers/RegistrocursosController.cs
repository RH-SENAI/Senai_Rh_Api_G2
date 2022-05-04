using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using SenaiRH_G2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrocursosController : ControllerBase
    {

        private IRegistrocursoRepository _registrocursoRepository { get; set; }

        public RegistrocursosController(IRegistrocursoRepository repo)
        {
            _registrocursoRepository = repo;
        }


        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Registrocurso> listarRegistrocurso = _registrocursoRepository.ListarTodos();
                if (listarRegistrocurso.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma Registro Curso cadastrada no sistema!"
                    });
                }
                return Ok(listarRegistrocurso);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_registrocursoRepository.BuscarPorId(id));
        }


        [HttpPost("Cadastrar")]
        public IActionResult CadastrarRegistrodesconto(RegistroCursoCadastrarViewModel novoRegistrocurso)
        {

            try
            {

                if (novoRegistrocurso == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                }
                else
                {
                    _registrocursoRepository.CadastrarRegistrocurso(novoRegistrocurso);
                    return StatusCode(201);
                }
            }
            catch (Exception erro)
            {
                if (novoRegistrocurso != null)
                {
                    return BadRequest("Saldo Insuficiente");
                }
                return BadRequest(erro);
            }

        }


        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirRegistrocurso(int id)
        {
            try
            {
                if (id != 0)
                {
                    _registrocursoRepository.ExcluirRegistrocurso(id);
                    return StatusCode(204);
                }

                return NotFound();
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }

        }



    }
}
