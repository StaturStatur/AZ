using System;
using System.Windows.Forms;

namespace AZV3._0
{
    public partial class Arbeitszeit : Form
    {
        #region Variables

        /// <summary>
        /// Inizializing Class Clac for this Class
        /// </summary>
        Calc _calc = new Calc();

        #endregion Variables

        #region Methods

        /// <summary>
        /// Initzializing Form1
        /// </summary>
        public Arbeitszeit()
        {
            InitializeComponent();
            gehenZeitTB.TextAlign = HorizontalAlignment.Center;
            KommenZeitTB.TextAlign = HorizontalAlignment.Center;
            progressBar.Maximum = 100;
        }

        /// <summary>
        /// Exit Programm
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Execute Calulations on Button Press "Go"
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void btGo_Click(object sender, EventArgs e)
        {
            _calc.Logic(KommenZeitTB, lbVAZ, gehenZeitTB, btGo);
        }

        /// <summary>
        /// Everything that needs to happen at load
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void Arbeitszeit_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer
            {
                Interval = (60 * 1000) // 60 secs (ms und so)
            };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            //get if Arrivaltime was given today already, if yes use this time for calc
            if (_calc.Today(KommenZeitTB,lbVAZ,gehenZeitTB,btGo) == true)
            {
                _calc.True(KommenZeitTB, lbVAZ, gehenZeitTB, btGo);
            }
            else
            {
                _calc.False(KommenZeitTB, lbVAZ, gehenZeitTB, btGo);
            }
        }

        /// <summary>
        /// Updating TimetoWork every Minute
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void Timer_Tick(object sender, EventArgs e)
        {
            _calc.TickLogic(KommenZeitTB, lbVAZ);

            _calc.Bar(progressBar, lbVAZ);
        }

        /// <summary>
        /// Calculating everything on "Enter" button press
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void KommenZeitTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _calc.Logic(KommenZeitTB, lbVAZ, gehenZeitTB,btGo);
            }
        }

        #endregion Methods
    }
}