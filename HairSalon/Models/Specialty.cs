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

        public static List<Specialty> GetAllSpecialties()
        {
            List<Specialty> allSpecialties = new List<Specialty>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              string specialtyName = rdr.GetString(1);
              int specialtyId = rdr.GetInt32(0);
              Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
              allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
              conn.Dispose();
            }
            return allSpecialties;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `specialties` (`name`, `id`) VALUES (@Name, @Id);";

            MySqlParameter specialtyName = new MySqlParameter();
            specialtyName.ParameterName = "@Name";
            specialtyName.Value = this._name;

            MySqlParameter specialtyId = new MySqlParameter();
            specialtyId.ParameterName = "@Id";
            specialtyId.Value = this._id;

            cmd.Parameters.Add(specialtyName);
            cmd.Parameters.Add(specialtyId);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty) otherSpecialty;
                bool idEquality = (this.GetId() == newSpecialty.GetId());
                bool nameEquality = (this.GetName() == newSpecialty.GetName());

                return (idEquality && nameEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * from `specialties` WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            string specialtyName = "";
            int specialtyId = 0;

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                specialtyName = rdr.GetString(1);
                specialtyId = rdr.GetInt32(0);
            }

            Specialty foundSpecialty = new Specialty(specialtyName, specialtyId);

            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }

            return foundSpecialty;
        }
    }
}
