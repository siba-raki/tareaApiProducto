Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class ProductoCreateDTO

    <Required(ErrorMessage:="El nombre es obligatorio")>
    <StringLength(50, ErrorMessage:="El nombre no puede superar los 50 caracteres")>
    Public Property Nombre As String

    <Range(0.01, 999999999, ErrorMessage:="El precio debe ser mayor a cero")>
    Public Property Precio As Decimal

    Public Property CategoriaID As Integer
End Class
