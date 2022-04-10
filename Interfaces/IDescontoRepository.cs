using SenaiRH_G2.Domains;
using SenaiRH_G2.ViewModels;
using System.Collections.Generic;

namespace SenaiRH_G2.Interfaces
{
    public interface IDescontoRepository
    {
        List<Desconto> ListarTodos();
        void ExcluirDesconto(int id);
        Desconto BuscarPorId(int id);
        void CadastrarCurso(DescontoCadastroViewModel novoDesconto);

    }
}
