[1.] Following packages must be install before applying Entity framework
=========================================================================
PM> Install-Package Microsoft.EntityFrameworkCore -Version 2.1.1
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 2.1.1
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design -Version 2.0.0-preview1-final
PM> Install-Package Microsoft.EntityFrameworkCore.Tools -Version 2.1.1
PM> Install-Package Microsoft.EntityFrameworkCore.Tools.DotNet -Version 2.0.0


[2.] Ensure following Item Group should be added into <Application>.proj file
========================================================================
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.5" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="2.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer.Design" Version="2.0.0-preview1-final" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="2.1.1" />
  </ItemGroup>

  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.0.2" />
	<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools" Version="2.1.1" />
	<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
  </ItemGroup>

[3.] Install Mapster for maping models
============================================ 
PM> Install-Package Mapster -Version 3.1.8


[4.] Add connection string to appsettings.json
===========================
"ConnectionStrings": {
    "DefaultConnection": "Data Source=NODHCMSLTP9398\\SQL2014;Initial Catalog=Algebra;Integrated Security=True;MultipleActiveResultSets=True"
  },
  
  
  
[5.] Following settings should be added into StartUp.cs class 
 ==========================================================
public void ConfigureServices(IServiceCollection services)
        {
            ..............

            //Adding EF support for Sql Server
            services.AddEntityFrameworkSqlServer();

            //Adding DB Context
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			
			..................
        }  
		
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ..................

            // Create a service scope to get an ApplicationDbContext instance  using DI
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                // Create the Db if it doesn't exist and applies any pending migration
                dbContext.Database.Migrate();
                DbSeeder.Seed(dbContext);
            }	

			..................			
		}
		

[6.] Adding the Initial Migration
==================================
dotnet ef migrations add "Initial" -o "Data\Migrations"

dotnet ef migrations add "Initial-1" -o "Data\Migrations" --context Algebra.Data.ApplicationDbContext


[7.] Removing the Initial Migration
==================================
dotnet ef migrations remove

[8.] Once migration done, run below commend, it will create the database
======================================================================
(For single DbContext)
dotnet ef database update

(For Multiple DbContext) 
dotnet ef database update --context Algebra.Data.ApplicationDbContext
======================================================================

[9.] To completely remove all migrations and start all over again, do the following:

dotnet ef database update 0
dotnet ef migrations remove

dotnet ef database update --context Algebra.Data.ApplicationDbContext

dotnet ef migrations remove --context Algebra.Data.ApplicationDbContext


[10.] More on Migration
======================================================
https://benjii.me/2017/05/enable-entity-framework-core-migrations-visual-studio-2017/


This command adds a new migration based on the state of your DbContext.

PS C:\> dotnet ef migrations add MigrationName
This command removes the latest migration.
Important: Always use this command to remove a migration. Deleting a migration.cs file will result in a corrupted migrations model.

PS C:\> dotnet ef migrations remove
This command updates the database to the latest version. You can also optionally specify a target migration to migrate up or down to that migration.

PS C:\> dotnet ef database update [MigrationName]





