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


        #region Eigenschaftsmethoden
        //Getter Methode für die Fahrzeugliste definieren, damit Fahrzeuge ausgegeben werden können
        public Parkhauspool Parkhausverwaltung { get { return parkhausverwaltung; } set { parkhausverwaltung = value; } }
        public List<String> AllePKWDaten { get { return allePKWDaten; } set { allePKWDaten = value; } }
        public List<String> AlleLKWDaten { get { return alleLKWDaten; } set { alleLKWDaten = value; } }
        public List<String> AlleMotorradDaten { get { return alleMotorradDaten; } set { alleMotorradDaten = value; } }
        #endregion

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
            //Anlegen der Variablen für das Exception Handling
            int achsenanzahl = 0;
            int zuladung = 0;
            String stellplatznummer;

            //Aufrufen der Methode ExceptionHandling Methode
            //diese behandelt die Exceptions, welche in allen abgeleiteten Klassen der Basisklasse Fahzeug auftreten können
            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            //Vornehmen des spezifischen Exception Handlings für die Variablen der Klasse PKW

            //prüfen, ob der String aAchsenAnzahl in einen int transofrmiert werden kann
            //prüfen, ob der String aAchsenAnzahl ein Null Wert beinhaltet oder ein Leerzeichen beinhaltet
            if (int.TryParse(aAchsenAnzahl, out achsenanzahl) == false || String.IsNullOrWhiteSpace(aAchsenAnzahl))
            {
                throw new ArgumentException("Achsenanzahl überprüfen");
            }
            //prüfen, ob der String aZuladung in einen int transofrmiert werden kann
            //prüfen, ob der String aZuladung ein Null Wert beinhaltet oder ein Leerzeichen beinhaltet
            if (int.TryParse(aZuladung, out zuladung) == false || String.IsNullOrWhiteSpace(aZuladung))
            {
                throw new ArgumentException("Zuladung überprüfen");
            }

            //neuen PKW zur Liste hinzufügen hinzufügen
            LKW lkw = new LKW(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aAchsenAnzahl), Convert.ToInt32(aZuladung));
            stellplatznummer = stellplatzZuweisen(lkw);
            //prüfen, ob kein freier Stellplatz gefunden wurde
            if (stellplatznummer == "-1")
            {
                throw new ArgumentException("Kein freier Stellplatz gefunden.");
            }
            //wurde ein freier Stellplatz gefunden, wird dem LKW die entsprechende Stellplatzummer beigefügt
            else
            {
                lkw.Stellplatznummer = stellplatznummer;
            }
            fahrzeugliste.Add(lkw);

        }

        public void neuesMotorradAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aHubraum)
        {
            //Anlegen der Variablen für das Exception Handling
            int hubraum = 0;
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

            //neues Motorrad zur Liste hinzufügen hinzufügen
            Motorrad motorrad = new Motorrad(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aHubraum));
            //Motorrad einem Stellplatz zuweisen
            stellplatznummer = stellplatzZuweisen(motorrad);
            //prüfen, ob ein freier Stellplatz gefunden wurde
            if (stellplatznummer == "-1")
            {
                throw new ArgumentException("Kein freier Parkplatz gefunden.");
            }
            //wurde ein freier Stellplatz gefunden, wird die Stellplatznummer dem Motorrad beigefügt
            else
            {
                motorrad.Stellplatznummer = stellplatznummer;
            }
            //Motorrad in die Fahrzeugliste hinzufügen
            fahrzeugliste.Add(motorrad);

        }

        public static Fahrzeug sucheFahrzeug(List<Fahrzeug> aFahrzeugliste, String kennzeichen)
        {
            //finden des Fahrzeugs in der Fahrzeugliste
            Fahrzeug f = aFahrzeugliste.Find(x => x.Kennzeichen.Contains(kennzeichen));
            //Zurückgeben des Ergebnisses
            return f;
        }

        public static String FahrzeugAusgeben(List<Fahrzeug> aFahrzeugliste, String kennzeichen)
        {
            //festlegen des Ausgabeformats 
            String output_format = "";
            String output = "";

            //finden des Fahrzeugs in der Fahrzeugliste
            Fahrzeug f = aFahrzeugliste.Find(x => x.Kennzeichen.Contains(kennzeichen));
            //Zurückgeben des Ergebnisses

            //Prüfen, welcher Fahrzeugtyp vorliegt
            switch (f.GetType().ToString())
            {
                case "Fahrzeugverwaltung.PKW":
                    //Format auf PKW anwenden
                    PKW pkw = f as PKW;
                    output_format = "{0,-50}\n{1,-50}\n{2,-50}\n{3,-50}\n{4,-50}\n{5,-50}\n{6,-50}\n{7,-50}\n{8,-50}";
                    output = string.Format(output_format, "Hersteller: " + pkw.Hersteller, "Modell: " + pkw.Modell, "Kennzeichen: " + pkw.Kennzeichen, "Erstzulassung: " + pkw.Erstzulassung, "Anschaffungspreis: " + pkw.Anschaffungspreis, "Hubraum: " + pkw.Hubraum, "Leistung: " + pkw.Leistung, "Schadstoffklasse: " + pkw.Schadstoffklasse, "Stellplatz: " + pkw.Stellplatznummer);
                    break;
                case "Fahrzeugverwaltung.LKW":
                    //Format auf LKW anwenden
                    LKW lkw = f as LKW;
                    output_format = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t{7,-20}\t";
                    output = string.Format(output_format, "Hersteller: " + lkw.Hersteller, "Modell: " + lkw.Modell, "Kennzeichen: " + lkw.Kennzeichen, "Erstzulassung: " + lkw.Erstzulassung, "Anschaffungspreis: " + lkw.Anschaffungspreis, "AnzahlAchsen: " + lkw.Achsenanzahl, "Zuladung: " + lkw.Zuladung, "Stellplatz: " + lkw.Stellplatznummer);
                    break;
                case "Fahrzeugverwaltung.Motorrad":
                    //Format auf Motorrad anwenden
                    Motorrad motorrad = f as Motorrad;
                    output_format = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t";
                    output = string.Format(output_format, "Hersteller: " + motorrad.Hersteller, "Modell: " + motorrad.Modell, "Kennzeichen: " + motorrad.Kennzeichen, "Erstzulassung: " + motorrad.Erstzulassung, "Anschaffungspreis: " + motorrad.Anschaffungspreis, "Hubraum: " + motorrad.Hubraum, "Stellplatz: " + motorrad.Stellplatznummer);
                    break;
            }
            //String ausgeben, welcher alle Fahrzeugdaten zurückgibt
            return output;
        }

        public float berechneSteuerschuldKennzeichen(String kennzeichen)
        {
            //Anlegen der Variablen steuerschuld
            float steuerschuld = 0;
            //Finden des Fahrezugs mit dem übergebenen Kennzeichen
            Fahrzeug f = sucheFahrzeug(fahrzeugliste, kennzeichen);

            //prüfen, ob das Kennzeichen in der Fahrzeugliste existiert
            if ((fahrzeugliste.Exists(x => x.Kennzeichen == kennzeichen)) == false)
            {
                throw new ArgumentException("Kennzeichen nicht vorhanden!");
            }
            //prüfen, ob Fahrzeug vom Typ PKW ist
            if (f.GetType().ToString().Equals("Fahrzeugverwaltung.PKW"))
            {
                //Konvertieren des Fahrzeugs in den Typ PKW
                //um auf spezifische Variablen der Klasse PKW zugreifen zu können
                PKW p = (PKW)Convert.ChangeType(f, typeof(PKW));
                steuerschuld = (p.Hubraum + 99) / 100 * 10 * (p.Schadstoffklasse + 1);
            }
            //prüfen, ob Fahrzeug vom Typ LKW ist
            else if (f.GetType().ToString().Equals("Fahrzeugverwaltung.LKW"))
            {
                //Konvertieren des Fahrzeugs in den Typ LKW
                //um auf spezifische Variablen der Klasse LKW zugreifen zu können
                LKW l = (LKW)Convert.ChangeType(f, typeof(LKW));
                steuerschuld = l.Zuladung * 100;
            }
            //ist das Fahrzeug weder vom Typ LKW noch vom Typ PKW, ist es vom Typ Motorrad
            else
            {
                //Konvertieren des Fahrzeugs in den Typ Motorrad
                //um auf spezifische Variablen der Klasse Motorrad zugreifen zu können
                Motorrad m = (Motorrad)Convert.ChangeType(f, typeof(Motorrad));
                steuerschuld = (m.Hubraum + 99) / 10 * 20;
            }
            //zurückgeben der Steuerschuld
            return steuerschuld;
        }

        public float berechneSteuerschuld()
        {
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
            //Definieren einer Abbruchvariable
            bool abbruch = false;
            //Stellplatznummer standardmäßig auf -1 setzen
            //wird -1 zurückgegeben, indiziert dies, dass kein freier Parkplatz gefunden wurde
            String stellplatznummer = "-1";

            //Schleife über alle Parkhäuser in der Parkhausliste laufen lassen
            foreach (Parkhaus element in Parkhausverwaltung.Parkhausliste)
            {
                //Schleife über alle Stellplätze in einem Parkplatz
                foreach (Stellplatz s in element.Stellplatzliste)
                {
                    //Fahrzeugtyp abfregen
                    String fahrzeugtyp = f.GetType().ToString();
                    //prüfen ob der Stellplatz belegt
                    if (s.IstBelegt == false)
                    {
                        //Prüfen, ob der Stellplatztyp dem Typ des Fahrzeugs entspricht
                        if (s.Stellplatztyp == fahrzeugtyp)
                        {
                            //dem Stellplatz das Kennzeichen zuweisen
                            s.Kennzeichen = f.Kennzeichen;
                            s.Parkhausnummer = element.Parkhausnummer;
                            //stellplatznummer zuweisen
                            stellplatznummer = s.Nummer;
                            //Variable istBelegt des Stellplatzes auf true stellen
                            s.IstBelegt = true;
                            //Schleifen durchlauf abbrechen
                            abbruch = true;
                            break;
                        }
                    }
                }
                //prüfen, ob die Schleife abgebrochen wurde
                //ist der Fall, wenn ein freier Stellplatz gefunden wurde
                if (abbruch == true)
                {
                    break;
                }
            }
            //stellplatznummer zurückgeben
            return stellplatznummer;

        }
        private void ExceptionHandling(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis)
        {
            //Anlegen der Variablen für das Exception Handling
            int erstzulassung = 0;
            float anschaffungspreis = 0;
            //festlegen des Formats für das Kennezeichen
            Regex kennzeichenFormat = new Regex(@"^[a-zA-Z]{1,3}-[a-zA-Z]{1,2}(-\d{1,4})$");

            //Prüfen ob der String ein NullWert oder ein Leerzeichen repräsentiert
            if (String.IsNullOrEmpty(aHersteller) || String.IsNullOrWhiteSpace(aHersteller))
            {
                throw new ArgumentException("Hersteller überprüfen");
            }
            //Prüfen ob der String ein NullWert oder ein Leerzeichen repräsentiert
            if (String.IsNullOrEmpty(aModell) || String.IsNullOrWhiteSpace(aModell))
            {
                throw new ArgumentException("Modell überprüfen");
            }
            //Prüfen ob der String ein NullWert oder ein Leerzeichen repräsentiert
            //Prüfen, ob das Kennzeichen ein korrektes Format hat
            if (String.IsNullOrEmpty(aKennzeichen) || String.IsNullOrWhiteSpace(aKennzeichen) || !kennzeichenFormat.IsMatch(aKennzeichen))
            {
                throw new ArgumentException("Kennzeichen überprüfen");
            }
            //prüfen, ob der String aZuladung in einen int transofrmiert werden kann
            //prüfen, ob der String aZuladung ein Null Wert beinhaltet oder ein Leerzeichen beinhaltet
            if (int.TryParse(aErstzulassung, out erstzulassung) == false || String.IsNullOrWhiteSpace(aErstzulassung))
            {
                throw new ArgumentException("Erstzulassung überprüfen");
            }
            //prüfen, ob der String aZuladung in einen float transofrmiert werden kann
            //prüfen, ob der String aZuladung ein Null Wert beinhaltet oder ein Leerzeichen beinhaltet
            if (float.TryParse(aAnschaffungspreis, out anschaffungspreis) == false || String.IsNullOrWhiteSpace(aAnschaffungspreis))
            {
                throw new ArgumentException("Anschaffungspreis überprüfen");
            }
        }
        public void gibAlleDatenAus()
        {
            //festlegen der jeweiligen Formate für die einzelnen Fahrzeugtypen
            String pkw_output = "{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}";
            String lkw_output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t{7,-20}\t";
            String motorrad_output = "{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}\t{6,-20}\t";

            //Hinzufügen der Beschriftungen der Fahrzeuge in einen String
            allePKWDaten.Add(String.Format(pkw_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "Hubraum", "Leistung", "Schadstoffklasse", "Stellplatz"));
            alleLKWDaten.Add(String.Format(lkw_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "AnzahlAchsen", "Zuladung", "Stellplatz"));
            alleMotorradDaten.Add(String.Format(motorrad_output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassung", "Anschaffungspreis", "Hubraum", "Stellplatz"));

            //Schleife über alle Fahrzeuge in der Fahrzeugliste laufen lassen
            foreach (Fahrzeug fahrzeug in fahrzeugliste)
            {
                //Prüfen, welcher Fahrzeugtyp vorliegt
                switch (fahrzeug.GetType().ToString())
                {
                    //es liegt ein PKW vor
                    case "Fahrzeugverwaltung.PKW":
                        //Fahrzeug zu PKW konvertieren
                        PKW pkw = fahrzeug as PKW;
                        //alle PKW Daten in einen String übertragen gemäß des festgelegten Formats
                        allePKWDaten.Add(String.Format(pkw_output, pkw.Hersteller, pkw.Modell, pkw.Kennzeichen, pkw.Erstzulassung.ToString(), pkw.Anschaffungspreis.ToString(), pkw.Hubraum.ToString(), pkw.Leistung.ToString(), pkw.Schadstoffklasse.ToString(), pkw.Stellplatznummer.ToString()));
                        break;

                    //es liegt ein LKW vor
                    case "Fahrzeugverwaltung.LKW":
                        //Fahrzeug in LKW übertragen
                        LKW lkw = fahrzeug as LKW;
                        //alle LKW Daten in einen String übertragen gemäß des festgelegten Formats
                        alleLKWDaten.Add(String.Format(lkw_output, lkw.Hersteller, lkw.Modell, lkw.Kennzeichen, lkw.Erstzulassung.ToString(), lkw.Anschaffungspreis.ToString(), lkw.Achsenanzahl.ToString(), lkw.Zuladung.ToString(), lkw.Stellplatznummer.ToString()));
                        break;

                    //es liegt ein Motorrad vor
                    case "Fahrzeugverwaltung.Motorrad":
                        //Fahrzeug zu Motorrad übertragen
                        Motorrad motorrad = fahrzeug as Motorrad;
                        //alle Motorrad Daten in einen String übertragen gemäß des festgelegten Formats
                        alleMotorradDaten.Add(String.Format(motorrad_output, motorrad.Hersteller, motorrad.Modell, motorrad.Kennzeichen, motorrad.Erstzulassung.ToString(), motorrad.Anschaffungspreis.ToString(), motorrad.Hubraum.ToString(), motorrad.Stellplatznummer.ToString()));
                        break;
                }
            }
        }

        /// <summary>
        /// Beim Verlassen des Programmes werden alle Daten / Einträge in der Fahrzeugliste in die separate Datenbank übertragen,
        /// damit sie beim nächsten Programmstart wieder zur Verfügung stehen. Die Datenbankanbindung wird mithilfe der Programmierschnitttelle
        /// OLE-DB implementiert, wobei unterschiedliche Datenbankabfragen ausgeführt werden können.
        /// </summary>
        /// <param name="connectionString"></param>
        public void datenInDatenbankSichern(String connectionString)
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();
            Boolean entryExists = false;
            try
            {
                ///SQL-Queries in Abhängigkeit von dem Fahrzeugtypen erstellen
                foreach (Fahrzeug fahrzeug in fahrzeugliste)
                {
                    String fahrzeugtyp = fahrzeug.GetType().ToString();
                    String query = "Insert into Fahrzeugliste values('" + fahrzeug.Kennzeichen + "','" + fahrzeug.Hersteller + "','" + fahrzeug.Modell + "'," + fahrzeug.Erstzulassung + "," + fahrzeug.Anschaffungspreis + ",";
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

                    ///neue OLE-DB Verbindung herstellen, um auf die Datenbank zuzugreifen
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {

                        ///prüfen, ob Kennzeichen bereits in der Datenbank vorhanden ist
                        using (cmd = new OleDbCommand("Select kennzeichen from Fahrzeugliste", connection))
                        {
                            connection.Open();
                            OleDbDataReader reader = cmd.ExecuteReader();
                            String kennzeichen;
                            while (reader.Read())
                            {
                                kennzeichen = reader["kennzeichen"].ToString();
                                if (kennzeichen.Equals(fahrzeug.Kennzeichen)) entryExists = true;
                            }
                        }
                        /// Wenn der Datensatz nicht existiert wird ein neuer Eintrag angelegt
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

        /// <summary>
        /// Beim Starten des Programmes werden alle Daten / Einträge aus der Datenbank in die Fahrzeugliste der Klasse übertragen,
        /// damit sie vom letzten Programmablauf wieder zur Verfügung stehen. Die Datenbankanbindung wird mithilfe der Programmierschnitttelle
        /// OLE-DB implementiert, wobei unterschiedliche Datenbankabfragen ausgeführt werden können.
        /// </summary>
        /// <param name="connectionString"></param>
        public void datenAusDatenbankAuslesen(String connectionString)
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();

            String kennzeichen, hersteller, modell, typ, stellplatznummer;
            float anschaffungspreis;
            int hubraum, erstzulassung, leistung, schadstoffklasse, achsenanzahl, zuladung;

<<<<<<< HEAD
            ///SQL-Abfrage zur Wiederherstellung der bereits vorhandenen Fahrzeuge aus der Datenbank
            string query = "SELECT kennzeichen, hersteller, modell, erstzulassung, anschaffungspreis, hubraum, leistung, schadstoffklasse, achsenanzahl, zuladung, typ, stellplatznummer FROM fahrzeugliste";
=======
            String query = "SELECT kennzeichen, hersteller, modell, erstzulassung, anschaffungspreis, hubraum, leistung, schadstoffklasse, achsenanzahl, zuladung, typ, stellplatznummer FROM fahrzeugliste";
>>>>>>> 7a4f92e0c82c482a90225f9ddceba1b84ae8ced7

            try
            {
                ///Aufbau einer neuen datenbankverbindung
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (cmd = new OleDbCommand(query, connection))
                    {

                        connection.Open();

                        OleDbDataReader reader = cmd.ExecuteReader();

                        /// Es wird jede Reihe aus der Datenbank ausgelesen, damit die Fahrzeuge wiederhergestellt werden können
                        while (reader.Read())
                        {    

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
                            
                            /// Abhängig von dem jeweiligen Fahrzeugtypen, wird ein neuer Fahrzeugtyp in die Liste eingefügt 
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
