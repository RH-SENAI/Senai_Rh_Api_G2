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


        /// <summary>
        /// Buscar um registro de cursos pelo seu id
        /// </summary>
        /// <param name="id">Id do registro a ser encontrado</param>
        /// <returns></returns>
        public Registrocurso BuscarPorId(int id)
        {
            return ctx.Registrocursos.FirstOrDefault(c => c.IdRegistroCurso == id);
        }



        /// <summary>
        /// Cadastrar um novo registro curso
        /// </summary>
        /// <param name="novoRegistrocurso"></param>
        /// <returns></returns>
        public void CadastrarRegistrocurso(RegistroCursoCadastrarViewModel novoRegistrocurso)
        {
            Usuario usuario = new Usuario();
            Curso curso = new Curso();
            Registrocurso registrocurso = new Registrocurso();
            registrocurso.IdUsuario = novoRegistrocurso.IdUsuario;
            registrocurso.IdCurso = novoRegistrocurso.IdCurso;
            registrocurso.IdSituacaoAtividade = novoRegistrocurso.IdSituacaoAtividade = 2;

            usuario.IdUsuario = registrocurso.IdUsuario;
            curso.IdCurso = registrocurso.IdCurso;

            Usuario buscarUsuario = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == usuario.IdUsuario);
            Curso buscarCurso = ctx.Cursos.FirstOrDefault(c => c.IdCurso == curso.IdCurso);

            if (buscarUsuario.SaldoMoeda >= (int)buscarCurso.ValorCurso)
            {

                buscarUsuario.SaldoMoeda -=(int) buscarCurso.ValorCurso;

                ctx.Usuarios.Update(buscarUsuario);
                ctx.Registrocursos.Add(registrocurso);
                ctx.SaveChanges();
            }

        }


        /// <summary>
        /// Deletar um registro 
        /// </summary>
        /// <param name="id">Id do registro a ser deletado</param>
        /// <returns></returns>
        public void ExcluirRegistrocurso(int id)
        {
            Registrocurso buscarPorId = ctx.Registrocursos.FirstOrDefault(c => c.IdRegistroCurso == id);
            ctx.Registrocursos.Remove(buscarPorId);
            ctx.SaveChanges();
        }


        /// <summary>
        /// Listar todos os registros de desconto
        /// </summary>
        /// <returns></returns>
        public List<Registrocurso> ListarTodos()
        {
            return ctx.Registrocursos.Select(p => new Registrocurso
            {

                IdRegistroCurso = p.IdRegistroCurso,
                IdSituacaoAtividade = p.IdSituacaoAtividade,
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
                },
                IdSituacaoAtividadeNavigation = new Situacaoatividade()
                {
                    IdSituacaoAtividade = p.IdSituacaoAtividadeNavigation.IdSituacaoAtividade,
                    NomeSituacaoAtividade = p.IdSituacaoAtividadeNavigation.NomeSituacaoAtividade
                }

            }).ToList();
        }
    }
}
