# keena
Demo project

1. Using SQL Server to create Database [keena]
2. On the API folder, change appsetting.json if you have another database name
            "DefaultConnection": "Server=localhost;Database=keena;Trusted_Connection=True;"
3. Run Entiti framework with command:
              1. dotnet tool install --global dotnet -ef
              2. dotnet ef migrations add InitialCreate -o Dta/Migrations
              3. dotnet ef database update.
              
              
            
