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

    public static List<Stylist> GetAllStylists()
    {
      List<Stylist> noStylists = new List<Stylist> {};
      Stylist test = new Stylist("carol", "smith", "curly hair", 1);
      noStylists.Add(test);
      return noStylists;
    }
  }
}
