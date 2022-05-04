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
    public class RegistrocursoRepository : IRegistrocursoRepository
    {

        senaiRhContext ctx = new senaiRhContext();


        public Registrocurso BuscarPorId(int id)
        {
            return ctx.Registrocursos.FirstOrDefault(c => c.IdRegistroCurso == id);
        }

        public void CadastrarRegistrocurso(RegistroCursoCadastrarViewModel novoRegistrocurso)
        {
            Usuario usuario = new Usuario();
            Curso curso = new Curso();
            Registrocurso registrocurso = new Registrocurso();
            registrocurso.IdUsuario = novoRegistrocurso.IdUsuario;
            registrocurso.IdCurso = novoRegistrocurso.IdCurso;

            usuario.IdUsuario = registrocurso.IdUsuario;
            curso.IdCurso = registrocurso.IdCurso;

            Usuario buscarUsuario = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == usuario.IdUsuario);
            Curso buscarCurso = ctx.Cursos.FirstOrDefault(c => c.IdCurso == curso.IdCurso);

            if (buscarUsuario.SaldoMoeda >= (int)buscarCurso.ValorCurso)
            {

                buscarUsuario.SaldoMoeda -=(int) buscarCurso.ValorCurso;
                buscarCurso.IdSituacaoInscricao = 2;

                ctx.Usuarios.Update(buscarUsuario);
                ctx.Cursos.Update(buscarCurso);
                ctx.Registrocursos.Add(registrocurso);
                ctx.SaveChanges();
            }

        }

        public void ExcluirRegistrocurso(int id)
        {
            Registrocurso buscarPorId = ctx.Registrocursos.FirstOrDefault(c => c.IdRegistroCurso == id);
            ctx.Registrocursos.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        public List<Registrocurso> ListarTodos()
        {
            return ctx.Registrocursos.Select(p => new Registrocurso
            {

                IdRegistroCurso = p.IdRegistroCurso,
                IdUsuarioNavigation = new Usuario()
                {
                    IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                    Nome = p.IdUsuarioNavigation.Nome,
                    SaldoMoeda = p.IdUsuarioNavigation.SaldoMoeda
                },
                IdCursoNavigation = new Curso()
                {
                    IdCurso = p.IdCursoNavigation.IdCurso,
                    NomeCurso = p.IdCursoNavigation.NomeCurso,
                    ValorCurso = p.IdCursoNavigation.ValorCurso
                }

            }).ToList();
        }
    }
}
