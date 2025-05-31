# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia o .csproj primeiro para aproveitar cache de camadas
COPY ["Teste_Loja_do_seu_emanoel.csproj", "."]

# Restaura as dependências
RUN dotnet restore "Teste_Loja_do_seu_emanoel.csproj"

# Copia todo o código fonte
COPY . .

# Build da aplicação (com tratamento de erro)
RUN dotnet build "Teste_Loja_do_seu_emanoel.csproj" -c Release -o /app/build || (echo "Build failed!" && exit 1)

# Estágio de publicação
FROM build AS publish
RUN dotnet publish "Teste_Loja_do_seu_emanoel.csproj" -c Release -o /app/publish

# Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teste_Loja_do_seu_emanoel.dll"]