﻿using SenaiRH_G2.Contexts;
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

        public Cep BuscarPorId(int id)
        {
            return ctx.Ceps.FirstOrDefault(c => c.IdCep == id);
        }

        public void CadastrarCep(Cep novoCep)
        {
            Cep cep = new Cep()
            {
                Cep1 = novoCep.Cep1
            };

            ctx.Ceps.Add(cep);
            ctx.SaveChanges();
        }

        public void ExcluirCep(int id)
        {
            Cep buscarPorId = ctx.Ceps.FirstOrDefault(c => c.IdCep == id);
            ctx.Ceps.Remove(buscarPorId);
            ctx.SaveChanges();
        }

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