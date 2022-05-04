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

        public Desconto BuscarPorId(int id)
        {
            return ctx.Descontos.FirstOrDefault(c => c.IdDesconto == id);
        }

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
                MediaAvaliacaoDesconto = novoDesconto.MediaAvaliacaoDesconto = 0
            };

            ctx.Descontos.Add(desconto);
            ctx.SaveChanges();
        }

        public void ExcluirDesconto(int id)
        {
            Desconto buscarPorId = ctx.Descontos.FirstOrDefault(c => c.IdDesconto == id);
            ctx.Descontos.Remove(buscarPorId);
            ctx.SaveChanges();
        }

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
