using System;
using System.Collections.Generic;

#nullable disable

namespace Migrations.Web.Models.NorthwindDB.Entities
{
    public partial class Usuario
    {
        public long UsuarioId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
