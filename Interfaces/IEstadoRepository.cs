using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IEstadoRepository
    {

        List<Estado> ListarTodos();
        void ExcluirEstado(int id);
        Estado BuscarPorId(int id);
        void CadastrarEstado(Estado novoEstado);

    }
}
