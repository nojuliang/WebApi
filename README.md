# WebApi

PURPOSE
----------
Implement an API in C# which will manage Customers and Orders. No user interface is required, only an
API to create, update and delete Customers and manage Orders. Customer entity should contain: name
(first and last), address, postal code. Each Order should contain one or more Items, order date and total
price. Item should contain Product and quantity of product and Product should contain name and price.
▪ For persistence entity framework should be used and repository pattern.
▪ Also, unit of work pattern is required to be implemented.
▪ In addition to creating/editing/deleting it is required also to support iterating over the customer
orders by order date.
▪ Implement focusing on domain logic using Domain Driven Design.
▪ Segregate commands and queries using CQRS.
▪ Having unit tests in your project is a plus (preferably with NUnit)
▪ XML documentation of the API is welcome, too
NOTE: A short list of the assumptions that you made when designing/implementing the API would be
great.



ASSUMPTIONS
------------------
- Customer/Order Relationships: Each customer can have multiple orders, but an order can only belong to one customer.
- Item/Order Relationship: Each order can contain multiple items. Each item is linked to a product with a name and price.
- CQRS: Commands will handle mutations (create, update, delete), and queries will handle retrieval operations.
- Domain Logic: Important business rules like order totals will be calculated within the domain model.
- Persistence: Entity Framework Core will be used with a SQL Server database for persistence.
- Unit of Work: Manages changes made to repositories to ensure atomic transactions.

