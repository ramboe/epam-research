//comment for testing
param prefix string

resource apiManagementInstance 'Microsoft.ApiManagement/service@2021-08-01' existing = {
  name: '${prefix}-apim'
}

resource myAspNetCoreApi 'Microsoft.ApiManagement/service/apis@2022-08-01' ={
  name: '${prefix}-apim/swaggerApi2'
  
  properties:{
    serviceUrl: 'https://epam-research-swagger-api.azurewebsites.net/'
    format:'openapi-link' // '-link' because we point to a swagger.json endpoint
    value: 'https://epam-research-swagger-api.azurewebsites.net/swagger/v1/swagger.json'
    path: 'myApi' //unique
  }
}

