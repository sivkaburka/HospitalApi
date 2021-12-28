# HospitalApi
RESTful API built with ASP.NET 5 for editing patient and doctor tables.
# Description of the task:
Write 2 web api controllers for editing patient and doctor tables.

The controller must support operations:
* Adding a record
* Edit recording
* Deleting an entry
* Getting a list of records for a list form with support for sorting and pagination of data
* Getting a record by id for editing

External links in the form of a list must be replaced with the value by reference (i.e. not a link to the cabinet, but the cabinet number), in the edit form they must be links.

It is necessary to use MS SQL as a base.

Tables in the database:
* Areas
  * Number
* Specializations
  * Name
* Cabinets
  * Number
* Patients
  * First Name
  * Patronymic
  * Last Name
  * Address
  * Date of Birth
  * Gender
  * Area(link)
* Doctors
  * First Name
  * Patronymic
  * Last Name
  * Cabinet (link)
  * Specialization (link)
  * Area (for area doctors, link)
# Run API
For running API DON'T FORGET change Data Base connection string in appsettings.json

After running API, you can check all requests in Swagger.
# Request parametrs
For pagination use property "Page" and "ItemsPerPage".
For sorting avaible all fields. Use property "OrderBy" with values, example "LastName" or "AreaNumber", and sort type, "asc' as default, and "desc" for reverse sorting. 

Example:
```
https://localhost:44316/api/Doctors?Page=2&ItemsPerPage=3&OrderBy=lastname%20desc
```
