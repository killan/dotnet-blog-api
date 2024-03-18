# dotnet-blog-api

https://learn.microsoft.com/fr-be/training/modules/build-web-api-minimal-api/5-exercise-advanced-commands
dotnet new web -o blog -f net8.0

https://medium.com/@saisiva249/how-to-configure-postgres-database-for-a-net-a2ee38f29372
dotnet add package Swashbuckle.AspNetCore --version 6.5.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet tool install --global dotnet-ef --version 8.*

dotnet ef migrations add create_articles
dotnet ef database update
