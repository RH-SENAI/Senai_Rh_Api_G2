using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public Cidade BuscarPorId(int id)
        {
            return ctx.Cidades.FirstOrDefault(c => c.IdCidade == id);
        }

        public void CadastrarCidade(Cidade novoCidade)
        {
            Cidade cidade = new Cidade()
            {
                NomeCidade = novoCidade.NomeCidade
            };

            ctx.Cidades.Add(cidade);
            ctx.SaveChanges();
        }

        public void ExcluirCidade(int id)
        {
            Cidade buscarPorId = ctx.Cidades.FirstOrDefault(c => c.IdCidade == id);
            ctx.Cidades.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        public List<Cidade> ListarTodos()
        {
            return ctx.Cidades.Select(p => new Cidade
            {
                IdCidade = p.IdCidade,
                NomeCidade = p.NomeCidade

            }).ToList();
        }
    }
}
