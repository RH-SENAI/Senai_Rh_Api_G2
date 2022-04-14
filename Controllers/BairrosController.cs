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
    public class BairrosController : ControllerBase
    {

        private IBairroRepository _bairroRepository { get; set; }

        public BairrosController(IBairroRepository repo)
        {
            _bairroRepository = repo;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Bairro> listarBairro = _bairroRepository.ListarTodos();
                if (listarBairro.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma Bairro cadastrada no sistema!"
                    });
                }
                return Ok(listarBairro);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_bairroRepository.BuscarPorId(id));
        }


        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirBairro(int id)
        {
            try
            {
                if (id != 0)
                {
                    _bairroRepository.ExcluirBairro(id);
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
        public IActionResult CadastrarBairro(Bairro novoBairro)
        {

            try
            {

                if (novoBairro == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                }
                else
                {
                    _bairroRepository.CadastrarBairro(novoBairro);
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