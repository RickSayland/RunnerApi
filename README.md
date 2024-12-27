# RunnerApi
Create a simple .NET API demo for job assessment

# Steps to create this demo
1. Setup a new solution and Add some projecsts to it - service, apiclient, tests, domain
2. Add sample CRUD controller for runners and activities
3. Add SQLite db to store runners via EF Core
4. Add swagger for easy demo/documentation
5. Add unit tests

# Demo Details
RunnersController - CRUD controller for adding or updating Runners
ActivitiesController - CRUD controller for adding or updating Activities

SQLite - lightweight shim for a full SQL db

Tests - some simple tests around the controller with mocking of the repo layer

Domain layer - place where db etities exist and can be referenced by other projects


