Imports Microsoft.AspNetCore.Mvc

<Route("api/[controller]")>
<ApiController>
Public Class ProductosController
    Inherits ControllerBase

    Private ReadOnly servicio As ProductoService

    Public Sub New(servicio As ProductoService)
        Me.servicio = servicio
    End Sub

    <HttpGet>
    Public Function ObtenerProductos()
        Dim productos = servicio.ObtenerTodos()
        Return Ok(productos)
    End Function

    <HttpGet("{id}")>
    Public Function ObtenerPorId(id As Integer)
        Dim producto = servicio.ObtenerporId(id)
        If producto Is Nothing Then
            Return NotFound("Producto no encontrado")
        End If

        Return Ok(producto)
    End Function

    <HttpPost>
    Public Function Crear(dto As ProductoCreateDTO)
        Dim productoCreado = servicio.Crear(dto)
        If productoCreado Is Nothing Then
            Dim respuesta As New ErrorResponseDTO With {
                .Mensaje = "Ya existe un producto con el mismo nombre"
            }
            Return Conflict(respuesta)
        End If

        Return Ok(productoCreado)
    End Function

    <HttpPut("{id}")>
    Public Function Modificar(id As Integer, productoModificado As Producto)
        Dim producto = servicio.Modificar(id, productoModificado)
        If producto Is Nothing Then
            Return NotFound("Producto no encontrado")
        End If

        producto.Nombre = productoModificado.Nombre
        producto.Precio = productoModificado.Precio

        Return Ok(producto)
    End Function

    <HttpDelete("{id}")>
    Public Function Eliminar(id As Integer)
        Dim eliminado = servicio.Eliminar(id)
        If Not eliminado Then
            Return NotFound("Producto no encontrado")
        End If

        Return Ok("Producto eliminado")
    End Function

    <HttpGet("categoria/{categoriaId:int}")>
    <HttpGet("/api/producto/categoria/{categoriaId:int}")>
    Public Function ObtenerPorCategoria(<FromRoute> categoriaId As Integer) As IActionResult
        Dim productos = servicio.ObtenerPorCategoria(categoriaId)

        If productos Is Nothing Then
            Return NotFound(New With {
                .mensaje = "La categoria no existe"
            })
        End If

        Return Ok(productos)
    End Function

End Class
