using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class FavoritosCursoRepository : IFavoritosCursoRepository
    {
        senaiRhContext ctx = new senaiRhContext();

        /// <summary>
        /// Adcionar um curso dos favoritos
        /// </summary>
        /// <param name="Novofavorito"></param>
        public void AdcionarFavoritos(Cursofavorito Novofavorito)
        {
            Cursofavorito curso = new Cursofavorito()
            {
                IdCurso = Novofavorito.IdCurso,
                IdUsuario = Novofavorito.IdUsuario
            };
            ctx.Cursofavoritos.Add(curso);
            ctx.SaveChanges();

        }

        /// <summary>
        /// Buscar um favorito curso pelo seu id
        /// </summary>
        /// <param name="Id">id do curso favorito</param>
        /// <returns></returns>
        public Cursofavorito BuscarCursoFavoritoPorId(int Id)
        {
            return ctx.Cursofavoritos.FirstOrDefault(c => c.IdCursoFavorito == Id);
        }


        /// <summary>
        /// Excluir um curso dos favoritos 
        /// </summary>
        /// <param name="Id">Id do curso favorito</param>
        public void ExcluirFavoritos(int Id)
        {
            ctx.Cursofavoritos.Remove(BuscarCursoFavoritoPorId(Id));
            ctx.SaveChanges();
        }


        /// <summary>
        /// Listar os cursos favoritos de um determinado usuario
        /// </summary>
        /// <returns></returns>
        public List<Cursofavorito> ListarTodos()
        {
            return ctx.Cursofavoritos.Select(f => new Cursofavorito { 
                                                IdCursoFavorito =f.IdCursoFavorito,
                                                IdCurso = f.IdCurso,
                                                IdUsuario = f.IdUsuario,
                                                IdCursoNavigation = new Curso {
                                                    
                                                    IdEmpresa = f.IdCursoNavigation.IdEmpresa,
                                                    NomeCurso = f.IdCursoNavigation.NomeCurso,
                                                    DescricaoCurso = f.IdCursoNavigation.DescricaoCurso,
                                                    SiteCurso = f.IdCursoNavigation.SiteCurso,
                                                    ModalidadeCurso = f.IdCursoNavigation.ModalidadeCurso,
                                                    CaminhoImagemCurso = f.IdCursoNavigation.CaminhoImagemCurso,
                                                    CargaHoraria = f.IdCursoNavigation.CargaHoraria,
                                                    DataFinalizacao = f.IdCursoNavigation.DataFinalizacao,
                                                    MediaAvaliacaoCurso = f.IdCursoNavigation.MediaAvaliacaoCurso
                                                },
                                                IdUsuarioNavigation = new Usuario { 
                                                    Nome = f.IdUsuarioNavigation.Nome,
                                                    Email = f.IdUsuarioNavigation.Email,
                                                    Cpf = f.IdUsuarioNavigation.Cpf,
                                                    SaldoMoeda = f.IdUsuarioNavigation.SaldoMoeda
                                                }
                                            }).ToList();
        }
    }
}
