# musical-adventureAPI
Music API Back end in .Net Core
[![Deploy ASP.NET Core app to Azure Web App](https://github.com/Hello-Learn/musical-adventureAPI/actions/workflows/dotnet.yml/badge.svg?branch=release)](https://github.com/Hello-Learn/musical-adventureAPI/actions/workflows/dotnet.yml)
To start up project
Add the following to your application settings file

"ConnectionStrings": {  
    "ConnStr": "Data Source=.;Initial Catalog=MusicAdventureDB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"  
  },
  For Database connection
  
 "JWT": {  
    "ValidAudience": "http://localhost:4200",  
    "ValidIssuer": "http://localhost:59921",  
    "Secret": "StrONGKAutHENTICATIONKEy"  
  } 
 JWT Authentication
 
 The update the database
