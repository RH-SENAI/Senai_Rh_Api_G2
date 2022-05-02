using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using SenaiRH_G2.Utils;
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
    public class CursosController : ControllerBase
    {

        private ICursoRepository _cursoRepository { get; set; }

        public CursosController(ICursoRepository repo)
        {
            _cursoRepository = repo;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Curso> listarCurso = _cursoRepository.ListarTodos();
                if (listarCurso.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma curso cadastrada no sistema!"
                    });
                }
                return Ok(listarCurso);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }



        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_cursoRepository.BuscarPorId(id));
        }


        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirCurso(int id)
        {
            try
            {
                if (id != 0)
                {
                    _cursoRepository.ExcluirCurso(id);
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
        public IActionResult CadastrarCurso([FromForm] CursoCadastroViewModel novoCurso, IFormFile fotoCurso)
        {

            try
            {
                if (fotoCurso == null)
                {
                    novoCurso.CaminhoImagemCurso = "imagem-padrao.png";
                }
                else
                {
                    #region Upload da Imagem com extensões permitidas apenas
                    string[] extensoesPermitidas = { "jpg", "png", "jpeg" };
                    string uploadResultado = Upload.UploadFile(fotoCurso, extensoesPermitidas);

                    if (uploadResultado == "")
                    {
                        return BadRequest("Arquivo não encontrado !");
                    }
                    if (uploadResultado == "Extensão não permitida")
                    {
                        return BadRequest("Extensão do arquivo não permitida");
                    }

                    novoCurso.CaminhoImagemCurso = uploadResultado;
                    #endregion
                }



                if (novoCurso == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                }
                else
                {
                    _cursoRepository.CadastrarCurso(novoCurso);
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
