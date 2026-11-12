Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Producto")>
Public Class Producto

    Public Property Id As Integer

    <Required(ErrorMessage:="El nombre es obligatorio")>
    <StringLength(40, ErrorMessage:="El nombre no puede superar los 40 caracteres")>
    Public Property Nombre As String

    Public Property Precio As Decimal

    Public Property CategoriaID As Integer

    Public Property Categoria As Categoria

End Class

