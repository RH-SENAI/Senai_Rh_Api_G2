using Microsoft.EntityFrameworkCore;
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

        public void AlterarSaldoUsuario(int id, Usuario novoSaldoAtualizar)
        {

            Registrodesconto buscarSaldo = ctx.Registrodescontos.Include(i => i.IdUsuarioNavigation).FirstOrDefault(c => c.IdRegistroDesconto == id);
            Registrodesconto buscarValor = ctx.Registrodescontos.Include(i => i.IdDescontoNavigation).FirstOrDefault(c => c.IdRegistroDesconto == id);
            

            if (buscarSaldo != null && buscarValor != null)
            {
                Usuario usuario = buscarSaldo.IdUsuarioNavigation;
                int Saldo = buscarSaldo.IdUsuarioNavigation.SaldoMoeda;
                int Valor = buscarValor.IdDescontoNavigation.ValorDesconto;
                buscarSaldo.IdUsuario = novoSaldoAtualizar.IdUsuario;

                if (usuario.Nome != null)
                {
                    novoSaldoAtualizar.Nome = usuario.Nome;
                }

                if (usuario.Email != null)
                {
                    novoSaldoAtualizar.Email = usuario.Email;
                }

                if (usuario.Senha != null)
                {
                    novoSaldoAtualizar.Senha = usuario.Senha;
                }

                if (usuario.Cpf != null)
                {
                    novoSaldoAtualizar.Cpf = usuario.Cpf;
                }

                if (usuario.CaminhoFotoPerfil != null)
                {
                    novoSaldoAtualizar.CaminhoFotoPerfil = usuario.CaminhoFotoPerfil;
                }

                
                    novoSaldoAtualizar.DataNascimento = usuario.DataNascimento;
                

                if (usuario.IdTipoUsuario != 0)
                {
                    novoSaldoAtualizar.IdTipoUsuario = usuario.IdTipoUsuario;
                }

                if (usuario.IdCargo != 0)
                {
                    novoSaldoAtualizar.IdCargo = usuario.IdCargo;
                }

                if (usuario.IdUnidadeSenai != 0)
                {
                    novoSaldoAtualizar.IdUnidadeSenai = usuario.IdUnidadeSenai;
                }

                if (usuario.LocalizacaoUsuario != null)
                {
                    novoSaldoAtualizar.LocalizacaoUsuario = usuario.LocalizacaoUsuario;
                }

                if (Saldo >= Valor)
                {
                    int saldoUsuario = Saldo - Valor;
                    novoSaldoAtualizar.SaldoMoeda = saldoUsuario;
                }

                ctx.Usuarios.Update(novoSaldoAtualizar);
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

        public void CadastrarRegistrodesconto(Registrodesconto novoRegistrodesconto)
        {
            Registrodesconto registrodesconto = new Registrodesconto()
            {
                IdUsuario = novoRegistrodesconto.IdUsuario,
                IdDesconto = novoRegistrodesconto.IdDesconto

            };

            ctx.Registrodescontos.Add(registrodesconto);
            ctx.SaveChanges();
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
