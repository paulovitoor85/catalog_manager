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

### 1. Provisionar a Infraestrutura no Azure

Execute o comando Terraform para provisionar todos os recursos:

```bash
terraform init
terraform apply

### 2. Configurar as Funções*

Publique as funções no Azure Functions.

### 3. Testar as Funções

Salvar Arquivo: Faça um POST na função SaveFile.
Salvar no Cosmos DB: Faça um POST na função SaveToCosmosDB.
Filtrar Registros: Faça um GET na função FilterRecords.
Listar Registros: Faça um GET na função ListRecords.

### Dependências

Azure Functions
Cosmos DB
Redis
Storage Account
Terraform (para provisioning)
