using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class ComentarioCursoRepository : IComentarioCursoRepository
    {
        senaiRhContext ctx = new senaiRhContext();


        /// <summary>
        /// Listar comentarios pelo seu id 
        /// </summary>
        /// <param name="Id">Id comentario</param>
        /// <returns></returns>
        public Comentariocurso ListarComentarioPorId(int Id)
        {

            return ctx.Comentariocursos.FirstOrDefault(c => c.IdComentarioCurso == Id);
        }

        /// <summary>
        /// Cadastrar um novo comentario
        /// </summary>
        /// <param name="NovoComentario">Dados no novo comentario</param>
        public void CadastrarComentarioCurso(Comentariocurso NovoComentario)
        {
            Curso curso = new Curso();
            Comentariocurso comentariocurso = new Comentariocurso();
            comentariocurso.IdUsuario = NovoComentario.IdUsuario;
            comentariocurso.IdCurso = NovoComentario.IdCurso;
            comentariocurso.ComentarioCurso1 = NovoComentario.ComentarioCurso1;
            comentariocurso.AvaliacaoComentario = NovoComentario.AvaliacaoComentario;

            curso.IdCurso = NovoComentario.IdCurso;

            Curso buscarMediaCurso = ctx.Cursos.FirstOrDefault(c => c.IdCurso == curso.IdCurso);

            if (buscarMediaCurso.MediaAvaliacaoCurso == 0)
            {
                buscarMediaCurso.MediaAvaliacaoCurso += NovoComentario.AvaliacaoComentario;
                ctx.Cursos.Update(buscarMediaCurso);
                ctx.Comentariocursos.Add(NovoComentario);
                ctx.SaveChanges();
            }
            else
            {
                buscarMediaCurso.MediaAvaliacaoCurso = (buscarMediaCurso.MediaAvaliacaoCurso + NovoComentario.AvaliacaoComentario) / 2;
                ctx.Cursos.Update(buscarMediaCurso);
                ctx.Comentariocursos.Add(NovoComentario);
                ctx.SaveChanges();
            }
        }



        /// <summary>
        /// Listar todos os comentarios 
        /// </summary>
        /// <returns></returns>
        public List<Comentariocurso> ListarComenatarioCurso()
        {
            return ctx.Comentariocursos
                                .Select(p => new Comentariocurso
                                {
                                    IdComentarioCurso = p.IdComentarioCurso,
                                    IdCurso = p.IdCurso,
                                    IdUsuario = p.IdUsuario,
                                    AvaliacaoComentario = p.AvaliacaoComentario,
                                    ComentarioCurso1 = p.ComentarioCurso1,
                                    IdUsuarioNavigation = new Usuario
                                    {
                                        Nome = p.IdUsuarioNavigation.Nome
                                    }

                                })
                            .ToList();
        }



        /// <summary>
        /// Excluir um comentario 
        /// </summary>
        /// <param name="Id">Id do comentario</param>
        public void ExcluirComentarioCurso(int Id)
        {
            ctx.Comentariocursos.Remove(ListarComentarioPorId(Id));
            ctx.SaveChanges();
        }

        public List<Comentariocurso> ListarComentarioPorIdCurso(int Id)
        {
            List<Comentariocurso> comentarioCurso = new();

            foreach (var comentario in ctx.Comentariocursos.Select(p => new Comentariocurso
            {
                IdComentarioCurso = p.IdComentarioCurso,
                IdCurso = p.IdCurso,
                IdUsuario = p.IdUsuario,
                ComentarioCurso1 = p.ComentarioCurso1,
                AvaliacaoComentario = p.AvaliacaoComentario,
                IdUsuarioNavigation = new Usuario
                {
                    IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                    Nome = p.IdUsuarioNavigation.Nome,
                }
            }).ToList())
            {
                if (comentario.IdCurso == Id)
                {
                    comentarioCurso.Add(comentario);
                }
            }

            return comentarioCurso;
        }

    }
}
