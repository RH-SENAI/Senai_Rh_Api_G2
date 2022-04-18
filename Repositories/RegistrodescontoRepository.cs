using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class RegistrodescontoRepository : IRegistrodescontoRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public void AlterarSaldoUsuario(int id, Registrodesconto saldoAtualizar)
        {

            Registrodesconto buscarSaldoPorId = ctx.Registrodescontos.FirstOrDefault(c => c.IdUsuarioNavigation.SaldoMoeda == id);
            Registrodesconto buscarValorPorId = ctx.Registrodescontos.FirstOrDefault(c => c.IdDescontoNavigation.ValorDesconto == id);
            if (buscarSaldoPorId != null && buscarValorPorId !=null)
            {

                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
                
            }

        }

        public Registrodesconto BuscarPorId(int id)
        {
             return ctx.Registrodescontos.FirstOrDefault(c => c.IdRegistroDesconto == id);
        }

        public Registrodesconto BuscarSaldoPorId(int id)
        {
            return ctx.Registrodescontos.FirstOrDefault(c => c.IdUsuarioNavigation.SaldoMoeda == id);
        }

        public Registrodesconto BuscarValorPorId(int id)
        {
            return ctx.Registrodescontos.FirstOrDefault(c => c.IdDescontoNavigation.ValorDesconto == id);
        }

        public void CadastrarRegistrodesconto(Registrodesconto novoRegistrodesconto)
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistrodesconto(int id)
        {
            Registrodesconto buscarPorId = ctx.Registrodescontos.FirstOrDefault(c => c.IdRegistroDesconto == id);
            ctx.Registrodescontos.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        public List<Registrodesconto> ListarTodos()
        {
            return ctx.Registrodescontos.Select(p => new Registrodesconto
            {

                IdRegistroDesconto = p.IdRegistroDesconto,
                IdUsuarioNavigation = new Usuario()
                {
                    IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                    Nome = p.IdUsuarioNavigation.Nome,
                    SaldoMoeda = p.IdUsuarioNavigation.SaldoMoeda
                },
                IdDescontoNavigation = new Desconto()
                {
                    IdDesconto = p.IdDescontoNavigation.IdDesconto,
                    NomeDesconto = p.IdDescontoNavigation.NomeDesconto,
                    ValorDesconto = p.IdDescontoNavigation.ValorDesconto

                }

            }).ToList();
        }
    }
}
