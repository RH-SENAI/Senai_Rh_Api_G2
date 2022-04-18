using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public Localizacao BuscarPorId(int id)
        {
            return ctx.Localizacaos.FirstOrDefault(c => c.IdLocalizacao== id);
        }

        public void CadastrarLocalizacao(Localizacao novoLocalizacao)
        {
            Localizacao localizacao = new Localizacao()
            {
                IdCep = novoLocalizacao.IdCep,
                IdBairro = novoLocalizacao.IdBairro,
                IdLogradouro = novoLocalizacao.IdLogradouro,
                IdCidade = novoLocalizacao.IdCidade,
                IdEstado = novoLocalizacao.IdEstado,
                Numero = novoLocalizacao.Numero

            };

            ctx.Localizacaos.Add(localizacao);
            ctx.SaveChanges();
        }

        public void ExcluirLocalizacao(int id)
        {
            Localizacao buscarPorId = ctx.Localizacaos.FirstOrDefault(c => c.IdLocalizacao == id);
            ctx.Localizacaos.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        public List<Localizacao> ListarTodos()
        {
            return ctx.Localizacaos.Select(p => new Localizacao
            {

                IdLocalizacao = p.IdLocalizacao,
                IdCep = p.IdCep,
                IdBairro = p.IdBairro,
                IdLogradouro = p.IdLogradouro,
                IdCidade = p.IdCidade,
                IdEstado = p.IdEstado,
                Numero = p.Numero,
                IdCepNavigation = new Cep()
                {
                    Cep1 = p.IdCepNavigation.Cep1
                },
                IdBairroNavigation = new Bairro()
                {
                    NomeBairro = p.IdBairroNavigation.NomeBairro
                },
                IdLogradouroNavigation = new Logradouro()
                {
                    NomeLogradouro = p.IdLogradouroNavigation.NomeLogradouro
                },
                IdCidadeNavigation = new Cidade()
                {
                    NomeCidade = p.IdCidadeNavigation.NomeCidade
                },
                IdEstadoNavigation = new Estado()
                {
                    NomeEstado = p.IdEstadoNavigation.NomeEstado
                }

            }).ToList();
        }
    }
}
