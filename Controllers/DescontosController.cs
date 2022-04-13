using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using SenaiRH_G2.Utils;
using SenaiRH_G2.ViewModels;
using System;
using System.Collections.Generic;

namespace SenaiRH_G2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DescontosController : ControllerBase
    {

        private IDescontoRepository _descontoRepository { get; set; }

        public DescontosController(IDescontoRepository repo)
        {
            _descontoRepository = repo;
        }



        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Desconto> listarDesconto = _descontoRepository.ListarTodos();
                if (listarDesconto.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma desconto cadastrada no sistema!"
                    });
                }
                return Ok(listarDesconto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_descontoRepository.BuscarPorId(id));
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirDesconto(int id)
        {
            try
            {
                if (id != 0)
                {
                    _descontoRepository.ExcluirDesconto(id);
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
        public IActionResult CadastrarCurso([FromForm] DescontoCadastroViewModel novoDesconto, IFormFile fotoDesconto)
        {

            try
            {
                if (fotoDesconto == null)
                {
                    novoDesconto.CaminhoImagemDesconto = "imagem-padrao.png";
                    novoDesconto.MediaAvaliacaoDesconto = 0;
                }
                else
                {
                    #region Upload da Imagem com extensões permitidas apenas
                    string[] extensoesPermitidas = { "jpg", "png", "jpeg" };
                    string uploadResultado = Upload.UploadFile(fotoDesconto, extensoesPermitidas);

                    if (uploadResultado == "")
                    {
                        return BadRequest("Arquivo não encontrado !");
                    }
                    if (uploadResultado == "Extensão não permitida")
                    {
                        return BadRequest("Extensão do arquivo não permitida");
                    }

                    novoDesconto.CaminhoImagemDesconto = uploadResultado;
                    #endregion
                }



                if (novoDesconto == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                }
                else
                {
                    _descontoRepository.CadastrarDesconto(novoDesconto);
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
