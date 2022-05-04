using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class ComentarioDescontoRepository : IComentarioDescontoRepository
    {
        senaiRhContext ctx = new senaiRhContext();


        /// <summary>
        /// Alterar um cometario 
        /// </summary>
        /// <param name="Id">Id do comentario</param>
        /// <param name="comentarioAtualizado">Dados do comentario atualizado</param>
        public void AlterarComentarioDesconto(int Id, Comentariodesconto comentarioAtualizado)
        {
            Comentariodesconto comentarioBuscado = ListarComentarioPorIdDesconto(Id);
            if (comentarioBuscado != null)
            {
                comentarioBuscado.AvaliacaoDesconto = comentarioAtualizado.AvaliacaoDesconto;
                comentarioBuscado.ComentarioDesconto1 = comentarioAtualizado.ComentarioDesconto1;

                ctx.Comentariodescontos.Update(comentarioBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Cadastrar um novo comentario
        /// </summary>
        /// <param name="NovoComentario">Dados no novo comentario</param>
        public void CadastrarComentarioDesconto(Comentariodesconto NovoComentario)
        {
            ctx.Comentariodescontos.Add(NovoComentario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Excluir um comentario 
        /// </summary>
        /// <param name="Id">Id do comentario</param>
        public void ExcluirComentarioDesconto(int Id)
        {
            ctx.Comentariodescontos.Remove(ListarComentarioPorIdDesconto(Id));
            ctx.SaveChanges();
        }



        /// <summary>
        /// Listar todos os comentarios
        /// </summary>
        /// <returns></returns>
        public List<Comentariodesconto> ListarComenatarioDesconto()
        {
            return ctx.Comentariodescontos
                                .Select(p => new Comentariodesconto
                                {
                                    IdComentarioDesconto = p.IdComentarioDesconto,
                                    IdDesconto = p.IdDesconto,
                                    IdUsuario = p.IdUsuario,
                                    AvaliacaoDesconto = p.AvaliacaoDesconto,
                                    ComentarioDesconto1 = p.ComentarioDesconto1,
                                    IdUsuarioNavigation = new Usuario
                                    {
                                        Nome = p.IdUsuarioNavigation.Nome
                                    }

                                })
                            .ToList();
        }

        /// <summary>
        /// Listar comentarios pelo seu id 
        /// </summary>
        /// <param name="Id">id comentario</param>
        /// <returns></returns>

        public Comentariodesconto ListarComentarioPorIdDesconto(int Id)
        {
            return ctx.Comentariodescontos.FirstOrDefault(c => c.IdComentarioDesconto == Id);
        }
    }
}
