Softwares required to run BE Code are : 
Visual Studio
SQL Server
SSMS

## Installation
1. **Clone the Repository**
   cmd
   git clone https://github.com/Khushidawra/Demo-App-BE.git

   cd Demo-App-BE
   dotnet restore - To Restore Packages
   ## Create the database and tables (Queries in script folder)
   Run the first query in ssms then change the database to newly created database and then execute the second query.
   Now the Database is setup.

2.Setup the Code in VS Studio
Open the .sln file in first Demo-App-BE Folder.
Then, in View Tab Click on Solution Explorer. The Solution explorer will have all the files and folders.
Update the appSettings.json set ServerName to your SSMS ServerName and Database Name to Newly Created Database.

3.Run the Code
