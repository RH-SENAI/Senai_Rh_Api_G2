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

        /// <summary>
        /// Buscar uma cidade pelo seu id 
        /// </summary>
        /// <param name="id">id do bairro a ser buscado</param>
        /// <returns></returns>
        public Cidade BuscarPorId(int id)
        {
            return ctx.Cidades.FirstOrDefault(c => c.IdCidade == id);
        }

        /// <summary>
        /// Cadastrar uma nova cidade
        /// </summary>
        /// <param name="novoCidade">Dados da nova cidade a ser cadastrada</param>
        public void CadastrarCidade(Cidade novoCidade)
        {
            Cidade cidade = new Cidade()
            {
                NomeCidade = novoCidade.NomeCidade
            };

            ctx.Cidades.Add(cidade);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Excluir uma cidade
        /// </summary>
        /// <param name="id">Id da cidade a ser excluida</param>
        public void ExcluirCidade(int id)
        {
            Cidade buscarPorId = ctx.Cidades.FirstOrDefault(c => c.IdCidade == id);
            ctx.Cidades.Remove(buscarPorId);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar todas as cidades
        /// </summary>
        /// <returns></returns>
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
