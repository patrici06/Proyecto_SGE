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



builder.Services.AddScoped<UsuarioValidador>(); // Registrar UsuarioValidador
builder.Services.AddScoped<ServicioHash>();

//Configuro Repositorio Usuarios
builder.Services.AddScoped<IUsuariosRepositorios, UsuarioRepositorio>( UR => new UsuarioRepositorio(dataContext));

builder.Services.AddScoped<ServicioAutorizacion>(); // Registrar ServicioAutorizacion
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
//Decalro los casos de uso de usuarios como Transient
builder.Services.AddTransient<CasoUsoEliminarPermiso>();
builder.Services.AddTransient<CasoUsoAltaUsuario>(); 
builder.Services.AddTransient<CasoUsoBajaUsuario>(); 
builder.Services.AddTransient<CasoUsoModificacionUsuarioAdmin>();
builder.Services.AddTransient<CasoUsoConsultaUsuarioID>(); 
builder.Services.AddTransient<CasoUsoConsultaUsuarios>();
builder.Services.AddTransient<CasoUsoLoguear>();
builder.Services.AddTransient<CasoUsoModificacionUsuario>();
builder.Services.AddTransient<CasoUsoOtorgarPermisos>();



//Configuro Repositorio Expediente
builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorio>( ER => new ExpedienteRepositorio(dataContext));

//Configuro Repositorios de Tramires
builder.Services.AddScoped<ITramiteRepositorio, TramitesRepositorio>( TR => new TramitesRepositorio(dataContext));
//Declaro los casos de Uso de Tramites como Transient
builder.Services.AddTransient<CasoUsoBajaTramite>();
builder.Services.AddTransient<CasoUsoAltaTramite>();
builder.Services.AddTransient<CasoUsoConsultaEtiquetaTramite>();
builder.Services.AddTransient<CasoUsoConsultaTramiteID>();
builder.Services.AddTransient<CasoUsoConsultaTramites>();
builder.Services.AddTransient<CasoUsoModificacionTramite>();

//Declaro los casos de Uso de Expedientes como Transient
builder.Services.AddTransient<CasoUsoBajaExpediente>();
builder.Services.AddTransient<CasoUsoAltaExpediente>();
builder.Services.AddTransient<CasoUsoConsultaExpedienteID>();
builder.Services.AddTransient<CasoUsoConsultaExpedientes>();
builder.Services.AddTransient<CasoUsoModificacionExpediente>();
builder.Services.AddScoped<ServicioCambioEstado>(); // Registrar EspecificacionCambioEstado
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
