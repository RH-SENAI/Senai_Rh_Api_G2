using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface ILogradouroRepository
    {

        List<Logradouro> ListarTodos();
        void ExcluirLogradouro(int id);
        Logradouro BuscarPorId(int id);
        void CadastrarLogradouro(Logradouro novoLogradouro);

    }
}
