﻿using Microsoft.AspNetCore.Http;
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
    public class FavoritosDescontosController : ControllerBase
    {


        private IFavoritosDescontoRepository _favoritoDesconto { get; set; }


        public FavoritosDescontosController(IFavoritosDescontoRepository repo)
        {
            _favoritoDesconto = repo;
        }


        /// <summary>
        /// Listar todos os descontos favoritos
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult ListarComenatarioDesconto()
        {
            try
            {
                return Ok(_favoritoDesconto.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Buscar um desconto nos favoritos pelo seu id
        /// </summary>
        /// <param name="Id">d do curso favorito</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarCursoFavoritoPorId(int Id)
        {
            if (_favoritoDesconto.BuscarDescontoFavoritoPorId(Id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "Id nao existente!!"
                });
            }
            return Ok(_favoritoDesconto.BuscarDescontoFavoritoPorId(Id));
        }


        /// <summary>
        /// Excluir um desconto dos favoritoss
        /// </summary>
        /// <param name="Id">Id do desconto favorito</param>
        /// <returns></returns>
        [HttpDelete("deletar/{Id}")]
        public IActionResult ExcluirComentarioCurso(int Id)
        {
            if (_favoritoDesconto.BuscarDescontoFavoritoPorId(Id) == null)
            {
                return BadRequest(new { menssagem = "Esse id nao existe" });
            }

            _favoritoDesconto.ExcluirFavoritos(Id);
            return StatusCode(204);
        }

        /// <summary>
        /// Adcionar um novo desconto aos favoritos
        /// </summary>
        /// <param name="NovoFavorito">Dados obrigatorios para cadastro</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdcionarFavoritos(Descontofavorito NovoFavorito)
        {
            try
            {
                if (_favoritoDesconto.BuscarDescontoFavoritoPorId(Convert.ToInt16(NovoFavorito.IdDescontoFavorito)) != null)
                {
                    return BadRequest(new
                    {
                        mensagem = "ja existe um comentario com esse id"
                    });
                }

                if (NovoFavorito.IdDesconto <= 0 || NovoFavorito.IdUsuario <= 0)
                {
                    return BadRequest(new
                    {
                        mensagem = "Algum dado nao foi preenchido ou nao foi informado corretamente"
                    });
                }

                _favoritoDesconto.AdcionarFavoritos(NovoFavorito);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}