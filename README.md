# MusicStoreApp

In the context of my bachelors degree, I was asked to develop a web application in Visual C# (ASP.NET Web Application) using the Model View Controller design architecture in the Visual Studio development environment. The application should implement the following functionality.

## Data management:
Record store data should be fully managed through the respective forms.
    1. The application should fully manage (insert, delete, edit) the data of all tables.
    2. Specifically for orders (invoices) to create stored procedures that will import, modify and delete orders. The orders are designed with the logic master – detail (invoice – invoiceLine). In stored procedures, use transactions to perform the above actions.
    3. You can optionally create stored procedures for all CRUD (Create, Read, Update, Delete) operations on a table using transactions.

## Create reports:
Beyond the administrative part, the following questions should be answered through the application by creating the corresponding reports:
    1. Retrieve the artists whose records are among the top X in sales for a specific time period. The user should define the following criteria for the creation of the report: Number X, Time interval Date From - To.
    2. Find the top 10 songs in customer preferences for a specific time period.
    3. Find out which genres of music are perennially first in customer preferences.
    4. Create a report showing the contact information of customers who have placed orders and their corresponding total turnover, sorted in descending order by turnover. The user should define the following criteria for the creation of the report: Time interval of orders Date From - To.
    5. Generate a report that will show the Id of the order (InvoiceID), the first and last name of the customer who placed the order, and the first and last name of the employee associated with the corresponding customer. Display those orders placed within a calendar interval. The user will be able to define the following criteria for the creation of the report: Time interval of orders Date From - To, Selection of customers from a list of customers of the electronic record store, Employee related to the order.
    6. Generate a report showing the sales of a record for any calendar year broken down by quarter of the year. The fields that will appear in the report are: Track Name, Artist, Record Track Order Year, First Quarter Sales, Second Quarter Sales, Third Quarter Sales, Fourth Quarter Sales. Sort results by track name and artist name. The user should define the following criteria for creating the report: Calendar year. Tip: To divide orders into quarters, use the datepart function.

