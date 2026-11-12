Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Categoria")>
Public Class Categoria
    Public Property Id As Integer

    <Required(ErrorMessage:="La categoria es obligatoria")>
    <StringLength(50, ErrorMessage:="La categoria no puede superar los 50 caracteres")>
    Public Property Descripcion As String

End Class
