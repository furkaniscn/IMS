using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories.Concrete;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

//Program çalıştığı sürece çalışır. => AddScoped ile aynı mantık
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();

//Program istek yolladığı sürece tekrardan oluşturulur.
builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IDeleteInventoryUseCase, DeleteInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
