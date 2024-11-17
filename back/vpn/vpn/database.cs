using Microsoft.EntityFrameworkCore;
using vpn.Data.Data;



namespace vpn.connect
{
    public class database
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=;Trusted_Connection=True;MultipleActiveResultSets=true");
                // or
                // options.UseSqlite("Filename=path_to_your_sqlite_file.db");
            });
            services.AddControllers();
        }
    }
}
