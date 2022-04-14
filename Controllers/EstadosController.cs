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
    public class EstadosController : ControllerBase
    {

        private IEstadoRepository _estadoRepository { get; set; }

        public EstadosController(IEstadoRepository repo)
        {
            _estadoRepository = repo;
        }


        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Estado> listarEstado = _estadoRepository.ListarTodos();
                if (listarEstado.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma Estadocadastrada no sistema!"
                    });
                }
                return Ok(listarEstado);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_estadoRepository.BuscarPorId(id));
        }


        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirCidade(int id)
        {
            try
            {
                if (id != 0)
                {
                    _estadoRepository.ExcluirEstado(id);
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
        public IActionResult CadastrarEstado(Estado novoEstado)
        {

            try
            {

                if (novoEstado == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                }
                else
                {
                    _estadoRepository.CadastrarEstado(novoEstado);
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