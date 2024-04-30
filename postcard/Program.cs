using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDataProtection().UseCryptographicAlgorithms(
    new AuthenticatedEncryptorConfiguration
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Adicione uma rota para o arquivo de verificação do Loader.io
app.Map("/loaderio-d6290e01b034208f5b307489d50a1820", builder =>
{
    builder.Run(async context =>
    {
        var filePath = Path.Combine("loaderio-d6290e01b034208f5b307489d50a1820.txt");
        if (File.Exists(filePath))
        {
            await context.Response.SendFileAsync(filePath);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    });
});

app.Map("/loaderio-008b9c1488999416c68670a184ecd0b8", builder =>
{
    builder.Run(async context =>
    {
        context.Response.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync("loaderio-008b9c1488999416c68670a184ecd0b8");
    });
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//docker build -t oficina17-grupo2 .
//docker run -d -p 8080:80 --name oficina17-grupo2 oficina17-grupo2
