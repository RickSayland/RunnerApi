# RunnerApi
Create a simple .NET API demo for job assessment

# Steps to create this demo
1. Setup a new solution and Add some projecsts to it - service, apiclient, tests, domain
2. Add sample CRUD controller for runners and activities
3. Add SQLite db to store runners via EF Core
4. Add swagger for easy demo/documentation
5. Add unit tests
6. Add Authentication
7. Add logging

# Demo Details
RunnersController - CRUD controller for adding or updating Runners

ActivitiesController - CRUD controller for adding or updating Activities

SQLite - lightweight shim for a full SQL db

Tests - some simple tests around the controller with mocking of the repo layer

Domain layer - place where db etities exist and can be referenced by other projects

Authentication - auth controller to generate tokens. API client has method to authenticate and set them internally

Logging - simple console logging, could be hooked up to elastic or data dog or something

# Running

Build and run the app

Navigate to http://localhost:5000/index.html

Authenticate with athentication controller (for the demo the credentials are admin, password)

add token to swagger login, then endpoints can be used


