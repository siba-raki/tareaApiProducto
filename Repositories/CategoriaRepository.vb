Imports Microsoft.EntityFrameworkCore

Public Class CategoriaRepository
    Private ReadOnly contexto As AppDbContext

    Public Sub New(contexto As AppDbContext)
        Me.contexto = contexto
    End Sub

    Public Function ObtenerTodos() As List(Of Categoria)
        Return contexto.Categoria.ToList()
    End Function

    Public Function ObtenerporId(id As Integer) As Categoria
        Return contexto.Categoria.Find(id)
    End Function

    Public Function Existe(id As Integer) As Boolean
        Return contexto.Categoria.Any(Function(c) c.Id = id)
    End Function

End Class
