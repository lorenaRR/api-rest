﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiblioAstur
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BibliotecaEntities : DbContext
    {
        public BibliotecaEntities()
            : base("name=BibliotecaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<SeleccionarUsuariosDTO> up_Usuarios_SEL_SeleccionarUsuarios(string dni, Nullable<byte> admin, string nombre, string apellidos)
        {
            var dniParameter = dni != null ?
                new ObjectParameter("dni", dni) :
                new ObjectParameter("dni", typeof(string));
    
            var adminParameter = admin.HasValue ?
                new ObjectParameter("admin", admin) :
                new ObjectParameter("admin", typeof(byte));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("apellidos", apellidos) :
                new ObjectParameter("apellidos", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SeleccionarUsuariosDTO>("up_Usuarios_SEL_SeleccionarUsuarios", dniParameter, adminParameter, nombreParameter, apellidosParameter);
        }

        public System.Data.Entity.DbSet<BiblioAstur.SeleccionarUsuariosDTO> SeleccionarUsuariosDTOes { get; set; }
    }
}