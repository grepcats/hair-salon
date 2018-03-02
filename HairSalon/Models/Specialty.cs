using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
    public class Specialty
    {
        private int _id;
        private string _name;

        public Specialty(string name, int Id = 0)
        {
            _name = name;
            _id = Id;
        }

        public int GetId() { return _id;}

        public string GetName() { return _name;}
    }
}
