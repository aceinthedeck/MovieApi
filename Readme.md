## Movie API

Make sure that the migrations folder exist. If not run the command to create the migrations

```dotnet ef migrations add InitialCreate```

The migrations will be run automatically on application startup

Create a file ```.env``` in the root directory copy and update the values from ```.env.example``` file

To start the application give command from the root directory

```docker-compose up```

The application will start at http://localhost:5001

For local development you can use the ```docker-compose.dev.yml``` file. 
```docker-compose --f docker-compose.dev.yml up```
This will spin up only the database and will not run the API, allowing you to debug the application using visual studio.

While using Visual Studio the application will start at https://localhost:7271

