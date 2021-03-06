﻿/// <head>
/// Diese Klasse hat den Zweck, alle Operationen durchzuführen, welche mit dem Verwalten der Parkhäuser zusammenhängen.
/// Zudem werden in dieser Klasse das Abfragen sowie das Abspeichern von Parkhausdaten auf der Datenbank durchgeführt.
/// </head>
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Fahrzeugverwaltung.Klassen
{
    public class Parkhauspool
    {
        //Anlegen einer Parkhausliste
        //speichert alle Fahrzeuge einer Laufzeitinstanz
        private List<Parkhaus> parkhausliste = new List<Parkhaus>();

        //Getter und Setter der Parkhausliste
        public List<Parkhaus> Parkhausliste { get { return parkhausliste; } set { parkhausliste = value; } }

        //neues Parkhaus anlegen
        public void neuesParkhausAnlegen(String aOrt, String aPlz, String aParkhausnummer, String aAnzahlPKW, String aAnzahlMotorrad, String aAnzahlLKW)
        {
            //Anlegen der Variablen für das Exception Handling
            int anzahlPKW = 0;
            int anzahlLKW = 0;
            int anzahlMotorrad = 0;

            //prüfen, ob der String aOrt ein Null Wert, leer oder ein Leerzeichen ist
            if (String.IsNullOrEmpty(aOrt) || String.IsNullOrWhiteSpace(aOrt))
            {
                throw new ArgumentException("Ort überprüfen");
            }
            //prüfen, ob der String aPLZ ein Null Wert, leer oder ein Leerzeichen ist
            if (String.IsNullOrEmpty(aPlz) || String.IsNullOrWhiteSpace(aPlz))
            {
                throw new ArgumentException("PLZ überprüfen");
            }
            //prüfen, ob der String aParkhausnummer ein Null Wert, leer oder ein Leerzeichen ist
            if (String.IsNullOrEmpty(aParkhausnummer) || String.IsNullOrWhiteSpace(aParkhausnummer))
            {
                throw new ArgumentException("Parkhausnummer überprüfen");
            }
            //prüfen, ob der String aAnzahlPKW in ein Int konvertiert werden kann
            //prüfen, ob der String aAnzahlPKW einen Nullwert oder ein Leerzeichen beinhaltet
            if (int.TryParse(aAnzahlPKW, out anzahlPKW) == false || String.IsNullOrWhiteSpace(aAnzahlPKW))
            {
                throw new ArgumentException("Anzahl PKW überprüfen");
            }
            //prüfen, ob der String aAnzahlLKW in ein Int konvertiert werden kann
            //prüfen, ob der String aAnzahlLKW einen Nullwert oder ein Leerzeichen beinhaltet
            if (int.TryParse(aAnzahlLKW, out anzahlLKW) == false || String.IsNullOrWhiteSpace(aAnzahlLKW))
            {
                throw new ArgumentException("Anzahl LKW überprüfen");
            }
            //prüfen, ob der String aAnzahlMotorrad in ein Int konvertiert werden kann
            //prüfen, ob der String aAnzahlMotorrad einen Nullwert oder ein Leerzeichen beinhaltet
            if (int.TryParse(aAnzahlMotorrad, out anzahlMotorrad) == false || String.IsNullOrWhiteSpace(aAnzahlMotorrad))
            {
                throw new ArgumentException("Anzahl Motorrad überprüfen");
            }
            //neues Parkhaus instanziieren
            Parkhaus parkhaus = new Parkhaus(aOrt, aPlz, aParkhausnummer, Convert.ToInt32(aAnzahlPKW), Convert.ToInt32(aAnzahlMotorrad), Convert.ToInt32(aAnzahlLKW));
            //prüfen, ob bereits ein Parkhaus mit der gleichen Parkhausnummer exisitert
            if ((parkhausliste.Exists(x => x.Parkhausnummer == aParkhausnummer)) == true)
            {
                throw new ArgumentException("Es existiert bereits ein Parkhaus mit dieser Parkhausnummer.");
            }

            //Parkhausinstanz der Parkhausliste hinzufügen
            parkhausliste.Add(parkhaus);
        }

        /// <summary>
        /// Beim Verlassen des Programmes werden alle Parkhaus-Daten / Einträge in der Parkhausliste in die separate Datenbank übertragen,
        /// damit sie beim nächsten Programmstart wieder zur Verfügung stehen. Die Datenbankanbindung wird mithilfe der Programmierschnitttelle
        /// OLE-DB implementiert, wobei unterschiedliche Datenbankabfragen ausgeführt werden können.
        /// </summary>
        /// <param name="connectionString"></param>
        public void datenInDatenbankSichern(String connectionString)
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();
            try
            {

                /// Durchlaufen aller Parkhäuser und Erstellung einer SQL-Abfrage, damit die Daten in die DB übertragen werden können
                foreach (Parkhaus parkhaus in parkhausliste)
                {
                    Boolean entryExists = false;
                    String parkhaus_query = "Insert into Parkhausliste values('" + parkhaus.Ort + "','" + parkhaus.Plz + "','" + parkhaus.Parkhausnummer + "','" + parkhaus.AnzahlPKW + "','" + parkhaus.AnzahlMotorrad + "','" + parkhaus.AnzahlLKW + "');";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        /// prüfen, ob das Parkhaus bereits in der Datenbank existiert
                        using (cmd = new OleDbCommand("Select parkhausnummer from Parkhausliste", connection))
                        {
                            connection.Open();
                            OleDbDataReader reader = cmd.ExecuteReader();
                            String parkhausnummer;
                            while (reader.Read())
                            {
                                parkhausnummer = reader["parkhausnummer"].ToString();
                                if (parkhausnummer.Equals(parkhaus.Parkhausnummer))
                                {
                                    entryExists = true;
                                    break;
                                }
                            }
                        }
                        /// wenn das Parkhaus nicht existiert, dann wird ein neuer Eintrag angelegt
                        if (!entryExists)
                        {
                            ///
                            using (cmd = new OleDbCommand(parkhaus_query, connection))
                            {

                                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                                dataAdapter.Fill(dataSet);
                                connection.Close();
                                dataSet.Dispose();

                            }
                        }

                        ///Übertragen aller Stellplätze der Parkhäuser in die Datenbank
                        string stellplatz_query = string.Empty;
                        ///Alle stellplätze in die Datenbank übertragen
                        foreach (Stellplatz stellplatz in parkhaus.Stellplatzliste)
                        {
                            try
                            {
                                stellplatz_query = "Insert into Stellplatzliste values('" + stellplatz.Parkhausnummer + "','" + stellplatz.Nummer + "','" + stellplatz.Stellplatztyp + "','" + stellplatz.IstBelegt.ToString() + "','" + stellplatz.Kennzeichen + "');";



                                using (cmd = new OleDbCommand(stellplatz_query, connection))
                                {

                                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                                    dataAdapter.Fill(dataSet);
                                    connection.Close();
                                    dataSet.Dispose();

                                };
                            }
                            catch
                            {

                                stellplatz_query = "Update Stellplatzliste set kennzeichen = '" + stellplatz.Kennzeichen + "', istbelegt = '" + stellplatz.IstBelegt.ToString() + "' where stellplatznummer = '" + stellplatz.Nummer + "'";

                                using (cmd = new OleDbCommand(stellplatz_query, connection))
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
            }
            catch
            {
                throw new Exception("Datenbankeintrag konnte nicht angelegt werden");
            }
        }

        /// <summary>
        /// Beim Starten des Programmes werden alle Parkhaus-Daten / Einträge aus der Datenbank in die Parkhausliste der Klasse übertragen,
        /// damit sie vom letzten Programmablauf wieder zur Verfügung stehen. Die Datenbankanbindung wird mithilfe der Programmierschnitttelle
        /// OLE-DB implementiert, wobei unterschiedliche Datenbankabfragen ausgeführt werden können.
        /// </summary>
        /// <param name="connectionString"></param>
        public void datenAusDatenbankAuslesen(String connectionString)
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();


            String plz, ort, parkhausnummer, stellplatznummer, stellplatztyp, istBelegt, kennzeichen;
            int anzahlPKW, anzahlMotorrad, anzahlLKW;


            /// SQL-Abfragen zur Wiederherestellung der bereits vorhandenen Parkhäuser und Stellplätze in der Datenbank
             String parkhaus_query = "SELECT plz, ort, parkhausnummer, anzahlPKW, anzahlMotorrad, anzahlLKW FROM parkhausliste";
            String stellplatz_query = "SELECT parkhausnummer, stellplatznummer, stellplatztyp, istBelegt, kennzeichen FROM stellplatzliste";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (cmd = new OleDbCommand(parkhaus_query, connection))
                    {

                        connection.Open();

                        OleDbDataReader reader = cmd.ExecuteReader();

                    /// Auslesen aller Parkhauseinträge aus der Datenbank zur Wiederherstellung der Daten
                        while (reader.Read())
                        {    

                            plz = reader["plz"].ToString();
                            ort = reader["ort"].ToString();
                            parkhausnummer = reader["parkhausnummer"].ToString();
                            anzahlPKW = Int32.Parse(reader["anzahlPKW"].ToString());
                            anzahlMotorrad = Int32.Parse(reader["anzahlMotorrad"].ToString());
                            anzahlLKW = Int32.Parse(reader["anzahlLKW"].ToString());

                            Parkhaus parkhaus = new Parkhaus(ort, plz, parkhausnummer, anzahlPKW, anzahlMotorrad, anzahlLKW);
                            parkhausliste.Add(parkhaus);

                        }
                        reader.Close();
                    }

                    using (cmd = new OleDbCommand(stellplatz_query, connection))
                    {


                        OleDbDataReader reader = cmd.ExecuteReader();
                        foreach (Parkhaus parkhaus in parkhausliste)
                        {
                            parkhaus.Stellplatzliste.Clear();
                        }

                        /// Auslesen aller Stellplatzeinträge aus der Datenbank zur Wiederherstellung der Daten
                        while (reader.Read())
                        {    

                            parkhausnummer = reader["parkhausnummer"].ToString();
                            stellplatznummer = reader["stellplatznummer"].ToString();
                            stellplatztyp = reader["stellplatztyp"].ToString();
                            istBelegt = reader["istbelegt"].ToString();
                            kennzeichen = reader["kennzeichen"].ToString();

                            Stellplatz stellplatz = new Stellplatz(stellplatznummer, stellplatztyp, Boolean.Parse(istBelegt), parkhausnummer);
                            stellplatz.Kennzeichen = kennzeichen;


                            foreach (Parkhaus parkhaus in parkhausliste)
                            {
                                if (parkhaus.Parkhausnummer.Equals(parkhausnummer))
                                {
                                    parkhaus.Stellplatzliste.Add(stellplatz);
                                    break;
                                }
                            }

                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Inhalt konnte nicht geladen werden");
            }
        }

        public List<String> gibAlleParkhausDatenAus()
        {
            List<String> parkhausDaten = new List<String>();
            String output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t";
            parkhausDaten.Add(String.Format(output, "Ort", "PLZ", "Parkhausnummer", "AnzahlPKWPlätze", "AnzahlMotorradPlätze", "AnzahlLKWPlätze"));

            foreach (Parkhaus parkhaus in parkhausliste)
            {
                parkhausDaten.Add(String.Format(output, parkhaus.Ort, parkhaus.Plz, parkhaus.Parkhausnummer, parkhaus.AnzahlPKW.ToString(), parkhaus.AnzahlMotorrad.ToString(), parkhaus.AnzahlLKW.ToString()));
            }
            return parkhausDaten;
        }


        public List<String> gibAlleStellplatzDatenAus()
        {
            List<String> stellplatzDaten = new List<String>();
            String output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t";
            stellplatzDaten.Add(String.Format(output, "Parkhausnummer", "Stellplatznummer", "Stellplatztyp", "istBelegt", "Kennzeichen"));

            foreach (Parkhaus parkhaus in parkhausliste)
            {
                foreach (Stellplatz stellplatz in parkhaus.Stellplatzliste)
                {
                    stellplatzDaten.Add(String.Format(output, stellplatz.Parkhausnummer, stellplatz.Nummer, stellplatz.Stellplatztyp, stellplatz.IstBelegt.ToString(), stellplatz.Kennzeichen));

                }
            }
            return stellplatzDaten;
        }

    }
}
