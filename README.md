Sandwich Order System
=====

General Description
-----

Sandwich Order System is a console program written in C# using Visual Studio Community Edition 2015.  It allows the user to order sandwiches according to the following requirements:

* An order may consist of either a Signature Sandwich or a Custom Sandwich

* A Custom Sandwich must have one Bread and one Filling
* Optional extras for a Custom Sandwich include Cheese, Vegetables, and Condiments
  - If selected, only one Cheese is allowed
  - If selected, unlimited Vegetables and Condiments are allowed

* Optional extras for each order include a Drink and Chips
  - If selected, only one Drink is allowed
  - If selected, only one Chips is allowed
  - If both are selected, a ComboMeal discount is applied

* A list of several options for each type of item is presented

The system allows the user to create as many orders as desired.

User functions available to the user are:

* Add order, which starts the item selection flow
* Show all orders, the prices of all items, and the total price
* Delete all orders
* Finish and checkout
* Quit and exit the system

During the order creation process, the user may:

* Delete the current order
* Review the current order before finalizing it

Upon choosing to finish ordering, the user is prompted to review all of his orders, each item price, and the total price.  He may then choose to pay and checkout, after which his order is sent to fulfillment, and the orders list is reset for the next user.

Program Entry Point
-----
```
sandwich-order-system\src\SandwichOrderSystem\SandwichOrderSystem\Program.cs
```

Third Party Library Framework and Database Dependencies
-----

* **Castle Windsor** : dependency injection
* **Entity** : object relational mapping
* **Moq** : for unit test mocking
* **SQL Server LocalDB** : database

Note that SQL Server LocalDB is provided by default in Visual Studio Community Edition 2015.  The default local database should be named **(localdb)\MSSQLLocalDB**.

#### Database Seed Data

Seed data for the items is provided in:
```
sandwich-order-system\src\SandwichOrderSystem\SandwichOrderSystemShared\Data
```
Upon first-time startup, database initialization may cause a lag of roughly 10 seconds.  A welcoming message is displayed during this initialization period.  After the first-time startup, system initialization is less than a second.

To change the seed data:

1. Edit the contents of item seed files in the Data directory.  The format is the name and price separated by a comma, one item per line.

2. In Visual Studio's SQL Server Object Explorer, delete the database named SandwichOrderSystem within (localdb)\MSSQLLocalDB.

3. Clean and Rebuild the project.

Visual Studio Solution Projects
-----

The entire solution is currently separated into 4 projects:

1.  **SandwichOrderSystem**
* DI
*  Models
* Services
* ViewControllers
* ViewModels
* Views
2.  **SandwichOrderSystemShared**
* DI
* Data
* DataAccess
* Models
* Services
3. **SandwichOrderSystemTests**
* Unit Tests for SandwichOrderSystem project
4.  **SandwichOrderSystemSharedTests**
* Unit Tests for SandwichOrderSystemShared project

The **SandwichOrderSystem** is the core console app project, and its classes are concerned with the console-driven UI/UX.

The **SandwichOrderSystemShared** project is a Class Library (dll).  It was separated out because these interfaces form a shared resource which can be used in other presentations, for example, a web-based UI/UX front-end using ASP.Net.

High-Level Design Notes
-----

Several design patterns were used, including:

* **Adaptor** to wrap System IO and Database resources
* **Dependency Injection** for inversion of control
* **Factory** for object creation
* **MVVM** to separate concerns
* **State** to efficiently organize the many view states, contexts, and segues in the UI/UX
* **Repository** to handle database interaction


