using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using ToDoList;

namespace ToDoListServiceTests.WebAppFactory
{
   public class ConfigWebFactory : WebApplicationFactory<Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder().UseStartup<Startup>();
        }
    }
}
