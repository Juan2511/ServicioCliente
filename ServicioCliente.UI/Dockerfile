FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ServicioCliente.UI/ServicioCliente.UI.csproj", "ServicioCliente.UI/"]
COPY ["ServicioCliente.Negocios/ServicioCliente.Negocios.csproj", "ServicioCliente.Negocios/"]
COPY ["ServicioCliente.Datos/ServicioCliente.Datos.csproj", "ServicioCliente.Datos/"]
COPY ["ServicioCliente.Entidades/ServicioCliente.Entidades.csproj", "ServicioCliente.Entidades/"]
RUN dotnet restore "ServicioCliente.UI/ServicioCliente.UI.csproj"
COPY . .
WORKDIR "/src/ServicioCliente.UI"
RUN dotnet build "ServicioCliente.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ServicioCliente.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ServicioCliente.UI.dll"]