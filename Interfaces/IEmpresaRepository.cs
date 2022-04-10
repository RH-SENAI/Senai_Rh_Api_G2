using SenaiRH_G2.Domains;
using SenaiRH_G2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IEmpresaRepository
    {

        List<Empresa> ListarTodos();
        void ExcluirEmpresa(int id);
        Empresa BuscarPorId(int id);
        void CadastrarEmpresa(EmpresaCadastroViewModel novoEmpresa);

    }
}
