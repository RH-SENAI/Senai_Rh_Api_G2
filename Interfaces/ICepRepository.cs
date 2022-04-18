using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface ICepRepository
    {

        List<Cep> ListarTodos();
        void ExcluirCep(int id);
        Cep BuscarPorId(int id);
        void CadastrarCep(Cep novoCep);

    }
}
