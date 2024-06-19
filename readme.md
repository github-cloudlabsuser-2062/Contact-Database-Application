# Contact Database Application

This is a guide to help you set up and deploy the Contact Database Application.

## Prerequisites

- Azure account
- GitHub account
- Visual Studio Code or any text editor

## ARM Template Deployment

Azure Resource Manager (ARM) templates are JSON files that define the resources you need to deploy for your application. Follow the steps below to create an ARM template for this application:

1. Create a new file in the root directory of your repository and name it `template.json`.
2. In `template.json`, define your resources. Here's a basic example:

```json
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "parameters": {  },
  "variables": {  },
  "resources": [  ]
}

