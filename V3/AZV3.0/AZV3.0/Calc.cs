using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AZV3._0
{
    class Calc : Form
    {
        #region Variables

        JsonGeneral _jsonGeneral = new JsonGeneral();
        Log _log = new Log();
        DateTime _dt = DateTime.Now;
        private readonly string _path = @"C:\Users\uib13276\OneDrive - Vitesco Technologies\Dokumente\Daten 13276\99-Amin Sbahi\06-Programme\90-Arbeitszeit Rechner\V3\AZV3.0\AZV3.0\log.json";


        #endregion Variables

        #region Jsonstuff

        /// <summary>
        /// Log Class
        /// </summary>
        public class JsonGeneral
        {
            public JsonGeneral()
            {
                LogEntries = new List<Log>();
            }

            public List<Log> LogEntries { get; set; }
        }

        /// <summary>
        /// Log Class
        /// </summary>
        public class Log
        {
            /// <summary>
            /// Date of Logentry
            /// </summary>
            [JsonProperty("date")]
            public DateTime Date { get; set; }

            /// <summary>
            /// Arrivaltime to work
            /// </summary>
            [JsonProperty("time")]
            public DateTime Time { get; set; }
        }

        #endregion Jsonstuff

        #region Methods

        /// <summary>
        /// Making Calculations wanted
        /// </summary>
        /// <param name="KommenZeitTB">KommenZeit Text Box object</param>
        /// <param name="lbVAZ">Remaining Worktime Label object</param>
        /// <param name="gehenZeitTB">gehenZeit Text Box object</param>
        public void Logic(MaskedTextBox KommenZeitTB, Label lbVAZ, MaskedTextBox gehenZeitTB, Button btGo)
        {
            var kommenZeit = Convert.ToDateTime(KommenZeitTB.Text);
                DateTime Datetime = DateTime.Now;
            if (Datetime.DayOfWeek.ToString() != "Friday")
            {
                var gehenh = kommenZeit.AddHours(8.5).Hour.ToString();
                var gehenmin = kommenZeit.AddHours(8.5).Minute.ToString();
                if (gehenmin.Length == 1)
                { gehenmin = "0" + gehenmin; }
                var gehentime = gehenh + ":" + gehenmin;
                gehenZeitTB.Text = gehentime;
                var towork = (kommenZeit.AddHours(8.5) - Datetime.TimeOfDay).ToShortTimeString();
                lbVAZ.Text = towork;
            }
            else
            {
                var gehenh = kommenZeit.AddHours(7.75).Hour.ToString();
                var gehenmin = kommenZeit.AddHours(7.75).Minute.ToString();
                if (gehenmin.Length == 1)
                { gehenmin = "0" + gehenmin; }
                var gehentime = gehenh + ":" + gehenmin;
                gehenZeitTB.Text = gehentime;
                var towork = (kommenZeit.AddHours(7.75) - Datetime.TimeOfDay).ToShortTimeString();
                lbVAZ.Text = towork;
            }
            
        }

        /// <summary>
        /// JsonOP
        /// </summary>
        /// <param name="kommenZeit"></param>
        public void JsonOP(DateTime kommenZeit)
        {
            var strJSON = File.ReadAllText(_path);
            if (JsonConvert.DeserializeObject<JsonGeneral>(strJSON) != null)
            {
                _jsonGeneral = JsonConvert.DeserializeObject<JsonGeneral>(strJSON);
            }

            _log.Date = _dt.Date;
            _log.Time = kommenZeit;
            _jsonGeneral.LogEntries.Add(_log);

            var jsontowrite = JsonConvert.SerializeObject(_jsonGeneral);

            using (var writer = new StreamWriter(_path))
            {
                writer.Write(jsontowrite);
            }
        }

        /// <summary>
        /// Logic to be executed every minute (updating the lbVAZ)
        /// </summary>
        /// <param name="KommenZeitTB">KommenZeit Text Box object</param>
        /// <param name="lbVAZ">Remaining Worktime Label object</param>
        public void TickLogic(MaskedTextBox KommenZeitTB, Label lbVAZ)
        {
            if (KommenZeitTB.Text != " :")
            {
                var kommenZeit = Convert.ToDateTime(KommenZeitTB.Text);
                DateTime Datetime = DateTime.Now;
                if (Datetime.DayOfWeek.ToString() != "Friday") //wenn Montag - Donnerstag
                {
                    if (DateTime.Now.ToLocalTime() >= kommenZeit.AddHours(8.5)) //wenn nach benötigter AZ gib überstunden aus
                    {
                        var ÜS = (Datetime.ToLocalTime() - kommenZeit.AddHours(8.5));
                        lbVAZ.Text = ÜS.ToString();
                    }
                    else
                    {
                        var towork = (kommenZeit.AddHours(8.5) - Datetime.TimeOfDay).ToShortTimeString();
                        lbVAZ.Text = towork;
                    }
                }
                else
                {
                    if (DateTime.Now.ToLocalTime() >= kommenZeit.AddHours(7.75)) //wenn nach benötigter AZ gib überstunden aus
                    {
                        var ÜS = (Datetime.ToLocalTime() - kommenZeit.AddHours(7.75));
                        lbVAZ.Text = ÜS.ToString();
                    }
                    else
                    {
                        var towork = (kommenZeit.AddHours(7.75) - Datetime.TimeOfDay).ToShortTimeString();
                        lbVAZ.Text = towork;
                    }
                }
            }
            else
            {
                lbVAZ.Text = "Bitte Kommenzeit Eintragen";
            }
        }

        public void Test()
        {            
            var strJSON = File.ReadAllText(_path);
            if (JsonConvert.DeserializeObject<JsonGeneral>(strJSON) != null)
            {
                _jsonGeneral = JsonConvert.DeserializeObject<JsonGeneral>(strJSON);
            }

            var kommenzeit = Convert.ToDateTime("7:19");
            
            _log.Date = _dt.Date;
            _log.Time = kommenzeit;
            _jsonGeneral.LogEntries.Add(_log);

            var jsontowrite = JsonConvert.SerializeObject(_jsonGeneral);

            using(var writer = new StreamWriter(_path))
            {
                writer.Write(jsontowrite);
            }

            //auslesen aus der Json und in _generalJSON speichern
            strJSON = File.ReadAllText(_path);
            _jsonGeneral = JsonConvert.DeserializeObject<JsonGeneral>(strJSON);



            var idlast = _jsonGeneral.LogEntries.Count - 1;
            int n = 0;
            foreach(Log log in _jsonGeneral.LogEntries)
            { 
                Console.WriteLine(_jsonGeneral.LogEntries[n].Date.ToShortDateString() + " " + _jsonGeneral.LogEntries[n].Time.ToShortTimeString().Substring(1));
                n++;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Reads Json into _jsongeneral
        /// </summary>
        public void Read()
        {
            var strJSON = File.ReadAllText(_path);
            if (JsonConvert.DeserializeObject<JsonGeneral>(strJSON) != null)
            {
                _jsonGeneral = JsonConvert.DeserializeObject<JsonGeneral>(strJSON);
            }
        }

        /// <summary>
        /// Old Check
        /// </summary>
        /// <param name="KommenZeitTB">KommenZeit Textbox</param>
        /// <param name="lbVAZ">label verbleibende AZ</param>
        /// <param name="gehenZeitTB">gehenZeit Textbox</param>
        /// <param name="btGO">Button Go</param>
        public void Check(MaskedTextBox KommenZeitTB, Label lbVAZ, MaskedTextBox gehenZeitTB, Button btGO)
        {
            //read json
            var strJSON = File.ReadAllText(_path);
            if (JsonConvert.DeserializeObject<JsonGeneral>(strJSON) != null)
            {
                _jsonGeneral = JsonConvert.DeserializeObject<JsonGeneral>(strJSON);

                int id = _jsonGeneral.LogEntries.Count - 1;
                if (id < 0)
                {
                    id = 1;
                }

                if (_jsonGeneral.LogEntries[_jsonGeneral.LogEntries.Count - 1].Date.ToShortDateString() == _dt.ToShortDateString())
                {
                    KommenZeitTB.Text = _jsonGeneral.LogEntries[_jsonGeneral.LogEntries.Count - 1].Time.ToShortTimeString().Substring(1);
                    btGO.Enabled = false;
                    Logic(KommenZeitTB, lbVAZ, gehenZeitTB, btGO);
                }
            }
        }

        /// <summary>
        /// Check if today was checked in already
        /// </summary>
        /// <param name="KommenZeitTB">KommenZeit Textbox</param>
        /// <param name="lbVAZ">label verbleibende AZ</param>
        /// <param name="gehenZeitTB">gehenZeit Textbox</param>
        /// <param name="btGO">Button Go</param>
        /// <returns>if today was checked in already</returns>
        public bool Today(MaskedTextBox KommenZeitTB, Label lbVAZ, MaskedTextBox gehenZeitTB, Button btGO)
        {
            Read();

            if (_jsonGeneral.LogEntries[_jsonGeneral.LogEntries.Count - 1].Date.ToShortDateString() == _dt.ToShortDateString())
            {
                return true;
            }
            else
            {
                
                return false;
            }
        }

        /// <summary>
        /// True
        /// </summary>
        /// <param name="KommenZeitTB"></param>
        /// <param name="lbVAZ"></param>
        /// <param name="gehenZeitTB"></param>
        /// <param name="btGO"></param>
        public void True(MaskedTextBox KommenZeitTB, Label lbVAZ, MaskedTextBox gehenZeitTB, Button btGO)
        {
            var kommen = _jsonGeneral.LogEntries[_jsonGeneral.LogEntries.Count - 1].Time.ToShortTimeString();
            if(kommen.StartsWith("0"))
            {
                kommen = kommen.Substring(1);
            }

            KommenZeitTB.Text = kommen;
            Logic(KommenZeitTB, lbVAZ, gehenZeitTB, btGO);
        }

        /// <summary>
        /// false
        /// </summary>
        /// <param name="KommenZeitTB"></param>
        /// <param name="lbVAZ"></param>
        /// <param name="gehenZeitTB"></param>
        /// <param name="btGO"></param>
        public void False(MaskedTextBox KommenZeitTB, Label lbVAZ, MaskedTextBox gehenZeitTB, Button btGO)
        {
            _log.Date = _dt.Date;
            _log.Time = _dt;
            _jsonGeneral.LogEntries.Add(_log);

            var jsontowrite = JsonConvert.SerializeObject(_jsonGeneral);

            using (var writer = new StreamWriter(_path))
            {
                writer.Write(jsontowrite);
            }            
        }

        /// <summary>
        /// Updatin Progressbar
        /// </summary>
        /// <param name="progressBar">Progressbar</param>
        /// /// <param name="lbVAZ">Label Verbleibende Arbeitszeit</param>
        public void Bar(ProgressBar progressBar, Label lbVAZ)
        {
            var progress = 100 - (100 * Convert.ToInt32(lbVAZ.Text.Substring(0, 2) + lbVAZ.Text.Substring(3, 2))) / 850;
            progressBar.Value = progress;
        }

        #endregion Methods
    }
}