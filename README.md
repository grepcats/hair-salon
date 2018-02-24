## Specs

Program should show a list of stylists at the hair salon
Input: action to see stylists: GetAllStylists();
Output: list of stylists from stylist table: List<Stylist>. ex Carol Smith, Jane Doe, Bobby Fischer
GetAllStylists method should return a list of stylists from the database.

Program should be able to create new stylists when they're hired
Input: Form with relevant fields for stylist Input: Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair"). newStylist.Save();
Output: Stylist is added to the system. Compare list of Stylist objects with list of GetAllStylists.
Adding a new stylist to the system should add stylists to db in a predictable way.

Program should show stylist details
Input: action to request stylist details. GetFirstName(), GetLastName(), GetSpecialty()
Output: details for a particular stylist. Name: Carol Smith. Specialty: Curly Hair.
Each method should return the value of a particular field for the specified stylist.

Program should show a list of clients for a stylist.
Input: action to request list of clients for stylist. stylist.GetClients()
Output: list of clients. List<Client>. ex Carol: Joe Joeson, Tom Tomson.
Given a stylist id or as a stylist method, the program should be able to return a list of clients having that stylist id.

Program should be able to create new clients for a stylist
Input: Form with relevant fields for client input. Client newClient = newClient("Tom", "Tomson", "503-555-1234", 1(stylistId))
Output: Client is added to the system for that stylist. stylist.GetClients().Count
Given a stylist id or as a stylist method, the count of Clients returned from that stylist's GetClient() method should increase as expected.

---other features
Program should allow deletion of a single stylist (with the deletion of their clients)
Input: Delete(); on Carol
Output: Delete Carol and all of her Clients.

Program should allow deletion of a single client
Input: Delete(); on Tom
Output: Delete Tom from database. Stylist should be unaffected.






As a salon employee, I need to be able to see a list of all our stylists.
As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
As an employee, I need to add new stylists to our system when they are hired.
As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.
