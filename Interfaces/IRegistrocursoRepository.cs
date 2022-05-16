using SenaiRH_G2.Domains;
using SenaiRH_G2.ViewModels;
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
        List<Registrocurso> ListarRegistroCursoPorIdSituação(int Id);
        void CadastrarRegistrocurso(RegistroCursoCadastrarViewModel novoRegistrocurso);
        void AtualizarSituacao(int idRegistroCurso);
        void EnviaEmailDescricao(string email);

    }
}
