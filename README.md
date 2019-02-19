# QA Automation Training

A simple web application to help train Manual QA become QA Automation Engineers.

## Overview

This project is to help train up Manual QA through the use of an integration testing tool, such as xBehave, SpecFlow, Cypress, Protractor, etc.

## Dependencies

- [.NET Core](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/en/download/)

## Installation

- To install the backend dependencies
  ```bash
  cd backend
  dotnet restore
  ```
- To install the frontend dependencies
  ```bash
  cd frontend
  npm install
  ```

## Running the project locally

### Backend
- In the `backend/` folder, open `Quotey.sln` solution file in Visual Studio
- Set the startup project to be `Quotey.WebApi`
- Right-click on the `Quotey.WebApi` project and select `Manage User Secrets`
- Ensure the file looks like
  ```json
  {
    "ConnectionStrings": {
      "QuoteyDatabase": "Server=__SERVER_IP_ADDRESS__,1433;Initial Catalog=__NAME_OF_DATABASE__;User Id=__USERNAME__;Password=__USER_PASSWORD__;Integrated Security=False;"
    }
  }
  ```
- Speak with the course instructor to fill in the appropriate variables (e.g.: `__VARIABLE__`) in the above file
- Press the Run (play icon) button in the top toolbar

### Frontend
- In a terminal, enter
  ```bash
  cd frontend
  npm start
  ```

## License

MIT