using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IComentarioCursoRepository
    {

        List<Comentariocurso> ListarComenatarioCurso();
        void CadastrarComentarioCurso(Comentariocurso NovoComentario);
        Comentariocurso ListarComentarioPorIdCurso(int Id);
        void ExcluirComentarioCurso(int Id);

        void AlterarComentarioCurso(int Id, Comentariocurso comentarioAtualizado);
    }
}
