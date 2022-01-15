
# crea un service principal y rellena los siguientes datos para autenticar
provider "azurerm" {
  features {}
  subscription_id = "699edf11-7721-441e-9976-44a591fe86ac"
  client_id       = "0ce6a5aa-2a36-479c-b4be-4b63d8c1a5e4" # appID
  client_secret   = "xTeBlRIk_oi~2LTvGJk~PjToatVcBUZNi9"   # password
  tenant_id       = "359f9a7d-18ce-42bf-80c8-7cff9e947cec" # tenant
}