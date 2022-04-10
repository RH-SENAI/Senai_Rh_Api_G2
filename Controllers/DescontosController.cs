using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;

namespace SenaiRH_G2.Controllers
{
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

    }
}
