﻿

//------------------------------------------------------------------------------
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


    public virtual ObjectResult<Nullable<int>> up_Usuarios_INS_InsertarUsuario(string dni, string nombre, string apellidos, string direccion, string telefono, string email, string usuario, string password, Nullable<bool> admin, ObjectParameter estado)
    {

        var dniParameter = dni != null ?
            new ObjectParameter("dni", dni) :
            new ObjectParameter("dni", typeof(string));


        var nombreParameter = nombre != null ?
            new ObjectParameter("nombre", nombre) :
            new ObjectParameter("nombre", typeof(string));


        var apellidosParameter = apellidos != null ?
            new ObjectParameter("apellidos", apellidos) :
            new ObjectParameter("apellidos", typeof(string));


        var direccionParameter = direccion != null ?
            new ObjectParameter("direccion", direccion) :
            new ObjectParameter("direccion", typeof(string));


        var telefonoParameter = telefono != null ?
            new ObjectParameter("telefono", telefono) :
            new ObjectParameter("telefono", typeof(string));


        var emailParameter = email != null ?
            new ObjectParameter("email", email) :
            new ObjectParameter("email", typeof(string));


        var usuarioParameter = usuario != null ?
            new ObjectParameter("usuario", usuario) :
            new ObjectParameter("usuario", typeof(string));


        var passwordParameter = password != null ?
            new ObjectParameter("password", password) :
            new ObjectParameter("password", typeof(string));


        var adminParameter = admin.HasValue ?
            new ObjectParameter("admin", admin) :
            new ObjectParameter("admin", typeof(bool));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Usuarios_INS_InsertarUsuario", dniParameter, nombreParameter, apellidosParameter, direccionParameter, telefonoParameter, emailParameter, usuarioParameter, passwordParameter, adminParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Usuarios_UPD_ActualizarUsuario(string dni, string nombre, string apellidos, string direccion, string telefono, string email, string usuario, string password, Nullable<bool> admin, ObjectParameter estado)
    {

        var dniParameter = dni != null ?
            new ObjectParameter("dni", dni) :
            new ObjectParameter("dni", typeof(string));


        var nombreParameter = nombre != null ?
            new ObjectParameter("nombre", nombre) :
            new ObjectParameter("nombre", typeof(string));


        var apellidosParameter = apellidos != null ?
            new ObjectParameter("apellidos", apellidos) :
            new ObjectParameter("apellidos", typeof(string));


        var direccionParameter = direccion != null ?
            new ObjectParameter("direccion", direccion) :
            new ObjectParameter("direccion", typeof(string));


        var telefonoParameter = telefono != null ?
            new ObjectParameter("telefono", telefono) :
            new ObjectParameter("telefono", typeof(string));


        var emailParameter = email != null ?
            new ObjectParameter("email", email) :
            new ObjectParameter("email", typeof(string));


        var usuarioParameter = usuario != null ?
            new ObjectParameter("usuario", usuario) :
            new ObjectParameter("usuario", typeof(string));


        var passwordParameter = password != null ?
            new ObjectParameter("password", password) :
            new ObjectParameter("password", typeof(string));


        var adminParameter = admin.HasValue ?
            new ObjectParameter("admin", admin) :
            new ObjectParameter("admin", typeof(bool));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Usuarios_UPD_ActualizarUsuario", dniParameter, nombreParameter, apellidosParameter, direccionParameter, telefonoParameter, emailParameter, usuarioParameter, passwordParameter, adminParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Usuarios_DEL_BorrarUsuario(string dni, ObjectParameter estado)
    {

        var dniParameter = dni != null ?
            new ObjectParameter("dni", dni) :
            new ObjectParameter("dni", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Usuarios_DEL_BorrarUsuario", dniParameter, estado);
    }


    public virtual ObjectResult<SeleccionarCategoriasDTO> up_Categorias_SEL_SeleccionarCategorias(string id_categoria, string categoria)
    {

        var id_categoriaParameter = id_categoria != null ?
            new ObjectParameter("id_categoria", id_categoria) :
            new ObjectParameter("id_categoria", typeof(string));


        var categoriaParameter = categoria != null ?
            new ObjectParameter("categoria", categoria) :
            new ObjectParameter("categoria", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SeleccionarCategoriasDTO>("up_Categorias_SEL_SeleccionarCategorias", id_categoriaParameter, categoriaParameter);
    }


    public virtual ObjectResult<Nullable<int>> up_Usuarios_UPD_ActualizarPassword(string dni, string pass, string estado)
    {

        var dniParameter = dni != null ?
            new ObjectParameter("dni", dni) :
            new ObjectParameter("dni", typeof(string));


        var passParameter = pass != null ?
            new ObjectParameter("pass", pass) :
            new ObjectParameter("pass", typeof(string));


        var estadoParameter = estado != null ?
            new ObjectParameter("Estado", estado) :
            new ObjectParameter("Estado", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Usuarios_UPD_ActualizarPassword", dniParameter, passParameter, estadoParameter);
    }


    public virtual ObjectResult<LoginsDTO> up_Usuarios_SEL_Logins(string user, string pass)
    {

        var userParameter = user != null ?
            new ObjectParameter("user", user) :
            new ObjectParameter("user", typeof(string));


        var passParameter = pass != null ?
            new ObjectParameter("pass", pass) :
            new ObjectParameter("pass", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoginsDTO>("up_Usuarios_SEL_Logins", userParameter, passParameter);
    }


    public virtual ObjectResult<SeleccionarLibrosDTO> up_Libros_SEL_SeleccionarLibros(string isbn, string titulo, string subtitulo, string editorial, string autor)
    {

        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        var tituloParameter = titulo != null ?
            new ObjectParameter("titulo", titulo) :
            new ObjectParameter("titulo", typeof(string));


        var subtituloParameter = subtitulo != null ?
            new ObjectParameter("subtitulo", subtitulo) :
            new ObjectParameter("subtitulo", typeof(string));


        var editorialParameter = editorial != null ?
            new ObjectParameter("editorial", editorial) :
            new ObjectParameter("editorial", typeof(string));


        var autorParameter = autor != null ?
            new ObjectParameter("autor", autor) :
            new ObjectParameter("autor", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SeleccionarLibrosDTO>("up_Libros_SEL_SeleccionarLibros", isbnParameter, tituloParameter, subtituloParameter, editorialParameter, autorParameter);
    }


    public virtual ObjectResult<Nullable<int>> up_Libros_INS_InsertarLibro(string isbn, string titulo, string subtitulo, Nullable<System.DateTime> fechaPublicacion, string descripcion, Nullable<int> nPaginas, string imagen, string editorial, Nullable<int> stock, Nullable<bool> reservado, Nullable<bool> prestado, ObjectParameter estado)
    {

        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        var tituloParameter = titulo != null ?
            new ObjectParameter("titulo", titulo) :
            new ObjectParameter("titulo", typeof(string));


        var subtituloParameter = subtitulo != null ?
            new ObjectParameter("subtitulo", subtitulo) :
            new ObjectParameter("subtitulo", typeof(string));


        var fechaPublicacionParameter = fechaPublicacion.HasValue ?
            new ObjectParameter("fechaPublicacion", fechaPublicacion) :
            new ObjectParameter("fechaPublicacion", typeof(System.DateTime));


        var descripcionParameter = descripcion != null ?
            new ObjectParameter("descripcion", descripcion) :
            new ObjectParameter("descripcion", typeof(string));


        var nPaginasParameter = nPaginas.HasValue ?
            new ObjectParameter("nPaginas", nPaginas) :
            new ObjectParameter("nPaginas", typeof(int));


        var imagenParameter = imagen != null ?
            new ObjectParameter("imagen", imagen) :
            new ObjectParameter("imagen", typeof(string));


        var editorialParameter = editorial != null ?
            new ObjectParameter("editorial", editorial) :
            new ObjectParameter("editorial", typeof(string));


        var stockParameter = stock.HasValue ?
            new ObjectParameter("stock", stock) :
            new ObjectParameter("stock", typeof(int));


        var reservadoParameter = reservado.HasValue ?
            new ObjectParameter("reservado", reservado) :
            new ObjectParameter("reservado", typeof(bool));


        var prestadoParameter = prestado.HasValue ?
            new ObjectParameter("prestado", prestado) :
            new ObjectParameter("prestado", typeof(bool));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Libros_INS_InsertarLibro", isbnParameter, tituloParameter, subtituloParameter, fechaPublicacionParameter, descripcionParameter, nPaginasParameter, imagenParameter, editorialParameter, stockParameter, reservadoParameter, prestadoParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Autores_Libros_INS_InsertarAutorLibro(Nullable<System.Guid> id_autor, string isbn, ObjectParameter estado)
    {

        var id_autorParameter = id_autor.HasValue ?
            new ObjectParameter("id_autor", id_autor) :
            new ObjectParameter("id_autor", typeof(System.Guid));


        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Autores_Libros_INS_InsertarAutorLibro", id_autorParameter, isbnParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Autores_INS_InsertarAutor(string nombre, string apellidos, ObjectParameter estado)
    {

        var nombreParameter = nombre != null ?
            new ObjectParameter("nombre", nombre) :
            new ObjectParameter("nombre", typeof(string));


        var apellidosParameter = apellidos != null ?
            new ObjectParameter("apellidos", apellidos) :
            new ObjectParameter("apellidos", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Autores_INS_InsertarAutor", nombreParameter, apellidosParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Categorias_Libros_INS_InsertarCategoriaLibro(Nullable<System.Guid> id_categoria, string isbn, ObjectParameter estado)
    {

        var id_categoriaParameter = id_categoria.HasValue ?
            new ObjectParameter("id_categoria", id_categoria) :
            new ObjectParameter("id_categoria", typeof(System.Guid));


        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Categorias_Libros_INS_InsertarCategoriaLibro", id_categoriaParameter, isbnParameter, estado);
    }


    public virtual ObjectResult<SeleccionarAutoresDTO> up_Autores_SEL_SeleccionarAutores(string id_autor, string nombre, string apellidos)
    {

        var id_autorParameter = id_autor != null ?
            new ObjectParameter("id_autor", id_autor) :
            new ObjectParameter("id_autor", typeof(string));


        var nombreParameter = nombre != null ?
            new ObjectParameter("nombre", nombre) :
            new ObjectParameter("nombre", typeof(string));


        var apellidosParameter = apellidos != null ?
            new ObjectParameter("apellidos", apellidos) :
            new ObjectParameter("apellidos", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SeleccionarAutoresDTO>("up_Autores_SEL_SeleccionarAutores", id_autorParameter, nombreParameter, apellidosParameter);
    }


    public virtual ObjectResult<Nullable<int>> up_Categorias_INS_InsertarCategoria(string categoria, ObjectParameter estado)
    {

        var categoriaParameter = categoria != null ?
            new ObjectParameter("categoria", categoria) :
            new ObjectParameter("categoria", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Categorias_INS_InsertarCategoria", categoriaParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Libros_DEL_BorrarLibro(string isbn, ObjectParameter estado)
    {

        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Libros_DEL_BorrarLibro", isbnParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Reservas_INS_InsertarReserva(string isbn, string dni, Nullable<System.DateTime> fecha_reserva, ObjectParameter estado)
    {

        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        var dniParameter = dni != null ?
            new ObjectParameter("dni", dni) :
            new ObjectParameter("dni", typeof(string));


        var fecha_reservaParameter = fecha_reserva.HasValue ?
            new ObjectParameter("fecha_reserva", fecha_reserva) :
            new ObjectParameter("fecha_reserva", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Reservas_INS_InsertarReserva", isbnParameter, dniParameter, fecha_reservaParameter, estado);
    }


    public virtual ObjectResult<SeleccionarReservasDTO> up_Reservas_SEL_SeleccionarReservas(string dni, string isbn)
    {

        var dniParameter = dni != null ?
            new ObjectParameter("dni", dni) :
            new ObjectParameter("dni", typeof(string));


        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SeleccionarReservasDTO>("up_Reservas_SEL_SeleccionarReservas", dniParameter, isbnParameter);
    }


    public virtual ObjectResult<SeleccionarAutoresLibroDTO> up_Autores_Libros_SEL_SeleccionarAutoresLibro(string id_autor, string isbn)
    {

        var id_autorParameter = id_autor != null ?
            new ObjectParameter("id_autor", id_autor) :
            new ObjectParameter("id_autor", typeof(string));


        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SeleccionarAutoresLibroDTO>("up_Autores_Libros_SEL_SeleccionarAutoresLibro", id_autorParameter, isbnParameter);
    }


    public virtual ObjectResult<SeleccionarCategoriaLibroDTO> up_Categorias_Libros_SEL_SeleccionarCategoriaLibro(string id_categorias_libros, string id_categoria, string isbn)
    {

        var id_categorias_librosParameter = id_categorias_libros != null ?
            new ObjectParameter("id_categorias_libros", id_categorias_libros) :
            new ObjectParameter("id_categorias_libros", typeof(string));


        var id_categoriaParameter = id_categoria != null ?
            new ObjectParameter("id_categoria", id_categoria) :
            new ObjectParameter("id_categoria", typeof(string));


        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SeleccionarCategoriaLibroDTO>("up_Categorias_Libros_SEL_SeleccionarCategoriaLibro", id_categorias_librosParameter, id_categoriaParameter, isbnParameter);
    }


    public virtual ObjectResult<Nullable<int>> up_Autores_DEL_BorrarAutor(string id_autor, ObjectParameter estado)
    {

        var id_autorParameter = id_autor != null ?
            new ObjectParameter("id_autor", id_autor) :
            new ObjectParameter("id_autor", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Autores_DEL_BorrarAutor", id_autorParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Autores_Libros_DEL_BorrarAutorLibro(string id_autores_libros, ObjectParameter estado)
    {

        var id_autores_librosParameter = id_autores_libros != null ?
            new ObjectParameter("id_autores_libros", id_autores_libros) :
            new ObjectParameter("id_autores_libros", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Autores_Libros_DEL_BorrarAutorLibro", id_autores_librosParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Categorias_Libros_DEL_BorrarCategoriaLibro(string id_categorias_libros, ObjectParameter estado)
    {

        var id_categorias_librosParameter = id_categorias_libros != null ?
            new ObjectParameter("id_categorias_libros", id_categorias_libros) :
            new ObjectParameter("id_categorias_libros", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Categorias_Libros_DEL_BorrarCategoriaLibro", id_categorias_librosParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Categorias_DEL_BorrarCategoria(string id_categoria, ObjectParameter estado)
    {

        var id_categoriaParameter = id_categoria != null ?
            new ObjectParameter("id_categoria", id_categoria) :
            new ObjectParameter("id_categoria", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Categorias_DEL_BorrarCategoria", id_categoriaParameter, estado);
    }


    public virtual ObjectResult<Nullable<int>> up_Libros_UPD_ActualizarLibro(string isbn, string titulo, string subtitulo, Nullable<System.DateTime> fechaPublicacion, string descripcion, Nullable<int> nPaginas, string imagen, string editorial, Nullable<int> stock, ObjectParameter estado)
    {

        var isbnParameter = isbn != null ?
            new ObjectParameter("isbn", isbn) :
            new ObjectParameter("isbn", typeof(string));


        var tituloParameter = titulo != null ?
            new ObjectParameter("titulo", titulo) :
            new ObjectParameter("titulo", typeof(string));


        var subtituloParameter = subtitulo != null ?
            new ObjectParameter("subtitulo", subtitulo) :
            new ObjectParameter("subtitulo", typeof(string));


        var fechaPublicacionParameter = fechaPublicacion.HasValue ?
            new ObjectParameter("fechaPublicacion", fechaPublicacion) :
            new ObjectParameter("fechaPublicacion", typeof(System.DateTime));


        var descripcionParameter = descripcion != null ?
            new ObjectParameter("descripcion", descripcion) :
            new ObjectParameter("descripcion", typeof(string));


        var nPaginasParameter = nPaginas.HasValue ?
            new ObjectParameter("nPaginas", nPaginas) :
            new ObjectParameter("nPaginas", typeof(int));


        var imagenParameter = imagen != null ?
            new ObjectParameter("imagen", imagen) :
            new ObjectParameter("imagen", typeof(string));


        var editorialParameter = editorial != null ?
            new ObjectParameter("editorial", editorial) :
            new ObjectParameter("editorial", typeof(string));


        var stockParameter = stock.HasValue ?
            new ObjectParameter("stock", stock) :
            new ObjectParameter("stock", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("up_Libros_UPD_ActualizarLibro", isbnParameter, tituloParameter, subtituloParameter, fechaPublicacionParameter, descripcionParameter, nPaginasParameter, imagenParameter, editorialParameter, stockParameter, estado);
    }

}

}

