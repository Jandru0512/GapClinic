<h1 align="center">⚛ GAP Clinic ⚛ </h1>
GAP Clinic is an application to manage patients and clinical appointments.

## Requirements
* VisualStudio 2017
* .NET Core 2.1
* NodeJs 10.15.3
* SqlServer

## Clone application

```
git clone https://github.com/jandru0512/GapClinic.git
```
## Install dependencies
* Go to user-interface project and then

```
yarn
```
or
```
npm install
```

## Configure the connection string
* Change the connection string in the appsettings.json file in Gap.Clinic.Apis

```
"ConnectionStrings": {
  "ClinicConnection": "server=DESKTOP-3DMJ80L\\SQLEXPRESS; Integrated Security=false; User ID=sa; Password=123456789; Initial Catalog=dbClinic; MultipleActiveResultSets=False;"
}
```

## Start the services
* Run the Gap.Clinic.Apis project

## Start the application
* Go to user-interface

```
yarn start
```
or
```
npm start
```
## Annotations
* .Net Core
* React
* Rematch
* AntDesign
* Responsive design
* Entity Framework Core Code first 
* Entity Framework Core Migrations (Migrations in Gap.Clinic.Persistence)
* Dependency injection
* Onnion architecture
* Sql Server

## License
MIT
