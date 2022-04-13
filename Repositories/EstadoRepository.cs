using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public Estado BuscarPorId(int id)
        {
            return ctx.Estados.FirstOrDefault(c => c.IdEstado == id);
        }

        public void CadastrarEstado(Estado novoEstado)
        {
            Estado estado = new Estado()
            {
                NomeEstado = novoEstado.NomeEstado
            };

            ctx.Estados.Add(estado);
            ctx.SaveChanges();
        }

        public void ExcluirEstado(int id)
        {
            Estado buscarPorId = ctx.Estados.FirstOrDefault(c => c.IdEstado == id);
            ctx.Estados.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        public List<Estado> ListarTodos()
        {
            return ctx.Estados.Select(p => new Estado
            {

                IdEstado = p.IdEstado,
                NomeEstado = p.NomeEstado

            }).ToList();
        }
    }
}
