Public Class ProductoService

    Private ReadOnly _productoRepository As ProductoRepository
    Private ReadOnly _categoriaRepository As CategoriaRepository

    Public Sub New(productoRepository As ProductoRepository, categoriaRepository As CategoriaRepository)
        _productoRepository = productoRepository
        _categoriaRepository = categoriaRepository
    End Sub

    Public Function ObtenerTodos() As List(Of Producto)
        Return _productoRepository.ObtenerTodos()
    End Function

    Public Function ObtenerporId(id As Integer) As Producto
        Return _productoRepository.ObtenerporId(id)
    End Function

    Public Function Crear(dto As ProductoCreateDTO) As Producto
        If _productoRepository.ExistePorNombre(dto.Nombre) Then
            Return Nothing
        End If

        Dim nuevoProducto As New Producto With {
            .Nombre = dto.Nombre,
            .Precio = dto.Precio,
            .CategoriaID = dto.CategoriaID
        }

        _productoRepository.Agregar(nuevoProducto)
        Return nuevoProducto
    End Function

    Public Function Modificar(id As Integer, productoModificado As Producto) As Producto
        Dim existente = _productoRepository.ObtenerporId(id)
        If existente Is Nothing Then
            Return Nothing
        End If

        existente.Nombre = productoModificado.Nombre
        existente.Precio = productoModificado.Precio
        existente.CategoriaID = productoModificado.CategoriaID

        _productoRepository.Modificar(existente)
        Return existente
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        Dim existente = _productoRepository.ObtenerporId(id)
        If existente Is Nothing Then
            Return False
        End If

        _productoRepository.Eliminar(existente)
        Return True
    End Function

    Public Function ObtenerPorCategoria(categoriaId As Integer) As List(Of Producto)
        ' Verificar si la categoría existe
        Dim existe = False
        If _categoriaRepository IsNot Nothing AndAlso _categoriaRepository.ObtenerporId(categoriaId) IsNot Nothing Then
            existe = True
        ElseIf _productoRepository.ExisteCategoria(categoriaId) Then
            existe = True
        End If

        If Not existe Then
            Return Nothing
        End If

        Return _productoRepository.ObtenerPorCategoria(categoriaId)
    End Function

End Class

