FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY DotnetBlazorPoker.Models/DotnetBlazorPoker.Models.csproj DotnetBlazorPoker.Models/
COPY DotnetBlazorPoker.Models.UnitTests/DotnetBlazorPoker.Models.UnitTests.csproj DotnetBlazorPoker.Models.UnitTests/
COPY DotnetBlazorPoker.App/DotnetBlazorPoker.App.csproj DotnetBlazorPoker.App/

RUN dotnet restore DotnetBlazorPoker.App/DotnetBlazorPoker.App.csproj
COPY . .
RUN dotnet build DotnetBlazorPoker.App/DotnetBlazorPoker.App.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish DotnetBlazorPoker.App/DotnetBlazorPoker.App.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY DotnetBlazorPoker.App/nginx.conf /etc/nginx/nginx.conf