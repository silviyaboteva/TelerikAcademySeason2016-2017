Homework

Answer following questions in Markdown format (.md file)

1. What database models do you know?
 - Hierarchical database model
 - Network model
 - Relational model
 - Entity–relationship model
 - Enhanced entity–relationship model
 - Object model
 - Document model
 - Entity–attribute–value model
 - Star schema

2. Which are the main functions performed by a Relational Database Management System (RDBMS)?
 There are several functions that a DBMS performs to ensure data integrity and consistency of data in the database. The ten functions in the DBMS are: 
 - data dictionary management
 - data storage management
 - data transformation and presentation
 - security management
 - multiuser access control
 - backup and recovery management
 - data integrity management
 - database access languages and application programming interfaces
 - database communication interfaces
 - transaction management.

3. Define what is "table" in database terms.
    A table is a collection of related data held in a structured format within a database. It consists of columns, and rows.
In relational databases and flat file databases, a table is a set of data elements (values) using a model of vertical columns (identifiable by name) and horizontal rows, the cell being the unit where a row and column intersect. A table has a specified number of columns, but can have any number of rows. Each row is identified by one or more values appearing in a particular column subset. The columns subset which uniquely identifies a row is called the primary key.

4. Explain the difference between a primary and a foreign key.
    A primary key and foreign key constraints both are similar and it provide unique enforce uniqueness of the column on which they are defined.

    Primary Key

     - Primary key cannot have a NULL value.
     - Each table can have only one primary key.
     - By default, Primary key is clustered index and data in the database table is physically organized in the sequence of clustered index.
     - Primary key can be related with another table's as a Foreign Key.
     - We can generated ID automatically with the help of Auto Increment field. Primary key supports Auto Increment value.

    Foreign Key

     - Foreign key is a field in the table that is primary key in another table.
     - Foreign key can accept multiple null value.
     - Foreign key do not automatically create an index, clustered or non-clustered. You can manually create an index on foreign key.
     - We can have more than one foreign key in a table.
     - There are actual advantages to having a foreign key be supported with a clustered index, but you get only one per table. What's the advantage? If you are selecting the parent plus all child records, you want the child records next to each other. This is easy to accomplish using a clustered index.
     - Having a null foreign key is usually a bad idea. In the example below, the record in [dbo].[child] is what would be referred to as an "orphan record". Think long and hard before doing this.

5. Explain the different kinds of relationships between tables in relational databases.
    There are three types of relationships between tables. The type of relationship that is created depends on how the related columns are defined.
     - One-to-Many Relationship
     - Many-to-Many Relationships
     - One-to-One Relationships

    One-to-Many Relationships
        A one-to-many relationship is the most common type of relationship. In this type of relationship, a row in table A can have many matching rows in table B, but a row in table B can have only one matching row in table A. For example, the publishers and titles tables have a one-to-many relationship: each publisher produces many titles, but each title comes from only one publisher.
        Make a one-to-many relationship if only one of the related columns is a primary key or has a unique constraint.
        The primary key side of a one-to-many relationship is denoted by a key symbol. The foreign key side of a relationship is denoted by an infinity symbol.
    
    Many-to-Many Relationships
        In a many-to-many relationship, a row in table A can have many matching rows in table B, and vice versa. You create such a relationship by defining a third table, called a junction table, whose primary key consists of the foreign keys from both table A and table B. For example, the authors table and the titles table have a many-to-many relationship that is defined by a one-to-many relationship from each of these tables to the titleauthors table. The primary key of the titleauthors table is the combination of the au_id column (the authors table's primary key) and the title_id column (the titles table's primary key).
    
    One-to-One Relationships
        In a one-to-one relationship, a row in table A can have no more than one matching row in table B, and vice versa. A one-to-one relationship is created if both of the related columns are primary keys or have unique constraints.
        This type of relationship is not common because most information related in this way would be all in one table. You might use a one-to-one relationship to:
        Divide a table with many columns.
        Isolate part of a table for security reasons.
        Store data that is short-lived and could be easily deleted by simply deleting the table.
        Store information that applies only to a subset of the main table.
        The primary key side of a one-to-one relationship is denoted by a key symbol. The foreign key side is also denoted by a key symbol.

