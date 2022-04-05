﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G2.Domains
{
    public partial class Minhasatividade
    {
        public int IdMinhasAtividades { get; set; }
        public byte IdSituacaoAtividade { get; set; }
        public int IdAtividade { get; set; }
        public byte IdSetor { get; set; }
        public int IdUsuario { get; set; }

        public virtual Atividade IdAtividadeNavigation { get; set; }
        public virtual Setor IdSetorNavigation { get; set; }
        public virtual Situacaoatividade IdSituacaoAtividadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
