using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private int _id;
        private int _stylistId;

        public Client(string firstName, string lastName, string phoneNumber, int Id = 0, int stylistId = 0)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _id = Id;
            _stylistId = stylistId;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public string GetFirstName() {return _firstName;}

        public string GetLastName() {return _lastName;}

        public string GetPhoneNumber() {return _phoneNumber;}

        public int GetId() {return _id;}

        public int GetStylistId() {return _stylistId;}

        public void SetStylistId(int id)
        {
            _stylistId = id;
        }

        public static List<Client> GetAllClients()
        {
            List<Client> allClients = new List<Client>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              string clientFirstName = rdr.GetString(0);
              string clientLastName = rdr.GetString(1);
              string clientPhone = rdr.GetString(2);
              int clientId = rdr.GetInt32(3);
              int clientStylistId = rdr.GetInt32(4);
              Client newClient = new Client(clientFirstName, clientLastName, clientPhone, clientId, clientStylistId);
              allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
              conn.Dispose();
            }
            return allClients;
        }

        public void Save()
        {

        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = (this.GetId() == newClient.GetId());
                bool firstNameEquality = (this.GetFirstName() == newClient.GetFirstName());
                bool lastNameEquality = (this.GetLastName() == newClient.GetLastName());
                bool phoneEquality = (this.GetPhoneNumber() == newClient.GetPhoneNumber());
                bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());

                return (idEquality && firstNameEquality && lastNameEquality && phoneEquality && stylistIdEquality);
            }
        }



    }
}
