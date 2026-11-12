Imports Microsoft.AspNetCore.Builder
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Hosting

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)
        builder.Services.AddControllers()

        'Swagger
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        builder.Services.AddDbContext(Of AppDbContext)(
        Sub(options)
            options.UseSqlServer(
            builder.Configuration("ConnectionStrings:ConexionBD")
            )
        End Sub
        )

        builder.Services.AddScoped(Of ProductoRepository)
        builder.Services.AddScoped(Of ProductoService)
        builder.Services.AddScoped(Of CategoriaRepository)

        Dim app = builder.Build()
        'Habilitar Swagger
        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.MapControllers()
        app.Run()
    End Sub
End Module