6. When is a certain database schema normalized?
    Database normalization is the process of organizing the attributes and tables of a relational database to minimize data redundancy. Normalization involves decomposing a table into less redundant (and smaller) tables but without losing information; defining foreign keys in the old table referencing the primary keys of the new ones. The objective is to isolate data so that additions, deletions, and modifications of an attribute can be made in just one table and then propagated through the rest of the database using the defined foreign keys.

7. What are the advantages of normalized databases?
    - Smaller database: By eliminating duplicate data, you will be able to reduce the overall size of the database.
    - Better performance: Fewer indexes per table mean faster maintenance tasks such as index rebuilds. Only join tables that you need.
    - Narrow tables: Having more fine-tuned tables allows your tables to have less columns and allows you to fit more records per data page.

8. What are database integrity constraints and when are they used?
    Integrity constraints are used to ensure accuracy and consistency of data in a relational database. Data integrity is handled in a relational database through the concept of referential integrity. Many types of integrity constraints play a role in referential integrity (RI).
     - Primary Key Constraints
     - Unique Constraints
     - Foreign Key Constraints
     - NOT NULL Constraints
     - Check Constraints
     - Dropping Constraints

9. Point out the pros and cons of using indexes in a database.
    Advantages:
     - Faster lookup for results. This is all about reducing the # of Disk IO's. Instead of scanning the entire table for the results, you can reduce the number of disk IO's(page fetches) by using index structures such as B-Trees or Hash Indexes to get to your data faster.

    Disadvantages:
     - Slower writes(potentially). Not only do you have to write your data to your tables, but you also have to write to your indexes. This may cause the system to restructure the index structure(Hash Index, B-Tree etc), which can be very computationally expensive.
     - Takes up more disk space, naturally. You are storing more data.

10. What's the main purpose of the SQL language?
     - SQL allows users to access data stored in a relational database management system. Users can create and delete databases, as well as set permissions on database tables, views and procedures. It also allows users to manipulate the data within a database.
     - In SQL, there are two main sets of commands that are used to create and modify databases. These are the Data Definition Language and the Data Manipulation Language. The former contains commands used to develop and delete databases and its objects, and the latter contains commands used to insert, modify and delete data stored in a database.

11. What are transactions used for?
    A transaction is a set of changes that must all be made together. Transaction is executed as a single unit. If the database was in consistent state before a transaction, then after execution of the transaction also, the database must be in a consistate.

12. Give an example.
    For example, a transfer of money from one bank account to another requires two changes to the database both must succeed or fail together.

13. What is a NoSQL database?
    A NoSQL database provides a mechanism for storage and retrieval of data that is modeled in means other than the tabular relations used in relational databases. Motivations for this approach include simplicity of design, horizontal scaling, and finer control over availability. The data structures used by NoSQL databases (e.g. key-value, graph, or document) differ from those used in relational databases, making some operations faster in NoSQL and others faster in relational databases.

14. Explain the classical non-relational data models.
    The non-relational data model would look more like a sheet of paper. In fact, the concept of one entity and all the data that pertains to that one entity is known in Mongo as a “document”, so truly this is a decent way to think about it. You just add things whenever you need them. Your software doesn’t need to know ahead of time, you don’t need to know ahead of time. It all just kind of works, provided you know what you’re doing on the software level.

15. Give few examples of NoSQL databases and their pros and cons.
 - MongoDB. Open-source document database.
 - CouchDB. Database that uses JSON for documents, JavaScript for MapReduce queries, and regular HTTP for an API.
 - Redis. Data structure server wherein keys can contain strings, hashes, lists, sets, and sorted sets.
 - Cassandra. Database that provides scalability and high availability without compromising performance. memcached. Open source high-performance, distributed-memory, and object-caching system.
