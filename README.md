This is solution for easy start develop website use Angular and Web API service with OAuth Authentication.

<a href="http://http://angularwebapitemplate.azurewebsites.net">http://angularwebapitemplate.azurewebsites.net</a>

This solution devlopment for ASP.Net framework and there is the same project for framework ASP.Net Core 2.0, you can download it <a href="https://github.com/11BREATH11/ASP.NET_Core_Web.API_Example">here</a>,

For authentication uses OAuth Bearer Token and implements Refresh Tokens. 
The backend API is built using ASP.NET Web API, OWIN middleware, ASP.NET Identity and Entity Framework.

Solution devided on 4 projects:

- Ordes - main project, uses Angular with WebPack and ASP.Net
- API - REST Service, uses ASP.NET Web API
- DAL - Data Access Layer, uses Entity Framework.
- BLL - Business Logic Layer

All project uses Dependency injection, uses Autofac.

After download and open need refresh node modules in project Orders. For easy uses WebPack install <a href="https://marketplace.visualstudio.com/items?itemName=MadsKristensen.WebPackTaskRunner">Web Pack Task Runner</a>. 

For run front-end unit-tests uses Karma, Jasmine and Gulp.

For Database point you connection string in project API in file web.config. After first run application, database will be create automaticaly.

For authorizarion via social networks need point your tokens for google and facebook in project Api, but you can use mine, if its still will be work.
