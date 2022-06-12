
# _ParkLookup API_

#### By _**Jeremy Martin**_

#### _An API that allows the user to view parks in the database, add parks to the database, and edit existing parks in the database._

## Technologies Used

* C#
* MySQL
* MySQL Workbench
* Entity
* .NET 5.0
* SwaggerUI
* OpenAPI
* Jwt Authentication

## Description

This API allows the user to make get requests returning either all parks, get based on ID, or get based on search parameters (such as location or jurisdiction). The user can also make posts new parks to the database, as well as edit and delete existing parks in the database. The user must be signed in to preform any action.

## Setup/Installation Requirements

### Getting Started

* Clone repo from GitHub using this link (https://github.com/JeremyM45/ParkLookupApi)

* Navigate to the ParkLookupAPI.Solution folder in terminal
```
(Users/Username/Desktop/ParkLookupAPI.Solution )
```
* cd into the ParkLookupAPI folder
```
cd ParkLookupAPI
```
* Add an appsettings.json file in the ParkLookupAPI folder

* In the appsettings.json file add these lines of code with your MySQL password were [Your Password Here] is and a string of random characters where [Your Secret Here] is. I'd recommend using [This Site](https://www.browserling.com/tools/random-string) and setting the length to 32 to generate a random string.

```
{

"Logging": {
	"LogLevel": {
		"Default": "Warning",
		"System": "Information",
		"Microsoft": "Information"
	}
},
"AllowedHosts": "*",
"ConnectionStrings": {
	"DefaultConnection": "Server=localhost;Port=3306;database=park_lookup;uid=root;pwd=[Your Password Here];"
	},
"JwtConfig": {
	"Secret": "[Your Secret Here]"
	}
}
```

### Setting up database
* If you do not have Entity installed on your computer run this line in your terminal at the root directory
```
dotnet tool install --global dotnet-ef --version 5.0.1
```
* Then run these two lines in your terminal at the project folder level (../ParkLookupAPI.Solution/ParkLookupAPI)
```
dotnet ef migrations add Initial
dotnet ef database update
```
* Now the database should show up in your MySQL schemas

### Restore and Run

* Type dotnet retore in terminal while in the PierresTreats folder
```
dotnet restore
```
* Then type dotnet run in the terminal while still in the PierresTreats folder
```
dotnet run
```
## Using The API
The default url is http://localhost5000, so before all end points there should be http://localhost5000. An example of a GET request would be http://localhost5000/api/Parks.
### Register and Login
All register/login calls will be POSTs.
|Action| End Point|
|:---------|:-------|
|Register|api/AuthManagement/Register|
|Login| api/AuthManagement/Login|
To Register you must provide a username, an email address, and a password
This is what a proper registration call looks like with the expected output
![Example in Postman of a proper registration request](https://i.gyazo.com/973c4bdbece113c678fc70383821cef4.png)

To Login you only need the email and password
This is what a proper login call looks like with the expected output
![Example in Postman of a proper login request](https://i.gyazo.com/85f4f284fe85265bf7b041b54147539c.png)
To be able to make any of the Park related requests to the API you must be logged in. For authentication this API uses Jwt Authentication. To be authenticated in Postman you need to copy the long string after "token": in the output body, click on Headers at the top, add a new line by clicking on the bottom most line and type "Authorization" in the key field and in the value field put "Bearer" and then the token you copied.

Your Postman Header group should look something like this after adding the Authorization line (NOTE: if you don't see the lines above the Authorization line that you added it's probably because they are set to be hidden by default)
(2nd NOTE: the token string is too long to show the entire thing in this view, so when you are adding it in the value field it may look different until you click out of the value field)
![enter image description here](https://i.gyazo.com/aaed97aa79bd78e63a5da7e95f6d55c9.png)
### Accessing Parks
|Request| End Point|
|:---------|:-------|
|GET|api/Parks|
|POST| api/Parks|
|GET {id}| api/Parks/{id}|
|PUT| api/Parks/{id}
|DELTE| api/Parks/{id}|
{id} is a stand in for the actual id of the park, so to get park by with the id of 2 the request would look like _api/Parks/2_
When making a POST call do not include a parkId in the body, the id will be automatically generated. However, when making a PUT call you must include the parkId in the body.

This is what a proper POST call looks like in Postman

![Example In Postman of proper POST call](https://i.gyazo.com/9d6e005917aa6648563f534143ddad75.png)

This is what a proper PUT call looks like in Postman

![Example In Postman of proper PUT call](https://i.gyazo.com/040b1aa1b10f92e10e0c74676caaa262.png)

## Known Bugs

*  _No Known Bugs_

## License

[MIT](https://opensource.org/licenses/MIT)

Copyright (c) _2022_  _Jeremy Martin_