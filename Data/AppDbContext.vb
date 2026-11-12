Imports Microsoft.EntityFrameworkCore

Public Class AppDbContext
    Inherits DbContext

    Public Sub New(options As DbContextOptions(Of AppDbContext))
        MyBase.New(options)
    End Sub

    Public Property Productos As DbSet(Of Producto)
    Public Property Categoria As DbSet(Of Categoria)
    Public Property Categorias As DbSet(Of Categoria)

End Class
