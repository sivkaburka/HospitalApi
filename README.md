# HospitalApi
RESTful API built with ASP.NET 5
After running API, u can check all requests in Swagger.
For sorting "Doctors" avaible property "OrderBy" with values "LastName" and "CabinetNumber", for "Patients" - "LastName" and "DateOfBirth". Sort type : method use asc as default, if u want desk, use property "OrderType" with value "desc". 

Description of the task:
Write 2 web api controllers for editing patient and doctor tables.
The controller must support operations:
-Adding a record
-Edit recording
-Deleting an entry
-Getting a list of records for a list form with support for sorting and pagination of data
-Getting a record by id for editing

External links in the form of a list must be replaced with the value by reference (i.e. not a link to the cabinet, but the cabinet number), in the edit form they must be links.

It is necessary to use MS SQL as a base.
Tables in the database:
Areas
- Number
Specializations
- Name
Cabinets
-Number
Patients
-First Name
-Patronymic
-Last Name
-Address
-Date of Birth
-Gender
-Area(link)
Doctors
-First Name
-Patronymic
-Last Name
-Cabinet (link)
-Specialization (link)
-Area (for area doctors, link)
