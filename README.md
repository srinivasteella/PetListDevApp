
# PetList Dev App
 ![GitHub release](https://img.shields.io/github/release/srinivasteella/Angular7-NetCoreAPI.svg?style=for-the-badge) ![Maintenance](https://img.shields.io/maintenance/yes/2020.svg?style=for-the-badge)


#### PetList Dev Application - PetListApp Frontend in Angular8 and Backend in .Net Core3.1

---------------------------------------


## Repository code base

The repository consists of projects as below:


| # |Project Name | Project detail | Environment |
| ---| ---  | ---           | ---          |
| 1 | AGLDevTestAPI | Asp.Net Core3.1 WebApi as backend | [![.Net Framework](https://img.shields.io/badge/DotNet-3.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/3.1)|
| 2 | AGLDevTestAPI.Test | Unit Test for webapi | [![.Net Framework](https://img.shields.io/badge/DotNet-3.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/3.1)| 
| 3 | AGLDevTestClient | Angular app as frontend | [![Angular](https://img.shields.io/badge/Angular-8-blue?style=plastic)](https://nodejs.org/en/download/)| 


### Summary

The overall objective of the applications is to make an API that access third party API to fetch the list of pets, filter by pet type and group by owner gender
```
>	Get Pet Types
>	Get List of Pets by Owner Gender
>	Unit test
```

### Setup detail

##### Environment Setup detail

> Download/install   	

>   1. [![VS2019](https://img.shields.io/badge/VS-2019-blue.svg)](https://git-scm.com/downloads) 
>	2. [![.Net Framework](https://img.shields.io/badge/.Net%20Core-3.1-blue.svg)](https://www.microsoft.com/net/download/dotnet-core/3.1) to run webapi project
>	3.  [![.Net Framework](https://img.shields.io/badge/Node-Js-blue.svg)](https://www.microsoft.com/net/download/dotnet-core/3.1) to run angular application project
>
| # |Package | Recommended Version
| ---| ---  | ---           
| 1 | .Net Core | 3.1 
| 2| VS | 2019
| 3| Node | V12
| 4 | Angular | 7 or above
##### Project Setup detail

>   1. Please clone or download the repository from [![github](https://img.shields.io/badge/git-hub-blue.svg?style=plastic)](https://github.com/srinivasteella/PetListDevApp) 

>   
##### (a) To start the backend webapi service
   
>   1. Open solution in **Visual Studio 2019** 
>   2. Right click on the solution and select `Properties` or Select solution and press `ALT+Enter`
>   3. Goto Common Properties -> StartUp Project. Choose `Multiple startup projects`
>   4. Choose `Start` action for **AGLDevTestAPI** and **AGLDevTestClient** projects and apply -> ok
>   5. Press F5 to run the APP

##### API { Swagger Page }
==========================================================================
![Home](https://github.com/srinivasteella/PetListDevApp/blob/master/Swagger.PNG ".Net Core API")



##### Client 
=========================================================================

![Client](https://github.com/srinivasteella/PetListDevApp/blob/master/Client.PNG "Angular")

##### (c) To run the unit test project
>   1. Open solution in **Visual Studio 2019**
>   
>   2. Select Test Project -> Run Tests
