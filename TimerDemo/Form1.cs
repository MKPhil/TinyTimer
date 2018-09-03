using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TimerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Escape)
            //    Close();
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

        //Let's not make things any more difficult than they need to be. I've come across so many snippets of code that allow you to drag a form around(or another Control). And many of them have their own drawbacks/side effects.Especially those ones where they trick Windows into thinking that a Control on a form is the actual form.
        //That being said, here is my snippet. I use it all the time. I'd also like to note that you should not use this.Invalidate(); as others like to do because it causes the form to flicker in some cases. And in some cases so does this.Refresh. Using this.Update, I have not had any flickering issues:
        //https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        private bool mouseDown;
        private Point lastLocation;

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


        //private DispatcherTimer demoDispatcher;
        private int timesTicked = 1;
        private double ProgressAmount = 0;
        private int sec = 0;
        private int min = 0;
        private int hour = 0;

        private DateTime startedTime;
        private TimeSpan timePassed, timeSinceLastStop;

        private Stopwatch timer;
        //= new Stopwatch();

       // public MainPage()
        //{
        //    this.InitializeComponent();
        //    timer = new Stopwatch();
       // }

        //bool isStop = false;
        //private void Start_Click(object sender, RoutedEventArgs e)
       // {
        //    if (isStop == false)
         //   {
          //      isStop = true;
           //     startedTime = DateTime.Now;
            //    DispatcherTimerSetup();

                //                Start.Content = "Stop";

             //   timer.Start();
        //    }
          //  else
            //{
              //  isStop = false;
                //dispatcherTimer.Stop();
               // demoDispatcher.Stop();
                //Hour.Text = "00:00:00";
                //                  Start.Content = "Start";

                //timer.Stop();
           //     UsageTime.Text = timer.Elapsed.ToString();
            //}
        //}

        //protected override void OnNavigatedTo(NavigationEventArgs e)
       // {
         //   base.OnNavigatedTo(e);

       // }

        private void DispatcherTimerSetup()
        {
            timeSinceLastStop = TimeSpan.Zero;
            //Hour.Text = "00:00:00";
            //demoDispatcher = new DispatcherTimer();
            //demoDispatcher.Tick += DemoDispatcher_Tick;
            //demoDispatcher.Interval = new TimeSpan(0, 0, 0, 0, 1);
            //demoDispatcher.Start();

            //timer.interval
            timer.Start();
        }

        //private void Page_Loaded(object sender, RoutedEventArgs e)
       // {
       //     isStop = true;
       //     startedTime = DateTime.Now;
       //     DispatcherTimerSetup();

            //                Start.Content = "Stop";
        //}

        private string MakeDigitString(int number, int count)
        {
            string result = "0";
            if (count == 2)
            {
                if (number < 10)
                    result = "0" + number;
                else
                    result = number.ToString();
            }
            else if (count == 3)
            {
                if (number < 10)
                    result = "00" + number;
                else if (number > 9 && number < 100)
                {
                    result = "0" + number;
                }
                else
                    result = number.ToString();
            }
            return result;
        }

        private void DemoDispatcher_Tick(object sender, object e)
        {
            timePassed = DateTime.Now - startedTime;
        //    Hour.Text = MakeDigitString((timeSinceLastStop + timePassed).Hours, 2) + ":"
        //        + MakeDigitString((timeSinceLastStop + timePassed).Minutes, 2) + ":"
        //        + MakeDigitString((timeSinceLastStop + timePassed).Seconds, 2);
            //+":"
            //+ MakeDigitString((timeSinceLastStop + timePassed).Milliseconds,3);
            timerDisplay.Text = timer.Elapsed.ToString();
        }



        private void dispatcherTimer_Tick(object sender, object e)
        {
            timesTicked++;

            ProgressAmount += (1.0 / 60.0) * (7.95 / 60.0);
            if (ProgressAmount > 1.0)
                ProgressAmount = 0.0;
        }
    }

}

    
