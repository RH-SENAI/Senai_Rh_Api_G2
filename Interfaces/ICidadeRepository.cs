using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface ICidadeRepository
    {

        List<Cidade> ListarTodos();
        void ExcluirCidade(int id);
        Cidade BuscarPorId(int id);
        void CadastrarCidade(Cidade novoCidade);

    }
}
