# Order Status Inquiry Bot - .NET Core Web API
## Overview
This project entails the development and deployment of a conversational bot using Dialogflow, integrated with a .NET Core Web API. The primary function of the bot is to handle inquiries regarding order statuses. The API, designed to facilitate this interaction, is deployed on Azure App Service via GitHub Actions, ensuring continuous integration and delivery.

## ProjectURL : [chatbotintegration.azurewebsites.net](https://chatbotintegration.azurewebsites.net/)

## Features
- **Dialogflow Integration**: The bot leverages Dialogflow's natural language processing capabilities to understand and respond to user inquiries about their order status.
- **Webhook Implementation**: A webhook is implemented to handle real-time requests and responses between Dialogflow and the .NET Core Web API.
- **Azure App Service Deployment**: The API is deployed on Azure App Service, ensuring high availability and scalability.
- **GitHub Actions Workflow**: Automated deployment is achieved using GitHub Actions, enabling continuous integration and continuous deployment (CI/CD).

## Technologies Used
- **.NET Core Web API**: Provides the backend logic and endpoints for the bot.
- **Dialogflow**: Manages the conversational aspect of the bot.
- **Azure App Service**: Hosts the deployed API.
- **GitHub Actions**: Automates the build and deployment processes.

## Architecture
1. **User Interaction**: The user interacts with the Dialogflow bot.
2. **Dialogflow Processing**: Dialogflow processes the user's query and sends a request to the webhook.
3. **Webhook Handling**: The webhook, implemented using .NET Core Web API, processes the request.
4. **Order Status Inquiry**: The API sends post request to [OrderApi](https://orderstatusapi-dot-organization-project-311520.uc.r.appspot.com/api/getOrderStatus) service.
5. **Response Delivery**: The API sends the order status back to Dialogflow, which then responds to the user.

## Usage
- Use the https://chatbotintegration.azurewebsites.net/api/Dialogflow to get the shipment detail. Use a POST request and send the order ID in the request body.

- The request body should be in JSON format and contain the order ID as shown below:
### RequestBody:
```
{
  "queryResult": {
    "queryText": "My order id is 155",
    "parameters": {
      "number": 155
    }
  }
}
```
### ResponseBody
```
{
    "fulfillmentMessages": [
        {
            "text": {
                "text": [
                    "Your order ID 155 will be shipped on Wednesday, 12 Jun 2024"
                ]
            }
        }
    ]
}
```


## Objectives
### Setup a Simple Dialogflow ES Bot

- **Build the Conversational Flow**: Construct the conversational flow as depicted in the sequence diagram (Figure 1) in your Dialogflow ES bot.

### Create a REST API for Webhook Requests

- **Receive the WebhookRequest**: Develop a REST API that can receive a webhook request from the bot created in step 1. Extract the order ID provided by the user from the WebhookRequest.
- **Fetch Shipment Date**: Use the API to make a POST request to fetch the shipment date based on the extracted order ID.
- **Return the WebhookResponse**: Construct and return a WebhookResponse with the appropriate response as documented in the sequence diagram below.

### Sequecne Diagram

![image](https://github.com/MAKMoiz23/ChatBotIntegration/assets/69483202/cce47522-a1c4-407f-a848-79c794b02953)

### Optional Tasks:
- Convert shipment date to a human-readable format.
- Deploy the REST API to any cloud instance (AWS, Azure,GCP, IBM, etc.)

## Setup
### Prerequisites
- .NET Core SDK 8.0
- Dialogflow ES account

### Local Setup
1. Clone the Repository
```
https://github.com/MAKMoiz23/ChatBotIntegration.git
cd ChatBotIntegration
```
2. Build the Solution
```
dotnet build
```
3. Run the Application
```
dotnet run
```
Local Api URL will be : http://localhost:5114 <br /><br />
4. Expose localhost port for testing
```
ngrok http 127.0.0.1:5114
```
Now copy the ngrok URL {your ngrok url here}/api/Dialogflow to DialogFlow webhook

## Dialogflow Configuration:
- Set up Dialogflow intent with webhook fulfillment using the ngrok URL.
- Test the bot in the Dialogflow console.

## API Specification
### API URL https://orderstatusapi-dot-organization-project-311520.uc.r.appspot.com/api/getOrderStatus

### API Method: POST

### Request Body
```
{
  "orderId": "31313"
}

```
### Response Body
```
{
  "shipmentDate": "2022-08-18T21:31:25.565Z"
}
```

## Demo Video
[Demo Video]()
