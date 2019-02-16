# NTU Events

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org) [![Code of Conduct](https://img.shields.io/badge/code%20of-conduct-ff69b4.svg)](https://github.com/JiaweiTan/NTU-Events-Website/blob/master/CONTRIBUTING.md#code-of-conduct) [![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![All Contributors](https://img.shields.io/badge/all_contributors-34-orange.svg?style=flat-square)](2)

### Team



**The Problem**

If a student wishes to find out about a CCA's upcoming events, he has to visit the [official CCA directory page](https://www.ntu.edu.sg/CampusLife/Clubs/pages/clubssocieties.aspx) first, before entering the CCA's website. This is a time-consuming process which severely limits student awareness and participation.

![alt text](https://github.com/JiaweiTan/NTU-Events-Website/blob/master/NTUCCas.PNG)

**Solution**

By aggregating all CCA events in one site, NTUEvents serves as a convenient platform for students to get the latest updates on upcoming activities. In turn, CCAs can reach a wider student audience.

**Technical Information**

Programming languages used:
* Javascript
* HTML
* CSS
* C#
* SQL

The architecture of our web application follows the Model-View-Controller (MVC) pattern. The controllers can perform create, read, update and delete (CRUD) operations.

To display the views, we use Vue.Js as our front-end framework.

To set up the models, we use Entity Framework Core as our object-relational mapper (O/RM), with MySQL as our relational database management system (RDBMS).

To set up the controllers, we use .NET Core's Web API framework.

### Getting Started

#### Vue UI

In VS Code terminal (cmd), enter:

```
vue ui
```

#### EF Core Migrations

You can enter the following commands in MS VS Package Manager Console:

##### Create Migration

```
EntityFrameworkCore\Add-Migration "MigrationName" -Context DbContextName
```

##### Migrate to Database

```
EntityFrameworkCore\Update-Database -Context DbContextName
```

#### Informal Guide
* [Google Word Doc](https://docs.google.com/document/d/1Rx7LVWbtGpK3kIgX6n6lZ7uL7YDiT6FwqChjPSpi7AA/edit)

### Prerequisites

#### IDE
* [Microsoft Visual Studio](https://docs.microsoft.com/en-us/cpp/build/vscpp-step-0-installation?view=vs-2017)

#### Code Editor
* [Visual Studio Code](https://code.visualstudio.com/docs/setup/windows)

#### Package Management
* [Node.js](https://nodejs.org/en/download/)

#### Web Frameworks
* [Vue CLI 3](https://cli.vuejs.org/guide/installation.html)
* [ASP.NET Core 2.2 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.2) - Select SDK Windows .NET Core Installer x64

#### Database
* [MySQL Community Server](https://dev.mysql.com/downloads/mysql/) - Select Windows (x86, 64-bit), ZIP Archive

### Setup

Step 1: Install the software in "Prerequisites" section

Step 2: Read "Getting Started" section

Step 3: Clone repository

Step 4: Install/update relevant packages:
* Vue CLI 3 - Use Vue UI (plugins, dependencies sections)
* Microsoft Visual Studio - Use Nuget

Step 5:
* Vue CLI 3 - Select Tasks -> Serve
* Microsoft Visual Studio - Press F5

## Running the tests
Currently, we have not implemented any automated testing.

Don't worry, we will review all pull requests to make sure the app does not break!

## Deployment
After a successful pull request, we will manually deploy the updated code.

We aim to automate the deployment process.

## Built With

* [Vue.js](https://vuejs.org/) - Front end Javascript framework
* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2) - Web application framework
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Object-relational mapper (O/RM)
* [MySQL](https://www.mysql.com/) - Relational database management system (RDBMS)
* [Azure](https://azure.microsoft.com/) - Cloud hosting

## Contributing

Please read [CONTRIBUTING.md](https://github.com/JiaweiTan/NTU-Events-Website/blob/master/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [GitHub](https://github.com/) for versioning. For the versions available, see the [tags on this repository](https://github.com/JiaweiTan/NTU-Events-Website/tags).

## To-Do
* Add user login functionality, with JWT tokens
* Add automated testing
* Automate deployment process, with continuous integration

## Authors
* [Tan Jia Wei](https://github.com/JiaweiTan/)
* [Lee Wei Min](https://github.com/leeweiminsg/)

## License
[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

[MIT](https://github.com/JiaweiTan/NTU-Events-Website/blob/master/LICENSE)
