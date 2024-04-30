FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copie o arquivo de texto para dentro da imagem
COPY loaderio-647e4423f6745ebf1a2b4c020c847f74.txt .
COPY . .

RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /app/published-app /app

# Copie o arquivo de texto do estágio de construção para o diretório de trabalho no tempo de execução
COPY --from=build /app/loaderio-647e4423f6745ebf1a2b4c020c847f74.txt .

ENTRYPOINT [ "dotnet", "/app/postcard.dll" ]