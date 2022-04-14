using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
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

        public void CadastrarRegistrocurso(Registrocurso novoRegistrocurso)
        {



            Registrocurso registrocurso = new Registrocurso()
            {
                IdCurso = novoRegistrocurso.IdCurso,
                IdUsuario = novoRegistrocurso.IdUsuario
            };

            ctx.Registrocursos.Add(registrocurso);
            ctx.SaveChanges();
        }

        public void DescontarMoedaCurso(int id, Registrocurso descontarMoedaCurso)
        {
            throw new NotImplementedException();
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
                   
               }

            }).ToList();
        }
    }
}
