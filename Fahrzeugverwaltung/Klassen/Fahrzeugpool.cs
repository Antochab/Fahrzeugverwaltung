using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Fahrzeugverwaltung
{
    public class Fahrzeugpool
    {
        private List<Fahrzeug> fahrzeugliste = new List<Fahrzeug>();
        private List<Parkhaus> parkhausliste = new List<Parkhaus>();

        //Getter Methode für die Fahrzeugliste definieren, damit Fahrzeuge ausgegeben werden können
        public List<Fahrzeug> Fahrzeugliste { get { return fahrzeugliste; } }

        public void neuenPKWAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aHubraum, String aLeistung, String aSchadstoffklasse)
        {
            int hubraum = 0;
            int leistung = 0;
            int schadstoffklasse = 0;

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
                fahrzeugliste.Add(pkw);
                stellplatzZuweisen(pkw);
            } catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public void neuenLKWAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aAchsenAnzahl, String aZuladung)
        {
            int achsenanzahl = 0;
            int zuladung = 0;

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
            fahrzeugliste.Add(lkw);
            stellplatzZuweisen(lkw);
        }

        public void neuesMotorradAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aHubraum)
        {
            int hubraum = 0;

            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            if (int.TryParse(aHubraum, out hubraum) == false || String.IsNullOrWhiteSpace(aHubraum))
            {
                throw new ArgumentException("Hubraum überprüfen");
            }

            //neuen PKW zur Liste hinzufügen hinzufügen
            Motorrad motorrad = new Motorrad(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aHubraum));
            fahrzeugliste.Add(motorrad);
            stellplatzZuweisen(motorrad);

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

        public void stellplatzZuweisen(Fahrzeug f)
        {
            bool abbruch = false;
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

        }
        private void ExceptionHandling(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis)
        {
            int erstzulassung = 0;
            float anschaffungspreis = 0;

            if (String.IsNullOrEmpty(aHersteller) || String.IsNullOrWhiteSpace(aHersteller))
            {
                throw new ArgumentException("Hersteller überprüfen");
            }
            if (String.IsNullOrEmpty(aModell) || String.IsNullOrWhiteSpace(aModell))
            {
                throw new ArgumentException("Modell überprüfen");
            }
            //Format angeben
            if (String.IsNullOrEmpty(aKennzeichen) || String.IsNullOrWhiteSpace(aKennzeichen))
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
        public List<String> gibAlleDatenAus()
        {
            string output = "{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-15}\t{5,-15}\t";
            List<String> alleFahrzeugDaten = new List<String>();
            alleFahrzeugDaten.Add(string.Format(output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassaung", "Anschaffungspreis", "Typ"));

            foreach (Fahrzeug fahrzeug in fahrzeugliste)
            {
                alleFahrzeugDaten.Add(string.Format(output, fahrzeug.Hersteller, fahrzeug.Modell, fahrzeug.Kennzeichen, fahrzeug.Erstzulassung.ToString(), fahrzeug.Anschaffungspreis.ToString(), fahrzeug.GetType()));
            }
            return alleFahrzeugDaten;
        }

        public void datenInDatenbankSichern()
        {
            OleDbCommand cmd;
            DataSet dataSet = new DataSet();
            Boolean entryExists = false;
            try
            {
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\anton\Documents\Fahrzeugverwaltung.mdb";


                foreach (Fahrzeug fa in fahrzeugliste)
                {
                    string fahrzeugtyp = fa.GetType().ToString();
                    string query = "Insert into Fahrzeugliste values('" + fa.Kennzeichen + "','" + fa.Hersteller + "','" + fa.Modell + "'," + fa.Erstzulassung + "," + fa.Anschaffungspreis + ",";
                    entryExists = false;

                        switch (fahrzeugtyp)
                        {
                            case "Fahrzeugverwaltung.PKW":
                                PKW pkw = fa as PKW;
                                query = query + pkw.Hubraum + "," + pkw.Leistung + "," + pkw.Schadstoffklasse + ",0,0,'" + pkw.GetType().ToString() + "');";
                                break;

                            case "Fahrzeugverwaltung.Motorrad":
                                Motorrad motorrad = fa as Motorrad;
                                query = query + motorrad.Hubraum + ",0,0,0,0,'" + motorrad.GetType().ToString() + "');";
                                break;

                            case "Fahrzeugverwaltung.LKW":
                                LKW lkw = fa as LKW;
                                query = query + "0,0,0," + lkw.Achsenanzahl + "," + lkw.Zuladung + ",'" + lkw.GetType().ToString() + "');";
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
                                if (kennzeichen.Equals(fa.Kennzeichen)) entryExists = true;
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


            string kennzeichen, hersteller, modell, typ;
            float anschaffungspreis;
            int hubraum, erstzulassung, leistung, schadstoffklasse, achsenanzahl, zuladung;

            string query = "SELECT kennzeichen, hersteller, modell, erstzulassung, anschaffungspreis, hubraum, leistung, schadstoffklasse, achsenanzahl, zuladung, typ FROM fahrzeugliste";

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

                            switch (typ)
                            {
                                case "Fahrzeugverwaltung.PKW":
                                    fahrzeugliste.Add(new PKW(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, hubraum, leistung, schadstoffklasse));
                                    break;

                                case "Fahrzeugverwaltung.Motorrad":
                                    fahrzeugliste.Add(new Motorrad(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, hubraum));
                                    break;

                                case "Fahrzeugverwaltung.LKW":
                                    fahrzeugliste.Add(new LKW(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, achsenanzahl, zuladung));
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
