using senai_gp3_webApi.SentimentAnalisys;
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
        /// Cadastrar um novo comentario
        /// </summary>
        /// <param name="NovoComentario">Dados no novo comentario</param>
        public void CadastrarComentarioDesconto(Comentariodesconto NovoComentario)
        {

            Desconto desconto = new Desconto();

            SentimentAnalysis sentimentAnalisys = new();

            // Pega o score da IA
            var analiseSentimento = sentimentAnalisys.AnalisarTexto(NovoComentario.ComentarioDesconto1);

            // Atribui os scores
            NovoComentario.Positivo = Convert.ToDecimal(analiseSentimento.ConfidenceScores.Positive);
            NovoComentario.Negativo = Convert.ToDecimal(analiseSentimento.ConfidenceScores.Negative);
            NovoComentario.Neutro = Convert.ToDecimal(analiseSentimento.ConfidenceScores.Neutral);

            Comentariodesconto comentariodesconto = new Comentariodesconto();
            comentariodesconto.IdUsuario = NovoComentario.IdUsuario;
            comentariodesconto.IdDesconto = NovoComentario.IdDesconto;
            comentariodesconto.ComentarioDesconto1 = NovoComentario.ComentarioDesconto1;
            comentariodesconto.AvaliacaoDesconto = NovoComentario.AvaliacaoDesconto;

            desconto.IdDesconto = NovoComentario.IdDesconto;

            Desconto buscarMediaDesconto = ctx.Descontos.FirstOrDefault(c => c.IdDesconto == desconto.IdDesconto);

            if (buscarMediaDesconto.MediaAvaliacaoDesconto == 0)
            {
                buscarMediaDesconto.MediaAvaliacaoDesconto += NovoComentario.AvaliacaoDesconto;
                ctx.Descontos.Update(buscarMediaDesconto);
                ctx.Comentariodescontos.Add(NovoComentario);
                ctx.SaveChanges();
            } else
            {
                buscarMediaDesconto.MediaAvaliacaoDesconto = (buscarMediaDesconto.MediaAvaliacaoDesconto + NovoComentario.AvaliacaoDesconto) / 2;
                ctx.Descontos.Update(buscarMediaDesconto);
                ctx.Comentariodescontos.Add(NovoComentario);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Excluir um comentario 
        /// </summary>
        /// <param name="Id">Id do comentario</param>
        public void ExcluirComentarioDesconto(int Id)
        {
            ctx.Comentariodescontos.Remove(ListarComentarioPorId(Id));
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

        public Comentariodesconto ListarComentarioPorId(int Id)
        {
            return ctx.Comentariodescontos.FirstOrDefault(c => c.IdComentarioDesconto == Id);
        }

        public List<Comentariodesconto> ListarComentarioPorIdDesconto(int Id)
        {
            List<Comentariodesconto> comentariodescontos = new();
            foreach (var comentario in ctx.Comentariodescontos.Select(p => new Comentariodesconto
            {
                IdComentarioDesconto = p.IdComentarioDesconto,
                IdDesconto = p.IdDesconto,
                IdUsuario = p.IdUsuario,
                ComentarioDesconto1 = p.ComentarioDesconto1,
                AvaliacaoDesconto = p.AvaliacaoDesconto,
                IdUsuarioNavigation = new Usuario
                {
                    IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                    Nome = p.IdUsuarioNavigation.Nome,
                }
            }).ToList())
            {
                if(comentario.IdDesconto == Id)
                {
                    comentariodescontos.Add(comentario);
                }
            }

            return comentariodescontos;

        }
    }
}
