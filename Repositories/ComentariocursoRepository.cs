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
        /// Alterar um cometario 
        /// </summary>
        /// <param name="Id">Id do comentario</param>
        /// <param name="comentarioAtualizado">Dados do comentario atualizado</param>

        public void AlterarComentarioCurso(int Id, Comentariocurso comentarioAtualizado)
        {
            Comentariocurso comentarioBuscado = ListarComentarioPorIdCurso(Id);
            if (comentarioBuscado != null)
            {
                comentarioBuscado.AvaliacaoComentario = comentarioAtualizado.AvaliacaoComentario;
                comentarioBuscado.ComentarioCurso1 = comentarioAtualizado.ComentarioCurso1;

                ctx.Comentariocursos.Update(comentarioBuscado);
                ctx.SaveChanges();
            }
        }


        /// <summary>
        /// Cadastrar um novo comentario
        /// </summary>
        /// <param name="NovoComentario">Dados no novo comentario</param>
        public void CadastrarComentarioCurso(Comentariocurso NovoComentario)
        {
            ctx.Comentariocursos.Add(NovoComentario);
            ctx.SaveChanges();
        }


        /// <summary>
        /// Excluir um comentario 
        /// </summary>
        /// <param name="Id">Id do comentario</param>
        public void ExcluirComentarioCurso(int Id)
        {
            ctx.Comentariocursos.Remove(ListarComentarioPorIdCurso(Id));
            ctx.SaveChanges();
        }


        /// <summary>
        /// Listar todos os comentarios 
        /// </summary>
        /// <returns></returns>
        public List<Comentariocurso> ListarComenatarioCurso()
        {
            return ctx.Comentariocursos.ToList();
        }


        /// <summary>
        /// Listar comentarios pelo seu id 
        /// </summary>
        /// <param name="Id">Id comentario</param>
        /// <returns></returns>
        public Comentariocurso ListarComentarioPorIdCurso(int Id)
        {
            return ctx.Comentariocursos.FirstOrDefault(c => c.IdComentarioCurso == Id);
        }
    }
}
