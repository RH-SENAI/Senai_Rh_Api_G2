using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using SenaiRH_G2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        senaiRhContext ctx = new senaiRhContext();


        /// <summary>
        /// Buscar um curso pelo seu id 
        /// </summary>
        /// <param name="id">id do curso a ser buscado</param>
        /// <returns></returns>
        public Curso BuscarPorId(int id)
        {
            return ctx.Cursos.FirstOrDefault(c => c.IdCurso == id);
        }


        /// <summary>
        /// Cadastrar um novo curso
        /// </summary>
        /// <param name="novoCurso">dados desse novo curso a ser cadastrado</param>
        public void CadastrarCurso(CursoCadastroViewModel novoCurso)
        {

            Curso curso = new Curso()
            {
                IdEmpresa = novoCurso.IdEmpresa,
                NomeCurso = novoCurso.NomeCurso,
                DescricaoCurso = novoCurso.DescricaoCurso,
                SiteCurso = novoCurso.SiteCurso,
                ModalidadeCurso = novoCurso.ModalidadeCurso,
                CaminhoImagemCurso = novoCurso.CaminhoImagemCurso,
                CargaHoraria = novoCurso.CargaHoraria,
                DataFinalizacao = novoCurso.DataFinalizacao,
                MediaAvaliacaoCurso = novoCurso.MediaAvaliacaoCurso
            };

            ctx.Cursos.Add(curso);
            ctx.SaveChanges();
            
        }

        /// <summary>
        /// Excluir um curso 
        /// </summary>
        /// <param name="id">id do curso a ser excluido</param>
        public void ExcluirCurso(int id)
        {
            Curso curso = ctx.Cursos.FirstOrDefault(c => c.IdCurso == id);
            foreach (var comentario in ctx.Comentariocursos)
            {
                if (comentario.IdCurso == curso.IdCurso)
                {
                    ctx.Comentariocursos.Remove(comentario);
                }
            }
            foreach (var registro in ctx.Registrocursos)
            {
                if (registro.IdCurso == curso.IdCurso)
                {
                    ctx.Registrocursos.Remove(registro);
                }
            }
            foreach (var favoritos in ctx.Cursofavoritos)
            {
                if (favoritos.IdCurso == curso.IdCurso)
                {
                    ctx.Cursofavoritos.Remove(favoritos);
                }
            }
            ctx.Cursos.Remove(curso);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar todos os cursos
        /// </summary>
        /// <returns></returns>
        public List<Curso> ListarTodos()
        {
            return ctx.Cursos
                    .Select(p => new Curso
                {
                    
                    IdCurso = p.IdCurso,
                    IdEmpresa = p.IdEmpresa,
                    NomeCurso = p.NomeCurso,
                    DescricaoCurso = p.DescricaoCurso,
                    SiteCurso = p.SiteCurso,
                    ModalidadeCurso = p.ModalidadeCurso,
                    CaminhoImagemCurso = p.CaminhoImagemCurso,
                    CargaHoraria = p.CargaHoraria,
                    DataFinalizacao = p.DataFinalizacao,
                    MediaAvaliacaoCurso = p.MediaAvaliacaoCurso,
                    IdEmpresaNavigation = new Empresa()
                    {

                        NomeEmpresa = p.IdEmpresaNavigation.NomeEmpresa,
                        EmailEmpresa = p.IdEmpresaNavigation.EmailEmpresa,
                        TelefoneEmpresa = p.IdEmpresaNavigation.TelefoneEmpresa,
                        IdLocalizacaoNavigation = new Localizacao()
                        {
                            Numero = p.IdEmpresaNavigation.IdLocalizacaoNavigation.Numero,
                            IdLogradouroNavigation = new Logradouro()
                            {
                                NomeLogradouro = p.IdEmpresaNavigation.IdLocalizacaoNavigation.IdLogradouroNavigation.NomeLogradouro
                            },
                            IdEstadoNavigation = new Estado()
                            {
                                NomeEstado = p.IdEmpresaNavigation.IdLocalizacaoNavigation.IdEstadoNavigation.NomeEstado
                            }

                        }


                    }

                    
                })
                .ToList();
        }
    }
}
