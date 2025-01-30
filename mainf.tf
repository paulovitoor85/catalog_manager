provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = "rg-netflix-catalog"
  location = "East US"
}

resource "azurerm_storage_account" "storage" {
  name                     = "storagecatalog"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_cosmosdb_account" "cosmosdb" {
  name                = "cosmos-catalog"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  kind                = "GlobalDocumentDB"
  offer_type          = "Standard"
  consistency_policy {
    consistency_level = "Eventual"
  }

geo_location {
    location          = azurerm_resource_group.rg.location
    failover_priority = 0
  }

}

resource "azurerm_redis_cache" "redis" {
  name                = "redis-catalog"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  capacity            = 1
  family              = "C"
  sku_name            = "Basic"
}

resource "azurerm_api_management" "api_gateway" {
  name                = "api-gateway"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  publisher_name      = "Netflix"
  publisher_email     = "netflix@company.com"

  sku_name = "Developer"

}

resource "azurerm_function_app" "function_app" {
  name                       = "netflix-catalog-functions"
  location                   = azurerm_resource_group.rg.location
  resource_group_name        = azurerm_resource_group.rg.name
  storage_account_name       = azurerm_storage_account.storage.name
  storage_account_access_key = azurerm_storage_account.storage.primary_access_key
  os_type                    = "Windows"
  version = "~4"

  app_service_plan_id        = azurerm_service_plan.plan.id
}

resource "azurerm_service_plan" "plan" {
  name                = "function-app-plan"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  os_type             = "Windows"
  sku_name            = "B1"
}