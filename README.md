# BackendTasks
Solution contains;
 * a .netCore web API project to demonstrate CRUD operations as well as aggregate, index and transaction features agains MongoDB using C# driver.
 * console app which validates a given binary string against a certain logic.
 * project dependencies:
    * .netCore v3.1
    * Swashbuckle.AspNetCore v5.5.1
    * ServiceStack.Core v5.9.2
    * MongoDB.Driver v2.11.1
    * MongoDB.Bson v2.11.1
    * nunit v3.12.0
    * NUnit3TestAdapter v3.15.1
 * patterns:
    * unity of work - repository pattern
 * database:
    * mongoDb v4.4.0
 
 Setup MongoDB on your machine:
 1. Install MongoDB on your machine - https://www.mongodb.com/try/download/community
 2. Make sure you set replication. If you need to conver standalone to replication please see https://docs.mongodb.com/manual/tutorial/convert-standalone-to-replica-set/
 2.1. ** No CRUD operation will work if mongoDb runs on standalone as unity of work makes every saveChanges call in mongo context with a transaction.
 3. Change IP:port and database name from appSettings.json
 
 CRUD operations:
 1. Set BackendTask.API as start up project and run on local
 2. See swagger/index.html 
 3. In order to prepopulate documents, use /api/advisers/populate-db post API
 4. In order to grab ids in GUID to pass onto another API parameter, use /api/advisers get API
 5. Use both Adviser and Client APIs to get, put, post and delete data
 
 Transactions:
 Each call happens within a transction but in order to see multiple documents are being insterted see /api/advisers/populate-db post API
 
 Aggeration:
 See the following APIs
 /api/adviser/total-fees-and-charges
 /api/adviser/total-assets-under-management
 
 Index:
 1. Index is set to Adviser.UserDetails.Name 
 2. /api/advisers/by-name/{name} get API can be used. A bit dodgy (working with 'test', 'name')
  
 Binary Check:
 1. Set BackendTask.BinaryCheck as start up project and run on local
 2. Alternatively unit test project can be used - BackendTask.Business.Services.UnitTests
 
