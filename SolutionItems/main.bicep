param prefix string
param location string
param tier string = 'Consumption'
param capacity int = 0 //needed for the consumption tier to work
param serviceUrl string = 'https://web-app-created-with-bicep.azurewebsites.net/'

//
// use case: create brand new apim

// resource apiManagementInstance 'Microsoft.ApiManagement/service@2021-08-01' = {
//   name: '${prefix}-apim'
//   location: location
//   sku:{
//     capacity: capacity
//     name: tier
//   }
//   properties:{
//     virtualNetworkType: 'None'
//     publisherEmail: 'clemenscy@protonmail.com'
//     publisherName: 'EPAM reserach'
//   }
// }

// use case: add api to existing apim

resource apiManagementInstance 'Microsoft.ApiManagement/service@2021-08-01' existing = {
  name: '${prefix}-apim'
}

resource myAspNetCoreApi2 'Microsoft.ApiManagement/service/apis@2022-08-01' ={
  name: '${prefix}-apim/swaggerApiDevOps'
  
  properties:{
    serviceUrl: serviceUrl
    format:'openapi-link' // '-link' because we point to a swagger.json endpoint
    value: '${serviceUrl}/swagger/v1/swagger.json'
    path: 'myApiFromDevOps' //unique
  }
}
