using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IFavoritosCursoRepository
    {
        List<Cursofavorito> ListarTodos();

        void AdcionarFavoritos(Cursofavorito Novofavorito);
        void ExcluirFavoritos(int Id);
        Cursofavorito BuscarCursoFavoritoPorId(int Id);
        List<Cursofavorito> ListarPorIdFavoritoCurso(int Id);


    }
}
