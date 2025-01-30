# catalog_manager

# Gerenciador de Catálogos da Netflix

Este projeto usa Azure Functions, Cosmos DB, Redis e Storage Account para gerenciar os catálogos da Netflix. A infraestrutura e as funções são criadas no Azure utilizando Terraform para o provisionamento dos recursos.

## Infraestrutura no Azure

### Recursos Criados

1. **Resource Group:** `rg-netflix-catalog`
2. **Storage Account:** `storagecatalog` para armazenar arquivos.
3. **Cosmos DB:** `cosmos-catalog` para armazenar os catálogos em formato JSON.
4. **Redis:** `redis-catalog` para cache de dados.
5. **API Gateway:** `api-gateway` para gerenciar as APIs.

## Funções Criadas

1. **SaveFile:** Função para salvar arquivos no Storage Account.
2. **SaveToCosmosDB:** Função para salvar dados no Cosmos DB.
3. **FilterRecords:** Função para filtrar registros no Cosmos DB.
4. **ListRecords:** Função para listar registros no Cosmos DB.

## Como Executar

1️⃣ Provisionar a Infraestrutura no Azure

Execute o comando Terraform para provisionar todos os recursos:

```bash
terraform init
terraform apply

2️⃣ Criar as Azure Functions

criar as funções necessárias

3️⃣ Publicar as Azure Functions no Azure
Instale a CLI do Azure Functions:
npm install -g azure-functions-core-tools

Faça login no Azure:
az login

Selecione o grupo de recursos:
az account set --subscription "<subscription-id>"


Vá para a pasta do projeto e publique:
cd netflix-catalog-functions
func azure functionapp publish netflix-catalog-functions


4️⃣ Testar as Funções

Salvar Arquivo: Faça um POST na função SaveFile.
Salvar no Cosmos DB: Faça um POST na função SaveToCosmosDB.
Filtrar Registros: Faça um GET na função FilterRecords.
Listar Registros: Faça um GET na função ListRecords.

- Testar as Funções

Salvar Arquivo no Storage Account
curl -X POST -d "@data.json" -H "Content-Type: application/json" https://<function-app-name>.azurewebsites.net/api/SaveFileFunction

Salvar Catálogo no CosmosDB
curl -X POST -d '{"title": "Stranger Things", "genre": "Sci-Fi"}' -H "Content-Type: application/json" https://<function-app-name>.azurewebsites.net/api/SaveToCosmosDBFunction

Filtrar Registros (por gênero)
curl -X GET "https://<function-app-name>.azurewebsites.net/api/FilterRecordsFunction?genre=Sci-Fi"

Listar Todos os Registros
curl -X GET "https://<function-app-name>.azurewebsites.net/api/ListRecordsFunction"

### Dependências

Azure Functions
Cosmos DB
Redis
Storage Account
Terraform (para provisioning)

📂 Estrutura do Projeto

netflix-catalog-functions/
│── SaveFileFunction/
│   ├── function.json
│   ├── run.csx
│── SaveToCosmosDBFunction/
│   ├── function.json
│   ├── run.csx
│── FilterRecordsFunction/
│   ├── function.json
│   ├── run.csx
│── ListRecordsFunction/
│   ├── function.json
│   ├── run.csx
│── host.json
│── local.settings.json
