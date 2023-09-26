param webAppName string = 'web-app-created-with-bicep'
param location string = 'switzerlandnorth' // Change to your desired location
param runtimeStack string = 'DOTNET|7.0' // Specify .NET 7 runtime

resource webApp 'Microsoft.Web/sites@2022-09-01' = {
  name: webAppName
  location: location
  kind: 'app'
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      linuxFxVersion: runtimeStack
    }
  }
}

resource appServicePlan 'Microsoft.Web/serverfarms@2022-09-01' = {
  name: '${webAppName}-asp'
  location: location
  sku: {
    name: 'F1' // Use the Free (F1) tier
  }
  properties: {
    reserved: true
  }
}

output webAppUrl string = webApp.properties.defaultHostName
