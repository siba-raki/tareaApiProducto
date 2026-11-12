Imports Microsoft.EntityFrameworkCore

Public Class ProductoRepository
    Private ReadOnly contexto As AppDbContext

    Public Sub New(contexto As AppDbContext)
        Me.contexto = contexto
    End Sub

    Public Sub Agregar(producto As Producto)
        contexto.Productos.Add(producto)
        contexto.SaveChanges()
    End Sub

    Public Function ObtenerTodos() As List(Of Producto)
        Return contexto.Productos _
        .Include(Function(p) p.Categoria).ToList()
    End Function

    Public Function ObtenerporId(id As Integer) As Producto
        Return contexto.Productos _
        .Include(Function(p) p.Categoria) _
        .FirstOrDefault(Function(p) p.Id = id)
    End Function

    Public Sub Modificar(producto As Producto)
        contexto.Productos.Update(producto)
        contexto.SaveChanges()
    End Sub

    Public Sub Eliminar(producto As Producto)
        contexto.Productos.Remove(producto)
        contexto.SaveChanges()
    End Sub

    Public Function ExistePorNombre(nombre As String) As Boolean
        Dim resul = contexto.Productos _
        .Include(Function(p) p.Categoria) _
        .Any(Function(p) p.Nombre.ToLower() = nombre)
        Return resul
    End Function

    Public Function ObtenerPorCategoria(categoriaId As Integer) As List(Of Producto)
        Return contexto.Productos _
            .Include(Function(p) p.Categoria) _
            .Where(Function(p) p.CategoriaID = categoriaId) _
            .ToList()
    End Function

    Public Function ExisteCategoria(categoriaId As Integer) As Boolean
        Return contexto.Categoria _
            .Any(Function(c) c.Id = categoriaId)
    End Function

End Class
