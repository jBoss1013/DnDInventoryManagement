# DnDInventoryManagement
*(Check below for instructions on how to get it started)*

A DnD 5e supplementary for inventory management. This project started out as a series of smaller projects that is on its way to becoming a minimum viable project. it's current features include: Registering a user, logging in, and viewing items on the Item List Tab. 

This utilizes database, API, and WPF layers for data seperation.  

Future Plans include:
- creating and deleting items in the Item List Tab
- Having a charactery inventory where items can be removed and added
- Multiple characters with individualized inventories

**How to get it working**

*Startup both WPF and API*
- right click on solution and click properties. Under Common Properties/Start up Project -> selecct mulitple start up.
- select both the DnDIMDataManager(API) and DnDIMDesktopUI(WPF) as start up projects.

*Configure Database*
- publish database (publish data is under Publish Locations in the DnDIMData project)
- it may be nessecary to create a new publish profile and erease the old one. Should you need to do this, ensure that the database connection string ("DnDIMData") in the API web.congfig is corrected if needed. 
- to see items in the Item List WPF tab it will require manual entry of items into database.

*Configure WPF*
- Set Localhost path in App Settings.
- To do this: right click on DnDIMDataManager(API) and select properties. Go to the Web tab and find the Project URL. Copy this localhost and paste in the WPF App.config under AppSettings -> value = "". (should look like: value="http://localhost:#####/")
- It may be nessecary to run the API once and register a dummy user under the api ACCOUNT/Register for the aspnet local database to be created. 

Once these changes are made, you should be able to create a new user with the UI and login to the form. 



