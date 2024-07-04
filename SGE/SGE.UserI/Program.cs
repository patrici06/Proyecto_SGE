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
//Configuro Repositorio Usuarios
builder.Services.AddScoped<IUsuariosRepositorios, UsuarioRepositorio>( UR => new UsuarioRepositorio(dataContext));
//Decalro los casos de uso de usuarios como Transient
builder.Services.AddTransient<CasoUsoAltaUsuario>(); 
builder.Services.AddTransient<CasoUsoBajaUsuario>(); 
builder.Services.AddTransient<CasoUsoConsultaUsuarioID>(); 
builder.Services.AddTransient<CasoUsoConsultaUsuarios>();
builder.Services.AddTransient<CasoUsoLoguear>();
builder.Services.AddTransient<CasoUsoModificacionUsuario>();
builder.Services.AddTransient<CasoUsoOtorgarPermisos>();

// builder.Services.AddScoped<ServicioAutorizacion>();
builder.Services.AddScoped<UsuarioValidador>();

//Configuro Repositorio Expediente
builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorio>( ER => new ExpedienteRepositorio(dataContext));

//Configuro Repositorios de Tramires
builder.Services.AddScoped<ITramiteRepositorio, TramitesRepositorio>( TR => new TramitesRepositorio(dataContext,   
                                                                                    new ExpedienteRepositorio(dataContext)
                                                                                    ,new EspecificacionCambioEstado()));
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
