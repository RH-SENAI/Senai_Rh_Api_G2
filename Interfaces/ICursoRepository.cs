using SenaiRH_G2.Domains;
using SenaiRH_G2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface ICursoRepository
    {

        List<Curso> ListarTodos();
        void ExcluirCurso(int id);
        Curso BuscarPorId(int id);
        void CadastrarCurso(CursoCadastroViewModel novoCurso);
    }
}
