FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copie o arquivo de texto para dentro da imagem
COPY loaderio-d6290e01b034208f5b307489d50a1820.txt .
COPY . .

RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /app/published-app /app

# Copie o arquivo de texto do estágio de construção para o diretório de trabalho no tempo de execução
COPY --from=build /app/loaderio-d6290e01b034208f5b307489d50a1820.txt .

ENTRYPOINT [ "dotnet", "/app/postcard.dll" ]