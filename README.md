# Project: Blog Application Backend

This repository contains the backend code for a blog application. The application is built using the following technologies:

Autofac: A dependency injection library for .NET
JWT: A JSON Web Token authentication library
AOP: Aspect-oriented programming framework for .NET
Entity Framework: An object-relational mapper (ORM) for .NET
.NET 8: The latest version of the .NET framework
Serilog: A structured logging library for .NET
Swagger: A tool for creating documentation for REST APIs

## Features
The application includes the following features:

User authentication and authorization: Users can create accounts and log in to the application. Once logged in, users are authorized to perform certain actions, such as creating, editing, and deleting blog posts.
Blog post management: Users can create, edit, and delete blog posts. Posts can be tagged with categories and keywords.

## Installation
To install the application, you will need to have the following prerequisites:

Visual Studio 2022: The latest version of Visual Studio
.NET SDK 6.0: The latest version of the .NET SDK
Once you have the prerequisites installed, you can clone the repository and open the solution in Visual Studio. The application will be built and run automatically.

## Usage
To use the application, you will need to create an account and log in. Once logged in, you can create, edit, and delete blog posts.

To access the Swagger documentation, go to the following URL:

http://localhost:5000/swagger/index.html
This will show you all of the API's endpoints, request bodies, and responses.

## Testing
The application includes a suite of unit tests that can be run to ensure that the code is working correctly. To run the unit tests, open the Test Explorer window in Visual Studio and select the project to test. Then, click the Run Tests button.

## Deployment
The application can be deployed to a web server using IIS or Kestrel. To deploy the application to IIS, follow these steps:

Publish the application to a folder on your web server.
Create an application pool in IIS and point it to the folder you published the application to.
Create a website in IIS and point it to the application pool you created.
To deploy the application to Kestrel, follow these steps:

Publish the application to a folder on your web server.
Run the following command from the command prompt:
dotnet run
This will start the Kestrel web server and host the application.
