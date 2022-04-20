using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class CepRepository : ICepRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        /// <summary>
        /// Buscar um cep pelo seu id 
        /// </summary>
        /// <param name="id">Id do cep a ser buscado</param>
        /// <returns></returns>
        public Cep BuscarPorId(int id)
        {
            return ctx.Ceps.FirstOrDefault(c => c.IdCep == id);
        }

        /// <summary>
        /// Cadastrar um novo cep
        /// </summary>
        /// <param name="novoCep">Dados do cep a ser cadastrado</param>
        public void CadastrarCep(Cep novoCep)
        {
            Cep cep = new Cep()
            {
                Cep1 = novoCep.Cep1
            };

            ctx.Ceps.Add(cep);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Escluir um cep
        /// </summary>
        /// <param name="id">Id do cep a ser excluido</param>
        public void ExcluirCep(int id)
        {
            Cep buscarPorId = ctx.Ceps.FirstOrDefault(c => c.IdCep == id);
            ctx.Ceps.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar todos os cep
        /// </summary>
        /// <returns></returns>
        public List<Cep> ListarTodos()
        {
            return ctx.Ceps.Select(p => new Cep
            {

                IdCep = p.IdCep,
                Cep1 = p.Cep1

            }).ToList();
        }
    }
}
