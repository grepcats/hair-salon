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

    public string GetFirstName()
    {
        return _firstName;
    }

    public string GetLastName()
    {
        return "cat";
    }
    //
    // public int GetId()
    // {
    //     return _id;
    // }
    //
    // public string GetSpecialty()
    // {
    //     return _specialty;
    // }

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

    // public override bool Equals(System.Object otherStylist)
    // {
    //     if (!(otherStylist) is Stylist)
    //     {
    //         return false;
    //     }
    //     else
    //     {
    //         Stylist newStylist = (Stylist) otherStylist;
    //         bool idEquality = (this.G)
    //     }
    // }
  }
}
