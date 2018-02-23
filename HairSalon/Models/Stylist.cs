using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _firstName;
    private string _lastName;
    private int _id;
    private string _specialty;

    public Stylist(string firstName, string lastName, string specialty, int Id = 0)
    {
      _firstName = firstName;
      _lastName = lastName;
      _specialty = specialty;
      _id = Id;
    }

    public string GetFirstName() {return _firstName;}

    public string GetLastName() {return _lastName;}

    public int GetId() {return _id;}

    public string GetSpecialty() {return _specialty;}

    public static List<Stylist> GetAllStylists()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string stylistFirstName = rdr.GetString(0);
        string stylistLastName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        string stylistSpecialty = rdr.GetString(3);
        Stylist newStylist = new Stylist(stylistFirstName, stylistLastName, stylistSpecialty, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO `stylists` (`first_name`, `last_name`, `specialty`) VALUES (@FirstName, @LastName, @Specialty);";

        MySqlParameter firstName = new MySqlParameter();
        firstName.ParameterName = "@FirstName";
        firstName.Value = this._firstName;

        MySqlParameter lastName = new MySqlParameter();
        lastName.ParameterName = "@LastName";
        lastName.Value = this._lastName;

        MySqlParameter specialty = new MySqlParameter();
        specialty.ParameterName = "@Specialty";
        specialty.Value = this._specialty;

        cmd.Parameters.Add(firstName);
        cmd.Parameters.Add(lastName);
        cmd.Parameters.Add(specialty);

        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylists;";

        cmd.ExecuteNonQuery();

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public override bool Equals(System.Object otherStylist)
    {
        if (!(otherStylist is Stylist))
        {
            return false;
        }
        else
        {
            Stylist newStylist = (Stylist) otherStylist;
            bool idEquality = (this.GetId() == newStylist.GetId());
            bool firstNameEquality = (this.GetFirstName() == newStylist.GetFirstName());
            bool lastNameEquality = (this.GetLastName() == newStylist.GetLastName());
            bool specialtyEquality = (this.GetSpecialty() == newStylist.GetSpecialty());

            return (idEquality && firstNameEquality && lastNameEquality && specialtyEquality);
        }
    }

    public List<Client> GetClients()
    {
        List<Client> allMyClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM `clients` WHERE `stylist_id` = @StylistId;";

        MySqlParameter stylistId = new MySqlParameter();
        stylistId.ParameterName = "@StylistId";
        stylistId.Value = this._id;
        cmd.Parameters.Add(stylistId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            string clientFirstName = rdr.GetString(1);
            string clientLastName = rdr.GetString(2);
            string clientPhone = rdr.GetString(3);
            int clientId = rdr.GetInt32(0);
            int clientStylistId = rdr.GetInt32(4);
            Client newClient = new Client(clientFirstName, clientLastName, clientPhone, clientId, clientStylistId);
            allMyClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allMyClients;
    }

    public static Stylist Find(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * from `stylists` WHERE id = @thisId;";

        MySqlParameter thisId = new MySqlParameter();
        thisId.ParameterName = "@thisId";
        thisId.Value = id;
        cmd.Parameters.Add(thisId);
        
        string stylistFirstName = "";
        string stylistLastName = "";
        int stylistId = 0;
        string stylistSpecialty = "";

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while (rdr.Read())
        {
            stylistFirstName = rdr.GetString(0);
            stylistLastName = rdr.GetString(1);
            stylistId = rdr.GetInt32(2);
            stylistSpecialty = rdr.GetString(3);
        }

        Stylist foundStylist = new Stylist(stylistFirstName, stylistLastName, stylistSpecialty, stylistId);

        conn.Close();
        if (conn != null)
        {
        conn.Dispose();
        }

        return foundStylist;
    }
  }
}
