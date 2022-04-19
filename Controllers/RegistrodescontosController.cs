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


        [HttpGet("Saldo/{id}")]
        public IActionResult BuscarSaldo(int id)
        {
            return Ok(_registrodescontoRepository.BuscarSaldo(id));
        }



        [HttpGet("Valor/{id}")]
        public IActionResult BuscarValor(int id)
        {
            return Ok(_registrodescontoRepository.BuscarValor(id));
        }



        [HttpPost("Cadastrar")]
        public IActionResult CadastrarRegistrodesconto(Registrodesconto novoRegistrodesconto)
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
            catch (Exception exp)
            {

                return BadRequest(exp);
            }

        }

        [HttpPut("atualizar/{id}")]
        public IActionResult AlterarSaldoUsuario(int id, Usuario novoSaldoAtualizar)
        {
            try
            {
                _registrodescontoRepository.AlterarSaldoUsuario(Convert.ToInt16(id), novoSaldoAtualizar);
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
