# SigmaSoftwareTask
**Technologies Used:** .NET8, xUnit.

# Ways for Improvement
- Use Docker containers or something similar to make sure everyone is running the app on the same environment.
- Add unit tests to the methods inside the candidate repository.
- Move the migrations to a separate project.
- Seed the Database with test data.
- Allow more than one time interval for each candidate.
- Handle different timezones.
- Cache the user Ids with the email as the key.

# Assumptions
- Only one time interval suitable for calls.
- Date will be posted to the API  in UTC.
- Start and end hours of the time interval will be posted to the API in 24 hrs system.

# Time Spent
- 6 hrs (Excluding the time spent on studying how to write test cases but including the time spent on studying how to get started with EF Core).
