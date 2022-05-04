﻿using Microsoft.AspNetCore.Http;
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
    public class RegistrodescontosController : ControllerBase
    {

        private IRegistrodescontoRepository _registrodescontoRepository { get; set; }
      

        public RegistrodescontosController(IRegistrodescontoRepository repo)
        {
            _registrodescontoRepository = repo;
        }


        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                List<Registrodesconto> listarRegistrodesconto = _registrodescontoRepository.ListarTodos();
                if (listarRegistrodesconto.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma Registro Desconto cadastrada no sistema!"
                    });
                }
                return Ok(listarRegistrodesconto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_registrodescontoRepository.BuscarPorId(id));
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarRegistrodesconto(RegistroDescontoCadastrarViewModel novoRegistrodesconto)
        {

            try
            {

                if (novoRegistrodesconto == null)
                {
                    return BadRequest("Todos os campos do usuario devem ser preenchidos !");
                } 
                else
                {
                    _registrodescontoRepository.CadastrarRegistrodesconto(novoRegistrodesconto);
                    return StatusCode(201);
                }
            }
            catch (Exception erro)
            {
                if (novoRegistrodesconto != null)
                {
                    return BadRequest("Saldo Insuficiente");
                }
                return BadRequest(erro);
            }

        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirRegistrodesconto(int id)
        {
            try
            {
                if (id != 0)
                {
                    _registrodescontoRepository.ExcluirRegistrodesconto(id);
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
