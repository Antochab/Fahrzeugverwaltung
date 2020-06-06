using Fahrzeugverwaltung.Klassen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace Fahrzeugverwaltung
{
    public class Fahrzeugpool
    {
        //Variablen der Klasse Fahrzeugpool
        private Parkhauspool parkhausverwaltung = new Parkhauspool();
        private List<Fahrzeug> fahrzeugliste = new List<Fahrzeug>();
        private List<String> allePKWDaten = new List<string>();
        private List<String> alleLKWDaten = new List<string>();
        private List<String> alleMotorradDaten = new List<string>();



        //Getter Methode für die Fahrzeugliste definieren, damit Fahrzeuge ausgegeben werden können
        public Parkhauspool Parkhausverwaltung { get { return parkhausverwaltung; } set { parkhausverwaltung = value; } }
        public List<String> AllePKWDaten { get { return allePKWDaten; } set { allePKWDaten = value; } }
        public List<String> AlleLKWDaten { get { return alleLKWDaten; } set { alleLKWDaten = value; } }
        public List<String> AlleMotorradDaten { get { return alleMotorradDaten; } set { alleMotorradDaten = value; } }
        public void neuenPKWAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aHubraum, String aLeistung, String aSchadstoffklasse)
        {
            //Anlegen von Variablen, die zum Überprüfen der Exceptions verwendet werden
            int hubraum = 0;
            int leistung = 0;
            int schadstoffklasse = 0;
            String stellplatznummer;

            //Aufrufen der Methode ExceptionHandling Methode
            //diese behandelt die Exceptions, welche in allen abgeleiteten Klassen der Basisklasse Fahzeug auftreten können
            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            //Vornehmen des spezifischen Exception Handlings für die Variablen der Klasse PKW

            //prüfen, ob der String aHubraum in einen int transofrmiert werden kann
            //prüfen, ob der String aHubraum ein Null Wert beinhaltet oder ein Leerzeichen beinhaltet
            if (int.TryParse(aHubraum, out hubraum) == false || String.IsNullOrWhiteSpace(aHubraum))
            {
                throw new ArgumentException("Hubraum überprüfen");
            }
            //prüfen, ob der String aLeistung in einen int transofrmiert werden kann
            //prüfen, ob der String aLeistung ein Null Wert beinhaltet oder ein Leerzeichen beinhaltet
            if (int.TryParse(aLeistung, out leistung) == false || String.IsNullOrWhiteSpace(aLeistung))
            {
                throw new ArgumentException("Leistung überprüfen");
            }
            //prüfen, ob der String aSchadstoffklasse in einen int transofrmiert werden kann
            //prüfen, ob der String aSchadstoffklasse ein Null Wert beinhaltet oder ein Leerzeichen beinhaltet
            if (int.TryParse(aSchadstoffklasse, out schadstoffklasse) == false || String.IsNullOrWhiteSpace(aSchadstoffklasse))
            {
                throw new ArgumentException("Schadstoffklasse überprüfen");
            }

            try
            {
                //neuen PKW zur Liste hinzufügen hinzufügen
                PKW pkw = new PKW(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aHubraum), Convert.ToInt32(aLeistung), Convert.ToInt32(aSchadstoffklasse));
                //PKW einem Stellplatz zuweisen
                stellplatznummer = stellplatzZuweisen(pkw);
                //prüfen, ob kein freier Stellplatz gefunden wurde
                if (stellplatznummer == "-1")
                {
                    throw new ArgumentException("Kein freier Stellplatz gefunden.");
                }
                //wurde ein freier Stellplatz geunden, wird dem PKW die Stellplatz nummer beigefügt
                else
                {
                    pkw.Stellplatznummer = stellplatznummer;
                }
                //neuen PKW der Fahrzeugliste hinzufügen
                fahrzeugliste.Add(pkw);

            }

            //Abfangen einer Exception, sollte eine aufgerufen werden
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public void neuenLKWAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aAchsenAnzahl, String aZuladung)
        {
            //Anlege
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
            if (stellplatznummer == "-1")
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
            if (stellplatznummer == "-1")
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

        public static string FahrzeugAusgeben(List<Fahrzeug> aFahrzeugliste, string kennzeichen)
        {
            string output_format = "";
            string output = "";

            //finden des Fahrzeugs in der Fahrzeugliste
            Fahrzeug f = aFahrzeugliste.Find(x => x.Kennzeichen.Contains(kennzeichen));
            //Zurückgeben des Ergebnisses
            
            switch (f.GetType().ToString())
            {
                case "Fahrzeugverwaltung.PKW":
                    PKW pkw = f as PKW;
                    output_format = "{0,-50}\n{1,-50}\n{2,-50}\n{3,-50}\n{4,-50}\n{5,-50}\n{6,-50}\n{7,-50}\n{8,-50}";
                    output = string.Format(output_format, "Hersteller: " + pkw.Hersteller, "Modell: " + pkw.Modell, "Kennzeichen: " + pkw.Kennzeichen, "Erstzulassung: " + pkw.Erstzulassung, "Anschaffungspreis: " + pkw.Anschaffungspreis, "Hubraum: " + pkw.Hubraum, "Leistung: " + pkw.Leistung, "Schadstoffklasse: " + pkw.Schadstoffklasse, "Stellplatz: " + pkw.Stellplatznummer);
                    break;
                case "Fahrzeugverwaltung.LKW":
                    LKW lkw = f as LKW;
                    output_format = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t{7,-20}\t";
                    output = string.Format(output_format, "Hersteller: " + lkw.Hersteller, "Modell: " + lkw.Modell, "Kennzeichen: " + lkw.Kennzeichen, "Erstzulassung: " + lkw.Erstzulassung, "Anschaffungspreis: " + lkw.Anschaffungspreis, "AnzahlAchsen: " + lkw.Achsenanzahl, "Zuladung: " + lkw.Zuladung, "Stellplatz: " + lkw.Stellplatznummer);
                    break;
                case "Fahrzeugverwaltung.Motorrad":
                    Motorrad motorrad = f as Motorrad;
                    output_format = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t";
                    output = string.Format(output_format, "Hersteller: " + motorrad.Hersteller, "Modell: " + motorrad.Modell, "Kennzeichen: " + motorrad.Kennzeichen, "Erstzulassung: " + motorrad.Erstzulassung, "Anschaffungspreis: " + motorrad.Anschaffungspreis, "Hubraum: " + motorrad.Hubraum, "Stellplatz: " + motorrad.Stellplatznummer);
                    break;
            }
            return output;
        }

        public float berechneSteuerschuldKennzeichen(string kennzeichen)
        {
            //Anlegen der Variablen steuerschuld
            float steuerschuld = 0;
            //Finden des Fahrezugs mit dem übergebenen Kennzeichen
            Fahrzeug f = sucheFahrzeug(fahrzeugliste, kennzeichen);

            if ((fahrzeugliste.Exists(x => x.Kennzeichen == kennzeichen)) == false)
            {
                throw new ArgumentException("Kennzeichen nicht vorhanden!");
            }

            if (f.GetType().ToString().Equals("Fahrzeugverwaltung.PKW"))
            {
                //Konvertieren des Fahrzeugs in den Typ PKW
                //um auf spezifische Variablen der Klasse PKW zugreifen zu können
                PKW p = (PKW)Convert.ChangeType(f, typeof(PKW));
                steuerschuld = (p.Hubraum + 99) / 100 * 10 * (p.Schadstoffklasse + 1);
            }
            else if (f.GetType().ToString().Equals("Fahrzeugverwaltung.LKW"))
            {
                //Konvertieren des Fahrzeugs in den Typ LKW
                //um auf spezifische Variablen der Klasse LKW zugreifen zu können
                LKW l = (LKW)Convert.ChangeType(f, typeof(LKW));
                steuerschuld = l.Zuladung * 100;
            }
            else
            {
                //Konvertieren des Fahrzeugs in den Typ Motorrad
                //um auf spezifische Variablen der Klasse Motorrad zugreifen zu können
                Motorrad m = (Motorrad)Convert.ChangeType(f, typeof(Motorrad));
                steuerschuld = (m.Hubraum + 99) / 10 * 20;
            }
            return steuerschuld;
        }

        public float berechneSteuerschuld()
        {
            //TODO Fahrzeuge mit Steuerschulden ausgeben
            float steuerschuld = 0;
            //berechnen der Steuerschuld für jedes Fahrzeug in der Fahrzeugliste
            foreach (Fahrzeug f in fahrzeugliste)
            {
                //addieren des Ergebnis der Berechnung der Steuerschuld auf die Variable Steuerschuld
                steuerschuld = steuerschuld + berechneSteuerschuldKennzeichen(f.Kennzeichen);
            }

            //Zurückgeben des Ergebnisses
            return steuerschuld;
        }

        public String stellplatzZuweisen(Fahrzeug f)
        {
            bool abbruch = false;
            String stellplatznummer = "-1";
            foreach (Parkhaus element in Parkhausverwaltung.Parkhausliste)
            {
                foreach (Stellplatz s in element.Stellplatzliste)
                {
                    string fahrzeugtyp = f.GetType().ToString();
                    if (s.IstBelegt == false)
                    {
                        if (s.Stellplatztyp == fahrzeugtyp)
                        {
                            s.Kennzeichen = f.Kennzeichen;
                            s.Parkhausnummer = element.Parkhausnummer;
                            stellplatznummer = s.Nummer;
                            s.IstBelegt = true;
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
            string pkw_output = "{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}";
            string lkw_output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t{7,-20}\t";
            string motorrad_output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t";


            allePKWDaten.Add(string.Format(pkw_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "Hubraum", "Leistung", "Schadstoffklasse", "Stellplatz"));
            alleLKWDaten.Add(string.Format(lkw_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "AnzahlAchsen", "Zuladung", "Stellplatz"));
            alleMotorradDaten.Add(string.Format(motorrad_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "Hubraum", "Stellplatz"));


            foreach (Fahrzeug fahrzeug in fahrzeugliste)
            {
                switch (fahrzeug.GetType().ToString())
                {
                    case "Fahrzeugverwaltung.PKW":
                        PKW pkw = fahrzeug as PKW;
                        allePKWDaten.Add(string.Format(pkw_output, pkw.Hersteller, pkw.Modell, pkw.Kennzeichen, pkw.Erstzulassung.ToString(), pkw.Anschaffungspreis.ToString(), pkw.Hubraum.ToString(), pkw.Leistung.ToString(), pkw.Schadstoffklasse.ToString(), pkw.Stellplatznummer.ToString()));
                        break;

                    case "Fahrzeugverwaltung.LKW":
                        LKW lkw = fahrzeug as LKW;
                        alleLKWDaten.Add(string.Format(lkw_output, lkw.Hersteller, lkw.Modell, lkw.Kennzeichen, lkw.Erstzulassung.ToString(), lkw.Anschaffungspreis.ToString(), lkw.Achsenanzahl.ToString(), lkw.Zuladung.ToString(), lkw.Stellplatznummer.ToString()));
                        break;

                    case "Fahrzeugverwaltung.Motorrad":
                        Motorrad motorrad = fahrzeug as Motorrad;
                        alleMotorradDaten.Add(string.Format(motorrad_output, motorrad.Hersteller, motorrad.Modell, motorrad.Kennzeichen, motorrad.Erstzulassung.ToString(), motorrad.Anschaffungspreis.ToString(), motorrad.Hubraum.ToString(), motorrad.Stellplatznummer.ToString()));

                        break;
                }
            }
        }


        public void datenInDatenbankSichern(String connectionString)
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();
            Boolean entryExists = false;
            try
            {

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


                    using (OleDbConnection connection = new OleDbConnection(connectionString))
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
            catch
            {
                throw new Exception("Datenbankeintrag konnte nicht angelegt werden");
            }
        }


        public void datenAusDatenbankAuslesen(String connectionString)
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();

            string kennzeichen, hersteller, modell, typ, stellplatznummer;
            float anschaffungspreis;
            int hubraum, erstzulassung, leistung, schadstoffklasse, achsenanzahl, zuladung;

            string query = "SELECT kennzeichen, hersteller, modell, erstzulassung, anschaffungspreis, hubraum, leistung, schadstoffklasse, achsenanzahl, zuladung, typ, stellplatznummer FROM fahrzeugliste";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
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
            }
            catch
            {
                throw new ArgumentException("Inhalt konnte nicht geladen werden");            
            }
        }
    };


}
