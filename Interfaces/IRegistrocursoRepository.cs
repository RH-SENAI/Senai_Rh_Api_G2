using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IRegistrocursoRepository
    {

        List<Registrocurso> ListarTodos();
        void ExcluirRegistrocurso(int id);
        Registrocurso BuscarPorId(int id);
        void CadastrarRegistrocurso(Registrocurso novoRegistrocurso);
        void DescontarMoedaCurso(int id, Registrocurso descontarMoedaCurso);

    }
}
