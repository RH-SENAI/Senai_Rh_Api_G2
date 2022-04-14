﻿using System.ComponentModel.DataAnnotations;

namespace SenaiRH_G2.ViewModels
{
    public class EmpresaCadastroViewModel
    {

        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "Todos os campos devem ser preenchidos !")]
        public int IdLocalizacao { get; set; }

        [Required(ErrorMessage = "Todos os campos devem ser preenchidos !")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Todos os campos devem ser preenchidos !")]
        public string EmailEmpresa { get; set; }

        [Required(ErrorMessage = "Todos os campos devem ser preenchidos !")]
        public string TelefoneEmpresa { get; set; }

        public string CaminhoImagemEmpresa { get; set; }

    }
}