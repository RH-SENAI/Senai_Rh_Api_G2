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
    public class RegistroscursosController : ControllerBase
    {

        private IRegistrocursoRepository _registroCurso { get; set; }

        public RegistroscursosController(IRegistrocursoRepository repo)
        {
            _registroCurso = repo;
        }


        /// <summary>
        /// Listar todos os registros de desconto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Registrocurso> listaRegistro = _registroCurso.ListarTodos();
                if (listaRegistro.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma regisro cadastrada no sistema!"
                    });
                }
                return Ok(listaRegistro);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }


        /// <summary>
        /// Buscar um registro de cursos pelo seu id
        /// </summary>
        /// <param name="id">Id do registro a ser encontrado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_registroCurso.BuscarPorId(id));
        }


        /// <summary>
        /// Deletar um registro 
        /// </summary>
        /// <param name="id">Id do registro a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirRegistrocurso(int id)
        {
            try
            {
                if (_registroCurso.BuscarPorId(id)!= null)
                {
                    _registroCurso.ExcluirRegistrocurso(id);
                    return StatusCode(204);
                }

                return NotFound();
            }
            catch (Exception execp)
            {
                return BadRequest(execp);
            }

        }


        /// <summary>
        /// Cadastrar um novo registro curso
        /// </summary>
        /// <param name="novoRegistrocurso"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CadastrarRegistrocurso(Registrocurso novoRegistrocurso)
        {
            try
            {
                if (_registroCurso.BuscarPorId(Convert.ToInt16(novoRegistrocurso.IdRegistroCurso)) != null)
                {
                    return BadRequest(new
                    {
                        mensagem = "ja existe um registro com esse id"
                    });
                }

                if (novoRegistrocurso.IdCurso <= 0 || novoRegistrocurso.IdUsuario <= 0)
                {
                    return BadRequest(new
                    {
                        mensagem = "Algum dado nao foi preenchido ou nao foi informado corretamente"
                    });
                }

                _registroCurso.CadastrarRegistrocurso(novoRegistrocurso);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
