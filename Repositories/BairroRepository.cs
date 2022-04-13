using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class BairroRepository : IBairroRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public Bairro BuscarPorId(int id)
        {
            return ctx.Bairros.FirstOrDefault(c => c.IdBairro == id);
        }

        public void CadastrarBairro(Bairro novoBairro)
        {
            Bairro bairro = new Bairro()
            {
                NomeBairro = novoBairro.NomeBairro
            };

            ctx.Bairros.Add(bairro);
            ctx.SaveChanges();
        }

        public void ExcluirBairro(int id)
        {
            Bairro buscarPorId = ctx.Bairros.FirstOrDefault(c => c.IdBairro == id);
            ctx.Bairros.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        public List<Bairro> ListarTodos()
        {
            return ctx.Bairros.Select(p => new Bairro
            {
                IdBairro = p.IdBairro,
                NomeBairro = p.NomeBairro

            }).ToList();
        }
    }
}
