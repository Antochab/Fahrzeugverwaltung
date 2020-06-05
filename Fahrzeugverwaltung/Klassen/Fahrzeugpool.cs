using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using Fahrzeugverwaltung.Klassen;
using System.Drawing.Drawing2D;

namespace Fahrzeugverwaltung
{
    public class Fahrzeugpool
    {
        private List<Fahrzeug> fahrzeugliste = new List<Fahrzeug>();
        private List<Parkhaus> parkhausliste = new List<Parkhaus>();
        private List<String> allePKWDaten = new List<string>();
        private List<String> alleLKWDaten = new List<string>();
        private List<String> alleMotorradDaten = new List<string>();

        public Fahrzeugpool(Parkhausverwaltung aParkhausverwaltung)
        {
            Parkhausliste = aParkhausverwaltung.Parkhausliste;
        }


        //Getter Methode für die Fahrzeugliste definieren, damit Fahrzeuge ausgegeben werden können
        public List<Fahrzeug> Fahrzeugliste { get { return fahrzeugliste; } }
        public List<String> AllePKWDaten { get { return allePKWDaten; } set { allePKWDaten = value; } }
        public List<String> AlleLKWDaten { get { return alleLKWDaten; } set { alleLKWDaten = value; } }
        public List<String> AlleMotorradDaten { get { return alleMotorradDaten; } set { alleMotorradDaten = value; } }

        public List<Parkhaus> Parkhausliste { get { return parkhausliste; } set { parkhausliste = value; } }

