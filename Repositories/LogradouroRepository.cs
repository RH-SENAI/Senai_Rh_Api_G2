using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public Logradouro BuscarPorId(int id)
        {
            return ctx.Logradouros.FirstOrDefault(c => c.IdLogradouro == id);
        }

        public void CadastrarLogradouro(Logradouro novoLogradouro)
        {
            Logradouro logradouro = new Logradouro()
            {
                NomeLogradouro = novoLogradouro.NomeLogradouro
            };

            ctx.Logradouros.Add(logradouro);
            ctx.SaveChanges();
        }

        public void ExcluirLogradouro(int id)
        {
            Logradouro buscarPorId = ctx.Logradouros.FirstOrDefault(c => c.IdLogradouro == id);
            ctx.Logradouros.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        public List<Logradouro> ListarTodos()
        {
            return ctx.Logradouros.Select(p => new Logradouro
            {

                IdLogradouro = p.IdLogradouro,
                NomeLogradouro = p.NomeLogradouro

            }).ToList();
        }
    }
}
