using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Data.Contexts;
using ToDoApp.Data.Repositories;
using ToDoApp.Data.Repositories.Interfaces;

[assembly: FunctionsStartup(typeof(AzFuncToDo.Startup))]
namespace AzFuncToDo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<ToDoContext>(options =>
                options.UseCosmos("https://todocosmosdb.documents.azure.com:443/",
                "HT1ZjFvJWpqlcB50fZ6n0j92DKXoNrMboG8o7APlqDF6CyLN8QL2VgzLKco6ZsZrJpa1laNYK0OW1QTgKAWE6g==",
                "ToDoDb")
            );
            builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
        }
    }
}
