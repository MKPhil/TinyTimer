using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace TinyTimer
{ 
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private Timer WatchdogDispatcher;
        private Stopwatch timer;
        private DateTime lastDate;
        private bool appClosing;

        public Form1()
        {
            InitializeComponent();
            timer = new Stopwatch();
            lastDate = DateTime.Today;
            appClosing = false;

            // Watch for the session being locked/unlocked
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(PauseTimer);

            RegistryKey rk = Registry.CurrentUser.OpenSubKey ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("TinyTimer", Application.ExecutablePath);
        }

        private void PauseTimer(object sender, SessionSwitchEventArgs e)
        {
             // Stop the timer when the session is locked
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                timer.Stop();
            } else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                // Restart the timer when unlocked
                if (DateTime.Today != lastDate)
                {
                    // If it is a new day then start from 0
                    lastDate = DateTime.Today;
                    timer.Restart();
                }
                else
                {
                    // otherwise just restart it
                    timer.Start();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // If given our secret key combination Shift+Alt+Ctrl+F12, then close the app
            if (e.Alt && e.Shift && e.Control && (e.KeyCode == Keys.F12))
            {
                appClosing = true;
                Close();
            }
            e.Handled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Block closing the app with usual means
            if (e.CloseReason == CloseReason.UserClosing && !appClosing) { e.Cancel = true; }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Double Clicking the notifyIcon toggles between minimized or normal window
            if (this.WindowState == FormWindowState.Minimized)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                Hide();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        // Capture mouse Down, Move and Up events on the form and label to enable window dragging
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            Form1_MouseDown(sender, e);
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            Form1_MouseMove(sender, e);
        }

        private void Label1_MouseUp(object sender, MouseEventArgs e)
        {
            Form1_MouseUp(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start two timers when the form loads. WatchdogDispatcher checks the elapsed session time and displays it
            WatchdogDispatcher = new Timer();
            WatchdogDispatcher.Tick += WatchdogDispatcher_Tick;
            WatchdogDispatcher.Interval = 1;
            WatchdogDispatcher.Start();

            // timer is a Stopwatch which contains the elapsed session time and is stoppable and restartable
            timer.Start();
        }

        // Runs every tick of the WatchdogDispatcher timer
        private void WatchdogDispatcher_Tick(object sender, object e)
        {
            // Checks for date rollover
            if (DateTime.Today != lastDate)
            {
                // Store the new date
                lastDate = DateTime.Today;
                // If the timer is running, restart it from 0, otherwise reset it to 0 and leave it stopped
                if (timer.IsRunning)
                {
                    timer.Restart();
                }
                else
                {
                    timer.Reset();
                }
            }

            // Display the elapsed time in the text box on the form in the correct format
            timerDisplay.Text = timer.Elapsed.ToString(@"hh\:mm\:ss");
        }
    }
} 
