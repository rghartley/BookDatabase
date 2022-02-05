FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5231

COPY ["bin/Debug/net6.0/", "."]
ENTRYPOINT ["dotnet", "BookDatabase.dll"]