        public void neuenPKWAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aHubraum, String aLeistung, String aSchadstoffklasse)
        {
            int hubraum = 0;
            int leistung = 0;
            int schadstoffklasse = 0;
            String stellplatznummer;

            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            if (int.TryParse(aHubraum, out hubraum) == false || String.IsNullOrWhiteSpace(aHubraum))
            {
                throw new ArgumentException("Hubraum überprüfen");
            }
            if (int.TryParse(aLeistung, out leistung) == false || String.IsNullOrWhiteSpace(aLeistung))
            {
                throw new ArgumentException("Leistung überprüfen");
            }
            if (int.TryParse(aSchadstoffklasse, out schadstoffklasse) == false || String.IsNullOrWhiteSpace(aSchadstoffklasse))
            {
                throw new ArgumentException("Schadstoffklasse überprüfen");
            }

            try {
                //neuen PKW zur Liste hinzufügen hinzufügen
                PKW pkw = new PKW(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aHubraum), Convert.ToInt32(aLeistung), Convert.ToInt32(aSchadstoffklasse));
                stellplatznummer = stellplatzZuweisen(pkw);
                if(stellplatznummer == "-1")
                {
                    throw new ArgumentException("Kein freier Stellplatz gefunden."); 
                }
                else
                {
                    pkw.Stellplatznummer = stellplatznummer;
                }
                fahrzeugliste.Add(pkw);
                
            } catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public void neuenLKWAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aAchsenAnzahl, String aZuladung)
        {
            int achsenanzahl = 0;
            int zuladung = 0;
            String stellplatznummer;

            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            if (int.TryParse(aAchsenAnzahl, out achsenanzahl) == false || String.IsNullOrWhiteSpace(aAchsenAnzahl))
            {
                throw new ArgumentException("Achsenanzahl überprüfen");
            }
            if (int.TryParse(aZuladung, out zuladung) == false || String.IsNullOrWhiteSpace(aZuladung))
            {
                throw new ArgumentException("Zuladung überprüfen");
            }

            //neuen PKW zur Liste hinzufügen hinzufügen
            LKW lkw = new LKW(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aAchsenAnzahl), Convert.ToInt32(aZuladung));
            stellplatznummer = stellplatzZuweisen(lkw);
            if(stellplatznummer == "-1")
            {
                throw new ArgumentException("Kein freier Stellplatz gefunden.");
            }
            else
            {
                lkw.Stellplatznummer = stellplatznummer; 
            }
            fahrzeugliste.Add(lkw);
            
        }

        public void neuesMotorradAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aHubraum)
        {
            int hubraum = 0;
            String stellplatznummer;

            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            if (int.TryParse(aHubraum, out hubraum) == false || String.IsNullOrWhiteSpace(aHubraum))
            {
                throw new ArgumentException("Hubraum überprüfen");
            }

            //neuen PKW zur Liste hinzufügen hinzufügen
            Motorrad motorrad = new Motorrad(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aHubraum));
            stellplatznummer = stellplatzZuweisen(motorrad);
            if(stellplatznummer == "-1")
            {
                throw new ArgumentException("Kein freier Parkplatz gefunden.");
            }
            else
            {
                motorrad.Stellplatznummer = stellplatznummer;
            }
            fahrzeugliste.Add(motorrad);
          
        }


        public static Fahrzeug sucheFahrzeug(List<Fahrzeug> aFahrzeugliste, string kennzeichen)
        {
            //finden des Fahrzeugs in der Fahrzeugliste
            Fahrzeug f = aFahrzeugliste.Find(x => x.Kennzeichen.Contains(kennzeichen));
            //Zurückgeben des Ergebnisses
            return f;
        }

        public float berechneSteuerschuld()
        {
            //TODO Fahrzeuge mit Steuerschulden ausgeben
            float steuerschuld = 0;
            //berechnen der Steuerschuld für jedes Fahrzeug in der Fahrzeugliste
            foreach (Fahrzeug f in fahrzeugliste)
            {
                //addieren des Ergebnis der Berechnung der Steuerschuld auf die Variable Steuerschuld
                steuerschuld = steuerschuld + f.berechneSteuerschuldKennzeichen(fahrzeugliste, f.Kennzeichen);
            }

            //Zurückgeben des Ergebnisses
            return steuerschuld;
        }

        public String stellplatzZuweisen(Fahrzeug f)
        {
            bool abbruch = false;
            String stellplatznummer = "-1";
            foreach (Parkhaus element in parkhausliste)
            {
                foreach (Stellplatz s in element.Stellplatzliste)
                {
                    string fahrzeugtyp = f.GetType().ToString();
                    if (s.IstBelegt == false)
                    {
                        if (s.Stellplatztyp == fahrzeugtyp)
                        {
                            s.Kennzeichen = f.Kennzeichen;
                            stellplatznummer = s.Nummer;
                            
                            abbruch = true;
                            break;
                        }
                    }
                }
                if (abbruch == true)
                {
                    break;
                }
            }
            return stellplatznummer; 

        }
        private void ExceptionHandling(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis)
        {
            int erstzulassung = 0;
            float anschaffungspreis = 0;
            Regex kennzeichenFormat = new Regex(@"^[a-zA-Z]{1,3}-[a-zA-Z]{1,2}(-\d{1,4})$");

            if (String.IsNullOrEmpty(aHersteller) || String.IsNullOrWhiteSpace(aHersteller))
            {
                throw new ArgumentException("Hersteller überprüfen");
            }
            if (String.IsNullOrEmpty(aModell) || String.IsNullOrWhiteSpace(aModell))
            {
                throw new ArgumentException("Modell überprüfen");
            }
            //Format angeben
            if (String.IsNullOrEmpty(aKennzeichen) || String.IsNullOrWhiteSpace(aKennzeichen) || !kennzeichenFormat.IsMatch(aKennzeichen))
            {
                throw new ArgumentException("Kennzeichen überprüfen");
            }
            if (int.TryParse(aErstzulassung, out erstzulassung) == false || String.IsNullOrWhiteSpace(aErstzulassung))
            {
                throw new ArgumentException("Erstzulassung überprüfen");
            }
            if (float.TryParse(aAnschaffungspreis, out anschaffungspreis) == false || String.IsNullOrWhiteSpace(aAnschaffungspreis))
            {
                throw new ArgumentException("Anschaffungspreis überprüfen");
            }
        }
        public void gibAlleDatenAus()
        {
            foreach (Fahrzeug fahrzeug in fahrzeugliste)
            {
                switch (fahrzeug.GetType().ToString())
                {
                    case "Fahrzeugverwaltung.PKW":
                        string pkw_output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t{7,-20}\t{8,-20}\t";
                        PKW pkw = fahrzeug as PKW;
                        allePKWDaten.Add(string.Format(pkw_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "Hubraum", "Leistung", "Schadstoffklasse","Stellplatz"));
                        allePKWDaten.Add(string.Format(pkw_output, pkw.Hersteller, pkw.Modell, pkw.Kennzeichen, pkw.Erstzulassung.ToString(), pkw.Anschaffungspreis.ToString(), pkw.Hubraum.ToString(),pkw.Leistung.ToString(),pkw.Schadstoffklasse.ToString(),pkw.Stellplatznummer.ToString()));
                        break;

                    case "Fahrzeugverwaltung.LKW":
                        string lkw_output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t{7,-20}\t";
                        LKW lkw = fahrzeug as LKW;
                        alleLKWDaten.Add(string.Format(lkw_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "AnzahlAchsen","Zuladung","Stellplatz"));
                        alleLKWDaten.Add(string.Format(lkw_output, lkw.Hersteller, lkw.Modell, lkw.Kennzeichen, lkw.Erstzulassung.ToString(), lkw.Anschaffungspreis.ToString(), lkw.Achsenanzahl.ToString(), lkw.Zuladung.ToString(),lkw.Stellplatznummer.ToString()));
                        break;

                    case "Fahrzeugverwaltung.Motorrad":
                        string motorrad_output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t";
                        Motorrad motorrad = fahrzeug as Motorrad;
                        alleMotorradDaten.Add(string.Format(motorrad_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "Hubraum","Stellplatz"));
                        alleMotorradDaten.Add(string.Format(motorrad_output, motorrad.Hersteller, motorrad.Modell, motorrad.Kennzeichen, motorrad.Erstzulassung.ToString(), motorrad.Anschaffungspreis.ToString(), motorrad.Hubraum.ToString(),motorrad.Stellplatznummer.ToString()));
                        
                        break;
                }
            }
        }


        public void datenInDatenbankSichern()
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();
            Boolean entryExists = false;
            try
            {
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\anton\Documents\Fahrzeugverwaltung.mdb";


                foreach (Fahrzeug fahrzeug in fahrzeugliste)
                {
                    string fahrzeugtyp = fahrzeug.GetType().ToString();
                    string query = "Insert into Fahrzeugliste values('" + fahrzeug.Kennzeichen + "','" + fahrzeug.Hersteller + "','" + fahrzeug.Modell + "'," + fahrzeug.Erstzulassung + "," + fahrzeug.Anschaffungspreis + ",";
                    entryExists = false;

                        switch (fahrzeugtyp)
                        {
                            case "Fahrzeugverwaltung.PKW":
                                PKW pkw = fahrzeug as PKW;
                                query = query + pkw.Hubraum + "," + pkw.Leistung + "," + pkw.Schadstoffklasse + ",0,0,'" + pkw.GetType().ToString() + "','" + pkw.Stellplatznummer.ToString() + "');";
                                break;

                            case "Fahrzeugverwaltung.Motorrad":
                                Motorrad motorrad = fahrzeug as Motorrad;
                                query = query + motorrad.Hubraum + ",0,0,0,0,'" + motorrad.GetType().ToString() + "','" + motorrad.Stellplatznummer.ToString() + "');";
                                break;

                            case "Fahrzeugverwaltung.LKW":
                                LKW lkw = fahrzeug as LKW;
                                query = query + "0,0,0," + lkw.Achsenanzahl + "," + lkw.Zuladung + ",'" + lkw.GetType().ToString() + "','" + lkw.Stellplatznummer.ToString() + "');";
                                break;

                        }


                        using (OleDbConnection connection = new OleDbConnection(connString))
                        {

                        using (cmd = new OleDbCommand("Select kennzeichen from Fahrzeugliste", connection))
                        {
                            connection.Open();
                            OleDbDataReader reader = cmd.ExecuteReader();
                            string kennzeichen;
                            while (reader.Read())
                            {
                                kennzeichen = reader["kennzeichen"].ToString();
                                if (kennzeichen.Equals(fahrzeug.Kennzeichen)) entryExists = true;
                            }
                        }

                        if (!entryExists)
                        {
                            using (cmd = new OleDbCommand(query, connection))
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


            string kennzeichen, hersteller, modell, typ, stellplatznummer;
            float anschaffungspreis;
            int hubraum, erstzulassung, leistung, schadstoffklasse, achsenanzahl, zuladung ;

            string query = "SELECT kennzeichen, hersteller, modell, erstzulassung, anschaffungspreis, hubraum, leistung, schadstoffklasse, achsenanzahl, zuladung, typ, stellplatznummer FROM fahrzeugliste";

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

                            kennzeichen = reader["kennzeichen"].ToString();
                            hersteller = reader["hersteller"].ToString();
                            modell = reader["modell"].ToString();
                            erstzulassung = Int32.Parse(reader["erstzulassung"].ToString());
                            anschaffungspreis = float.Parse(reader["anschaffungspreis"].ToString());
                            hubraum = Int32.Parse(reader["hubraum"].ToString());
                            leistung = Int32.Parse(reader["leistung"].ToString());
                            schadstoffklasse = Int32.Parse(reader["schadstoffklasse"].ToString());
                            achsenanzahl = Int32.Parse(reader["achsenanzahl"].ToString());
                            zuladung = Int32.Parse(reader["zuladung"].ToString());
                            typ = reader["typ"].ToString();
                            stellplatznummer = reader["stellplatznummer"].ToString();

                            switch (typ)
                            {
                                case "Fahrzeugverwaltung.PKW":
                                    PKW pkw = new PKW(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, hubraum, leistung, schadstoffklasse);
                                    pkw.Stellplatznummer = stellplatznummer;
                                    fahrzeugliste.Add(pkw);
                                    break;

                                case "Fahrzeugverwaltung.Motorrad":
                                    Motorrad motorrad = new Motorrad(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, hubraum);
                                    motorrad.Stellplatznummer = stellplatznummer;
                                    fahrzeugliste.Add(motorrad);
                                    break;

                                case "Fahrzeugverwaltung.LKW":
                                    LKW lkw = new LKW(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, achsenanzahl, zuladung);
                                    lkw.Stellplatznummer = stellplatznummer;
                                    fahrzeugliste.Add(lkw);
                                    break;
                            }
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
                } catch (Exception ex)
            {
                //If an exception occurs, write it to the console
                Console.WriteLine(ex.ToString());
            }
        }
    };


}
