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

        public List<Stylist> GetStylists()
        {
            List<Stylist> allMyStylists = new List<Stylist>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylists.* FROM specialties
                JOIN specialties_stylists ON (specialties_stylists.specialty_id = specialties.id)
                JOIN stylists ON (stylists.id = specialties_stylists.stylist_id) WHERE specialties.id = @SpecialtyId;";

            MySqlParameter specialtyId = new MySqlParameter();
            specialtyId.ParameterName = "@SpecialtyId";
            specialtyId.Value = this._id;
            cmd.Parameters.Add(specialtyId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                string stylistFirstName = rdr.GetString(0);
                string stylistLastName = rdr.GetString(1);
                int stylistId = rdr.GetInt32(2);

                Stylist newStylist = new Stylist(stylistFirstName, stylistLastName, stylistId);

                allMyStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
              conn.Dispose();
            }
            return allMyStylists;
        }

        public void AddStylist(Stylist stylist)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `specialties_stylists` (`specialty_id`, `stylist_id`) VALUES (@SpecialtyId, @StylistId);";

            MySqlParameter specialtyId = new MySqlParameter();
            specialtyId.ParameterName = "@SpecialtyId";
            specialtyId.Value = this._id;
            cmd.Parameters.Add(specialtyId);

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@StylistId";
            stylistId.Value = stylist.GetId();
            cmd.Parameters.Add(stylistId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM `specialties` WHERE `id` = @thisId;";

            var cmdCommon = conn.CreateCommand() as MySqlCommand;
            cmdCommon.CommandText = @"DELETE FROM `specialties_stylists` WHERE `specialty_id` = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = _id;
            cmd.Parameters.Add(thisId);
            cmdCommon.Parameters.Add(thisId);

            cmdCommon.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
