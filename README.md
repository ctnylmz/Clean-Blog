
Certainly! I'll help you improve the clarity and organization of your README.md file. Here's a revised version:

Clean-Blog ASP.NET Core 6 Project
Clean-Blog is an ASP.NET Core 6 project that provides a clean and simple blog template. Follow the steps below to set up and run the project.

Installation Steps
Download Project:

Clone or download the project from Clean-Blog GitHub repository.
Open Project:

Navigate to the project folder and open it in your preferred code editor.
Database Configuration:

Make MSSQL database connection adjustments in the appsettings.json file.
Run Migrations:

Open Package Manager Console and run the following commands:
bash
Copy code
add-migration StartCleanBlogDB
update-database
Configure Program.cs:

Uncomment the necessary code lines in the Program.cs file.
Run Project:

Start the project and navigate to https://localhost:7220/ in your browser.
Access Admin Page:

Visit https://localhost:7220/admin to access the admin page.
Admin Credentials:

Use the following credentials to log in:
Email: admin@gmail.com
Password: Admin123!
Update Pages Settings:

Go to the Pages Settings and make any necessary edits.
Extra Information
Make sure to replace the placeholder images with your own images:

/assets/img/home-bg.jpg
/assets/img/about-bg.jpg
/assets/img/post-bg.jpg
/assets/img/contact-bg.jpg
