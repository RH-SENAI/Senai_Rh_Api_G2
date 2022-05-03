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
    public class ComentarioDescontosController : ControllerBase
    {
        private IComentarioDescontoRepository _comentarioDesconto { get; set; }

        public ComentarioDescontosController(IComentarioDescontoRepository repo)
        {
            _comentarioDesconto = repo;
        }


        /// <summary>
        /// Listar todos os comentarios dos descontos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarComenatarioDesconto()
        {
            try
            {
                return Ok(_comentarioDesconto.ListarComenatarioDesconto());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Listar um comentario pelo seu id
        /// </summary>
        /// <param name="id">id Comentario</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult ListarComentarioPorIdDesconto(int id)
        {
            if (_comentarioDesconto.ListarComentarioPorIdDesconto(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "Id nao existente!!"
                });
            }
            return Ok(_comentarioDesconto.ListarComentarioPorIdDesconto(id));
        }

        /// <summary>
        /// Deletar um comentario pelo seu id
        /// </summary>
        /// <param name="id">Id do cometario</param>
        /// <returns></returns>
        [HttpDelete("deletar/{id}")]
        public IActionResult ExcluirComentarioDesconto(int id)
        {
            if (_comentarioDesconto.ListarComentarioPorIdDesconto(id) == null)
            {
                return BadRequest(new { menssagem = "Esse id nao existe" });
            }

            _comentarioDesconto.ExcluirComentarioDesconto(id);
            return StatusCode(204);
        }

        [HttpDelete("deletar/{idDesconto}")]
        public IActionResult ExcluirComentarioDesconto2(int idDesconto)
        {
            if (_comentarioDesconto.ListarComentarioPorIdDesconto(idDesconto) == null)
            {
                return BadRequest(new { menssagem = "Esse id nao existe" });
            }

            _comentarioDesconto.ExcluirComentarioDesconto2(idDesconto);
            return StatusCode(204);
        }

        /// <summary>
        /// Cadastrar um novo comentario
        /// </summary>
        /// <param name="NovoComentario">Dados do novo comentario</param>
        /// <param name="idcurso">id do curso cujo comentario faz parte </param>
        /// <param name="idUsuario">Id do usuario que cadastrou esse comentario</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CadastrarComentarioDesconto(Comentariodesconto NovoComentario, int idcurso, int idUsuario)
        {
            try
            {
                if (_comentarioDesconto.ListarComentarioPorIdDesconto(Convert.ToInt16(NovoComentario.IdComentarioDesconto)) != null)
                {
                    return BadRequest(new
                    {
                        mensagem = "ja existe um comentario com esse id"
                    });
                }

                if (NovoComentario.IdDesconto <= 0 || NovoComentario.IdUsuario <= 0 || NovoComentario.AvaliacaoDesconto == 0 || NovoComentario.ComentarioDesconto1 == null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Algum dado nao foi preenchido ou nao foi informado corretamente"
                    });
                }

                _comentarioDesconto.CadastrarComentarioDesconto(NovoComentario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualizar comentario
        /// </summary>
        /// <param name="Id">Id comentario</param>
        /// <param name="comentarioAtualizado">dados a serem atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult AlterarComentarioDesconto(int Id, Comentariodesconto comentarioAtualizado)
        {
            try
            {
                _comentarioDesconto.AlterarComentarioDesconto(Convert.ToInt16(Id), comentarioAtualizado);
                return StatusCode(200, new
                {
                    mensagem = "Dados atualizados!"
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
