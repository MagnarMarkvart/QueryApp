## EF Command Line (Migrations)

~~~bash
dotnet tool update --global dotnet-ef

dotnet ef migrations add --project DAL --startup-project WebApp InitialCreate
dotnet ef database update --project DAL --startup-project WebApp 

dotnet ef database drop --project DAL --startup-project WebApp 
~~~

## CodeGenerator CRUD

~~~bash
dotnet tool update --global dotnet-aspnet-codegenerator

cd WebApp

dotnet aspnet-codegenerator razorpage -m Domain.Database.Query -dc AppDbContext -udl -outDir Pages/Queries --referenceScriptLibraries
~~~