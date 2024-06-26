using SGE.UserI.Components;
using SGE.Repositorios;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//Agregamos el contexto de Base de Datos y la creamos de no existir
DataContext dataContext = new DataContext();
DataSqlite.Inicializar();
//servicios
builder.Services.AddScoped<IUsuariosRepositorios, UsuarioRepositorio>( UR => new UsuarioRepositorio(dataContext));
builder.Services.AddTransient<ServicioUsuarios>();

builder.Services.AddScoped<ServicioAutorizacion>();
builder.Services.AddScoped<UsuarioValidador>();

builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorio>( ER => new ExpedienteRepositorio(dataContext));
builder.Services.AddTransient<ServicioExpedientes>();

builder.Services.AddScoped<ITramiteRepositorio, TramitesRepositorio>( TR => new TramitesRepositorio(dataContext,   
                                                                                    new ExpedienteRepositorio(dataContext)
                                                                                    ,new EspecificacionCambioEstado()));
builder.Services.AddTransient<ServicioTramite>();

builder.Services.AddScoped<ServicioHash>();
builder.Services.AddScoped<EspecificacionCambioEstado>(); // Registrar EspecificacionCambioEstado
//servicio Del Usuario Loggeado
builder.Services.AddSingleton<ServicioUsuarioEstado>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
