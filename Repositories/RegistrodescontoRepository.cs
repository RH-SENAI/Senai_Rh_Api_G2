using Microsoft.EntityFrameworkCore;
using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using SenaiRH_G2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class RegistrodescontoRepository : IRegistrodescontoRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        // Saldo
        // Valor desconto

        public void AlterarSaldoUsuario(int idRegistro)
        {


            //Saldo
            Registrodesconto buscarSaldo = ctx.Registrodescontos.Include(i => i.IdUsuarioNavigation).FirstOrDefault(c => c.IdRegistroDesconto == idRegistro);

            //Usuario
            Usuario Usuario = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == buscarSaldo.IdUsuario);
            
            //Valor Desconto
            Registrodesconto buscarValor = ctx.Registrodescontos.Include(i => i.IdDescontoNavigation).FirstOrDefault(c => c.IdRegistroDesconto == idRegistro);

            //usuario.IdUsuario = buscarSaldo.IdUsuario;

            //int Saldo = buscarSaldo.IdUsuarioNavigation.SaldoMoeda;

            int Valor = buscarValor.IdDescontoNavigation.ValorDesconto;
            

            if(buscarSaldo != null && buscarValor !=  null && Usuario != null)
            {
                Usuario.SaldoMoeda -= Valor;

                ctx.Usuarios.Update(Usuario);

                ctx.SaveChanges();
            }

        }

        

        public Registrodesconto BuscarPorId(int id)
        {
             return ctx.Registrodescontos.FirstOrDefault(c => c.IdRegistroDesconto == id);
        }

        public int BuscarSaldo(int id)
        {
            Registrodesconto buscarSaldo = ctx.Registrodescontos.Include(i => i.IdUsuarioNavigation).FirstOrDefault(c => c.IdRegistroDesconto == id);
            if (buscarSaldo != null)
            {
                return buscarSaldo.IdUsuarioNavigation.SaldoMoeda;
            }
            return 0;
        }

        public int BuscarValor(int id)
        {
            Registrodesconto buscarValor = ctx.Registrodescontos.Include(i => i.IdDescontoNavigation).FirstOrDefault(c => c.IdRegistroDesconto == id);
            if (buscarValor != null)
            {
                return buscarValor.IdDescontoNavigation.ValorDesconto;
            }
            return 0;
        }

        public void CadastrarRegistrodesconto(RegistroDescontoCadastrarViewModel novoRegistrodesconto)
        {
            Usuario usuario = new Usuario();
            Desconto desconto = new Desconto();
            Registrodesconto registrodesconto = new Registrodesconto();
            registrodesconto.IdUsuario = novoRegistrodesconto.IdUsuario;
            registrodesconto.IdDesconto = novoRegistrodesconto.IdDesconto;

            usuario.IdUsuario = registrodesconto.IdUsuario;
            desconto.IdDesconto = registrodesconto.IdDesconto;

            Usuario buscarUsuario = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == usuario.IdUsuario);
            Desconto buscarDesconto = ctx.Descontos.FirstOrDefault(c => c.IdDesconto == desconto.IdDesconto);


            if (buscarUsuario.SaldoMoeda >= buscarDesconto.ValorDesconto)
            {

                buscarUsuario.SaldoMoeda -= buscarDesconto.ValorDesconto;


                ctx.Usuarios.Update(buscarUsuario);
                ctx.Registrodescontos.Add(registrodesconto);
                ctx.SaveChanges();
            }
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
