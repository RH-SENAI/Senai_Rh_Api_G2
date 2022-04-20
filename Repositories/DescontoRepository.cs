using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using SenaiRH_G2.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SenaiRH_G2.Repositories
{
    public class DescontoRepository : IDescontoRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        /// <summary>
        /// Bsucar um desconto pelo seu id
        /// </summary>
        /// <param name="id">id do desconto a ser buscado</param>
        /// <returns></returns>
        public Desconto BuscarPorId(int id)
        {
            return ctx.Descontos.FirstOrDefault(c => c.IdDesconto == id);
        }


        /// <summary>
        /// Cadastrar um novo desconto
        /// </summary>
        /// <param name="novoDesconto">dados do desconto a ser cadastrado</param>
        public void CadastrarDesconto(DescontoCadastroViewModel novoDesconto)
        {
            Desconto desconto = new Desconto()
            {
                IdEmpresa = novoDesconto.IdEmpresa,
                NomeDesconto = novoDesconto.NomeDesconto,
                DescricaoDesconto = novoDesconto.DescricaoDesconto,
                CaminhoImagemDesconto = novoDesconto.CaminhoImagemDesconto,
                ValidadeDesconto = novoDesconto.ValidadeDesconto,
                ValorDesconto = novoDesconto.ValorDesconto,
                NumeroCupom = novoDesconto.NumeroCupom,
                MediaAvaliacaoDesconto = novoDesconto.MediaAvaliacaoDesconto
            };

            ctx.Descontos.Add(desconto);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Excluir um desconto 
        /// </summary>
        /// <param name="id">Id do desconto a ser excluido</param>
        public void ExcluirDesconto(int id)
        {
            Desconto buscarPorId = ctx.Descontos.FirstOrDefault(c => c.IdDesconto == id);
            ctx.Descontos.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar todos os descontos
        /// </summary>
        /// <returns></returns>
        public List<Desconto> ListarTodos()
        {
            return ctx.Descontos
                    .Select(p => new Desconto
                    {
                        IdDesconto = p.IdDesconto,
                        IdEmpresa = p.IdEmpresa,
                        NomeDesconto = p.NomeDesconto,
                        DescricaoDesconto = p.DescricaoDesconto,
                        CaminhoImagemDesconto = p.CaminhoImagemDesconto,
                        ValidadeDesconto = p.ValidadeDesconto,
                        ValorDesconto = p.ValorDesconto,
                        NumeroCupom = p.NumeroCupom,
                        MediaAvaliacaoDesconto = p.MediaAvaliacaoDesconto,
                        IdEmpresaNavigation = new Empresa()
                        {

                            NomeEmpresa = p.IdEmpresaNavigation.NomeEmpresa,
                            EmailEmpresa = p.IdEmpresaNavigation.EmailEmpresa,
                            TelefoneEmpresa = p.IdEmpresaNavigation.TelefoneEmpresa,
                            IdLocalizacaoNavigation = new Localizacao()
                            {
                                Numero = p.IdEmpresaNavigation.IdLocalizacaoNavigation.Numero,
                                IdLogradouroNavigation = new Logradouro()
                                {
                                    NomeLogradouro = p.IdEmpresaNavigation.IdLocalizacaoNavigation.IdLogradouroNavigation.NomeLogradouro
                                },
                                IdEstadoNavigation = new Estado()
                                {
                                    NomeEstado = p.IdEmpresaNavigation.IdLocalizacaoNavigation.IdEstadoNavigation.NomeEstado
                                }

                            }


                        }


                    })
                .ToList();
        }
    }
}
