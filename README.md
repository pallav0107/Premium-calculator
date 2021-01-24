# PremiumCalculator
Application calculates the premium based on the input provided for the user
# **Folders**

## Db_Scripts
- Script File: TableCreate_Script.sql contains Create script for the database and table creation to be created 

## API

Folder PremiumCalculator/[API] contains API solution built in DotNet Core 3.1
> Connection String:
-  PremiumCalculator/API/PremiumCalculator.API/**appsettings.json**
modify the section :- "ConnectionStrings": 
"**TALDatabase"**: "Server=**[YourServer Name here]**;Initial Catalog=TAL;Persist Security Info=False;User ID=**[Login UserID]**;Password=**[Password]**;MultipleActiveResultSets=False;Connection Timeout=30;"},
> Build and Run the Solution => Swagger documentation page is displayed

## WEB
Folder PremiumCalculator/UI/premium-calculator-web/ contains Angular UI code for the application built using Angular 9
> Build and run the code
- Follow steps inside ## PremiumCalculator/UI/premium-calculator-web/**README.md** 
to setup and run the Angular application code 

## Scope of enhancement/ TODO's:
- Logging is to be done through an independent logging platform for which the setup and process is configured in the BaseService.cs in API
- file based logging is currently implemented
- Unit testing framework is to be implemented in both Web and Api projects


## Key technologies used
- DotNet Core 3.1
- Angular 9
- Swashbuckle Swagger definition in API
- EF Core V3.1.4
- Repository pattern
