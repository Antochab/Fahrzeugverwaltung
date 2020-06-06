using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using Fahrzeugverwaltung.Klassen;
using System.Drawing.Drawing2D;

namespace Fahrzeugverwaltung.Klassen
{
    public class Parkhausverwaltung
    {
        private List<Parkhaus> parkhausliste = new List<Parkhaus>();

        public List<Parkhaus> Parkhausliste { get { return parkhausliste; } set { parkhausliste = value; } }

        public void neuesParkhausAnlegen(string aOrt, string aPlz, string aStrasse, int aMaxKap, String aParkhausnummer, int aAnzahlPKW, int aAnzahlMotorrad,  int aAnzahlLKW)
        {
            Parkhaus parkhaus = new Parkhaus(aOrt, aPlz, aStrasse, aMaxKap, aParkhausnummer, aAnzahlPKW, aAnzahlMotorrad, aAnzahlLKW);
            if(aMaxKap > parkhaus.Stellplatzliste.Count())
            {
                throw new ArgumentException ("Liste zu groß!");
            }
            if ((parkhausliste.Exists(x => x.Parkhausnummer == aParkhausnummer)) == true)
            {
                throw new ArgumentException("Es existiert bereits ein Parkhaus mit dieser Parkhausnummer.");
            }

            parkhausliste.Add(parkhaus);
        }

        public void datenInDatenbankSichern()
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();
            try
            {
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\anton\Documents\Fahrzeugverwaltung.mdb";


                foreach (Parkhaus parkhaus in parkhausliste)
                {
                    string parkhaus_query = "Insert into Parkhausliste values('" + parkhaus.Ort + "','" + parkhaus.Plz + "','" + parkhaus.MaxKap + "','" + parkhaus.Parkhausnummer + "','" + parkhaus.AnzahlPKW + "','" + parkhaus.AnzahlMotorrad + "','" + parkhaus.AnzahlLKW + "');";

                    using (OleDbConnection connection = new OleDbConnection(connString))
                    {
                            using (cmd = new OleDbCommand(parkhaus_query, connection))
                            {

                                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                                dataAdapter.Fill(dataSet);
                                connection.Close();
                                dataSet.Dispose();

                            };
                        ///Alles stellplätze in die Datenbank übertragen
                        ///
                        foreach(Stellplatz stellplatz in parkhaus.Stellplatzliste)
                        {
                            string stelllplatz_query = "Insert into Stellplatzliste values('" + parkhaus.Parkhausnummer + "','" + stellplatz.Nummer + "','" + stellplatz.Stellplatztyp + "','" + stellplatz.IstBelegt.ToString() + "');";

                            using (cmd = new OleDbCommand(stelllplatz_query, connection))
                            {

                                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                                dataAdapter.Fill(dataSet);
                                connection.Close();
                                dataSet.Dispose();

                            };
                        }



                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Datenbankeintrag konnte nicht angelegt werden");
            }
        }
        public void datenAusDatenbankAuslesen()
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\anton\Documents\Fahrzeugverwaltung.mdb";


            string plz, ort, parkhausnummer;
            int maxkap, anzahlPKW, anzahlMotorrad, anzahlLKW;

            string query = "SELECT plz, ort, maxkap, parkhausnummer, anzahlPKW, anzahlMotorrad, anzahlLKW FROM parkhausliste";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connString))
                {
                    using (cmd = new OleDbCommand(query, connection))
                    {

                        connection.Open();

                        OleDbDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {    //Every new row will create a new dictionary that holds the columns

                            plz = reader["plz"].ToString();
                            ort = reader["ort"].ToString();
                            parkhausnummer = reader["parkhausnummer"].ToString();
                            maxkap = Int32.Parse(reader["maxkap"].ToString());
                            anzahlPKW = Int32.Parse(reader["anzahlPKW"].ToString());
                            anzahlMotorrad = Int32.Parse(reader["anzahlMotorrad"].ToString());
                            anzahlLKW = Int32.Parse(reader["anzahlLKW"].ToString());
                            

                            Parkhaus parkhaus = new Parkhaus(ort,plz,"beispielstraße",maxkap,parkhausnummer,anzahlPKW,anzahlMotorrad,anzahlLKW);
                            parkhausliste.Add(parkhaus);
                            break;

                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //If an exception occurs, write it to the console
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
