using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IFavoritosDescontoRepository
    {

        List<Descontofavorito> ListarTodos();

        void AdcionarFavoritos(Descontofavorito Novofavorito);
        void ExcluirFavoritos(int Id);
        Descontofavorito BuscarDescontoFavoritoPorId(int Id);
    }
}
