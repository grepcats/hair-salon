
# Hair Salon Manager

#### _An app to track a hair salon's stylists and their clients. 2/23/2018_

## Specs

* Program should show a list of stylists at the hair salon
    * Input: action to see stylists: GetAllStylists();
    * Output: list of stylists from stylist table: List<Stylist>. ex Carol Smith, Jane Doe, Bobby Fischer
    * GetAllStylists method should return a list of stylists from the database.

* Program should be able to create new stylists when they're hired
    * Input: Form with relevant fields for stylist Input: Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair"). newStylist.Save();
    * Output: Stylist is added to the system. Compare list of Stylist objects with list of GetAllStylists.
    * Adding a new stylist to the system should add stylists to db in a predictable way.

* Program should show stylist details
    * Input: action to request stylist details. GetFirstName(), GetLastName(), GetSpecialty()
    * Output: details for a particular stylist. Name: Carol Smith. Specialty: Curly Hair.
    * Each method should return the value of a particular field for the specified stylist.

* Program should show a list of clients for a stylist.
    * Input: action to request list of clients for stylist. stylist.GetClients()
    * Output: list of clients. List<Client>. ex Carol: Joe Joeson, Tom Tomson.
    * Given a stylist id or as a stylist method, the program should be able to return a list of clients having that stylist id.

* Program should be able to create new clients for a stylist
    * Input: Form with relevant fields for client input. Client newClient = newClient("Tom", "Tomson", "503-555-1234", 1(stylistId))
    * Output: Client is added to the system for that stylist. stylist.GetClients().Count
    * Given a stylist id or as a stylist method, the count of Clients returned from that stylist's GetClient() method should increase as expected.

* Program should allow deletion of a single stylist (with the deletion of their clients)
    * Input: Delete(); on Carol
    * Output: Delete Carol and all of her Clients.

* Program should allow deletion of a single client
    * Input: Delete(); on Tom
    * Output: Delete Tom from database. Stylist should be unaffected.

* Program should allow deletion of all stylists
    * Input: DeleteAll() and command to use this method on stylists. (Should this also delete their clients?)
    * Ouptut: Delete all stylists from Database.

* Program should let user view all existing Clients
    * Input: GetAll() method and command to perform method.
    * Output: List<Client> on a Clients index page.

* Program should allow deletion of all Clients
    * Input: DeleteAll() and command to use this method on clients.
    * Output: Delete all clients from Database.

* Program should let user view a single Client
    * Input: Find a client and click their name to view their details.
    * Output: Getter methods for that client

* Program should allow editing of stylist information
    * Input: Update/Edit method for Stylists (name)
    * Output: Set stylist name in Database.


* Program should allow editing of client information
    * Input: Update/Edit method for Clients (name, contact)
    * Output: Set Client info in Database

* Program should allow adding specialties
    * Input: Add specialties page. Specialties model, specialties table, join table.
    * Output: Add specialty.

* Program should allow viewing specialties
    * Input: Navigate to specialties index page.
    * Output: GetAllSpecialties should display a list of Specialties. List<Specialty>

        ////

* Program should allow adding a specialty to a stylist (many to many)
    * Input: from Stylist create or update page, add specialties.
    * Output: relationship is created in specialties_stylists table

* Program should allow user to click a specialty and see all stylists that have that specialty
    * Input: On Specialty index, click specialty
    * Output: Specialty Details page with List<Stylist>

* Program should allow users to see stylists specialties on their details page
    * Input: Click stylist details
    * Output: on Stylist details page, see list of specialties.

* Program should let user add a stylist to a specialty
    * Input: from Specialty details page, add stylist to specialty.
    * Output: relationship is created in specialties_stylists table.


## Set up and installation
* Install .NET Core 1.1 SDK (Software Development Kit) and .NET runtime
* Install MAMP. https://www.mamp.info/en/downloads/
* Modify preferences to use ports 8888 and 8889 for Apache & MySQL, respectively
* Log into MySQL:
```
$ C:\MAMP\bin\mysql\bin\mysql -uroot -proot -P8889
```
From your command line once you've logged into MySQL, create the database and tables via the following instructions.
```
CREATE DATABASE kayla_ondracek;
USE kayla_ondracek;
CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `first_name` varchar(255) DEFAULT NULL,
  `last_name` varchar(255) DEFAULT NULL,
  `phone_number` varchar(255) DEFAULT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
CREATE TABLE `stylists` (
  `first_name` varchar(255) DEFAULT NULL,
  `last_name` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `specialty` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);
ALTER TABLE `stylists`
ADD PRIMARY KEY (`id`);
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;COMMIT;
```

* Clone the app
```
git clone https://github.com/grepcats/hair-salon
```
* navigate to "HairSalon" folder one level down
* run "dotnet restore" in project folder to load dependencies
* run "dotnet build" to build project and its dependencies into a set of binaries
* run "dotnet run" to run the project
* Open web browser and navigate to http://localhost:5000. Program will run as long as it is running in the terminal.

## Known Bugs
No known bugs at this time. Please report any bugs by opening a GitHub issue.

## Support and Contact Details
If there are any issues or questions, please contact me at kayla.renee at gmail dot com or create an issue in GitHub.

## Technologies Used
C#/ASP.NET Core 1.1, Bootstrap, MAMP.

## License
MIT License

Copyright (c) 2018 Kayla Ondracek

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
