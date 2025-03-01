# Job Listing Model in ASP.NET Core

## Overview
This project defines a `JobListing` model in ASP.NET Core, representing a job posting in a tech job portal.

## Features
- Defines a `JobListing` class with properties like `Title`, `CompanyName`, `Location`, `JobType`, and `PostedDate`.
- Uses `JobType` enum to categorize jobs as Full-Time, Part-Time, Remote, or Contract.
- Utilizes Data Annotations for validation and primary key definition.

## Model Properties
- **Id**: Primary key of the job listing.
- **Title**: Job title (Required).
- **CompanyName**: Name of the company offering the job (Required).
- **Location**: Location of the job (Optional).
- **JobType**: Enum defining the type of job (Required).
- **PostedDate**: Defaults to the current date when a job is created.

## How to Use
1. Add this model to the `Models` folder of your ASP.NET Core project.
2. Run migrations to apply changes to the database:
   ```sh
   dotnet ef migrations add AddJobListingModel
   dotnet ef database update
   ```
3. Use this model in your controllers and views to manage job listings.

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- C#

## Author
- **Abdullah Al-Juhani**
