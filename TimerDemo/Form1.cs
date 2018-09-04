using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace TimerDemo
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private Timer demoDispatcher;
        private Stopwatch timer;
        private DateTime lastDate;

        public Form1()
        {
            InitializeComponent();
            timer = new Stopwatch();
            lastDate = DateTime.Today;

            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(PauseTimer);
        }

        private void PauseTimer(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                timer.Stop();
            } else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                if (DateTime.Today != lastDate)
                {
                    lastDate = DateTime.Today;
                    timer.Restart();
                }
                else
                {
                    timer.Start();
                }
            }
            
            //MessageBox.Show("Paused");
            // e.Reason: Microsoft.Win32.SessionSwitchReason.SessionLock Microsoft.Win32.SessionSwitchReason.SessionUnlock, 
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) { e.Cancel = true; }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // doubleclicking the notifyIcon toggles between minimized or normal window
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

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Form1_MouseDown(sender, e);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Form1_MouseMove(sender, e);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            Form1_MouseUp(sender, e);
        }
        
        private void DispatcherTimerSetup()
        {
            demoDispatcher = new Timer();
            demoDispatcher.Tick += DemoDispatcher_Tick;
            demoDispatcher.Interval = 1; 
            demoDispatcher.Start();

            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DispatcherTimerSetup();
        }
        
        private void DemoDispatcher_Tick(object sender, object e)
        {
            if (DateTime.Today != lastDate)
            {
                lastDate = DateTime.Today;
                if (timer.IsRunning)
                {
                    timer.Restart();
                }
                else
                {
                    timer.Reset();
                }
            }
            timerDisplay.Text = timer.Elapsed.ToString(@"hh\:mm\:ss");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show (e.KeyCode.ToString());
            e.Handled = false;
        }
    }
} 
