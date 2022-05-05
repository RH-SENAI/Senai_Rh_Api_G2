using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class FavoritosDescontoRepository : IFavoritosDescontoRepository
    {

        senaiRhContext ctx = new senaiRhContext();


        /// <summary>
        /// Adcionar um desconto dos favoritos
        /// </summary>
        /// <param name="Novofavorito"></param>
        public void AdcionarFavoritos(Descontofavorito Novofavorito)
        {
            Descontofavorito desconto = new Descontofavorito()
            {
                IdDesconto = Novofavorito.IdDesconto,
                IdUsuario = Novofavorito.IdUsuario
            };
            ctx.Descontofavoritos.Add(desconto);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um favorito desconto pelo seu id
        /// </summary>
        /// <param name="Id">id do desconto favorito</param>
        /// <returns></returns>
        public Descontofavorito BuscarDescontoFavoritoPorId(int Id)
        {
            return ctx.Descontofavoritos.FirstOrDefault(c => c.IdDescontoFavorito == Id);
        }

        /// <summary>
        /// Excluir um desconto dos favoritos 
        /// </summary>
        /// <param name="Id">Id do desconto favorito</param>
        public void ExcluirFavoritos(int Id)
        {
            ctx.Descontofavoritos.Remove(BuscarDescontoFavoritoPorId(Id));
            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar os descontos favoritos de um determinado usuario
        /// </summary>
        /// <returns></returns>
        public List<Descontofavorito> ListarTodos()
        {
            return ctx.Descontofavoritos.Select(f => new Descontofavorito
            {
                IdDescontoFavorito = f.IdDescontoFavorito,
                IdDesconto = f.IdDesconto,
                IdUsuario = f.IdUsuario,
                IdDescontoNavigation = new Desconto
                {

                    IdEmpresa = f.IdDescontoNavigation.IdEmpresa,
                    NomeDesconto = f.IdDescontoNavigation.NomeDesconto,
                    DescricaoDesconto = f.IdDescontoNavigation.DescricaoDesconto,
                    CaminhoImagemDesconto = f.IdDescontoNavigation.CaminhoImagemDesconto,
                    ValidadeDesconto = f.IdDescontoNavigation.ValidadeDesconto,
                    ValorDesconto = f.IdDescontoNavigation.ValorDesconto,
                    NumeroCupom = f.IdDescontoNavigation.NumeroCupom,
                    MediaAvaliacaoDesconto = f.IdDescontoNavigation.MediaAvaliacaoDesconto,
                },
                IdUsuarioNavigation = new Usuario
                {
                    Nome = f.IdUsuarioNavigation.Nome,
                    Email = f.IdUsuarioNavigation.Email,
                    Cpf = f.IdUsuarioNavigation.Cpf,
                    SaldoMoeda = f.IdUsuarioNavigation.SaldoMoeda
                }
            }).ToList();
        }
    }
}

