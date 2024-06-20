using UserInterface.Components;
using Repositorios;
using Aplicacion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//Agregamos el contexto de Base de Datos;
DataContext dataContext = new DataContext();
DataSqlite.Inicializar();
//builder.Services.AddDbContext<DataContext>(options =>
  //  options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
//Agregarmos Servicios de Aplicacion
builder.Services.AddScoped<IUsuariosRepositorios, UsuarioRepositorio>( _context => new UsuarioRepositorio(dataContext));
builder.Services.AddTransient<ServicioUsuarios>();

builder.Services.AddScoped<ServicioAutorizacion>();
builder.Services.AddScoped<UsuarioValidador>();

builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorio>(_context => new ExpedienteRepositorio(dataContext));
builder.Services.AddTransient<ServicioExpedientes>();

builder.Services.AddScoped<ITramiteRepositorio, TramitesRepositorio>(_context => new TramitesRepositorio(dataContext,   
                                                                                    new ExpedienteRepositorio(dataContext)
                                                                                    ,new EspecificacionCambioEstado()));
builder.Services.AddTransient<ServicioTramite>();

builder.Services.AddScoped<ServicioHash>();
builder.Services.AddScoped<EspecificacionCambioEstado>(); // Registrar EspecificacionCambioEstado

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
