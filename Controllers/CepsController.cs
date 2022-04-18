using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CepsController : ControllerBase
    {

        private ICepRepository _cepRepository { get; set; }

        public CepsController(ICepRepository repo)
        {
            _cepRepository = repo;
        }


        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Cep> listarCep = _cepRepository.ListarTodos();
                if (listarCep.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma Cep cadastrada no sistema!"
                    });
                }
                return Ok(listarCep);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_cepRepository.BuscarPorId(id));
        }


        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirCurso(int id)
        {
            try
            {
                if (id != 0)
                {
                    _cepRepository.ExcluirCep(id);
                    return StatusCode(204);
                }

                return NotFound();
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }

        }


        [HttpPost("Cadastrar")]
        public IActionResult CadastrarCurso(Cep novoCep)
        {

            try
            {

                if (novoCep == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                }
                else
                {
                    _cepRepository.CadastrarCep(novoCep);
                    return StatusCode(201);
                }
            }
            catch (Exception exp)
            {

                return BadRequest(exp);
            }

        }




    }
}
