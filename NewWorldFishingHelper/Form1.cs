using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace NewWorldFishingHelper
{
    public partial class Form1 : Form
    {
        int timeout = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            searchForFish();


        }

        private void searchForFish() {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            bitmap.Save(@"C:\Temp\printscreen.png", ImageFormat.Jpeg);


            Boolean encontrou = new Boolean();

            //Bitmap bitmap1 = (Bitmap)Bitmap.FromFile(@"C:\Temp\5.png");

            Bitmap HOLDCAST = (Bitmap)Bitmap.FromFile(@"C:\Temp\HOLDCAST.png");
            Bitmap READY = (Bitmap)Bitmap.FromFile(@"C:\Temp\READY.png");
            Bitmap HOOK = (Bitmap)Bitmap.FromFile(@"C:\Temp\hook.png");
            Bitmap PULLSAFE = (Bitmap)Bitmap.FromFile(@"C:\Temp\pullsafe.png");
            Bitmap PULLSAFE2 = (Bitmap)Bitmap.FromFile(@"C:\Temp\pullsafe4.png");
            Bitmap PULLRED = (Bitmap)Bitmap.FromFile(@"C:\Temp\PULLRED.png");



            Bitmap Screenshot = (Bitmap)Bitmap.FromFile(@"C:\Temp\printscreen.png");
           
            Rectangle location = Rectangle.Empty;
        
            double tolerance = Convert.ToDouble(toleranceTrackBar.Value) / 100.0;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (textBox1.Text == "HOLDCAST" || textBox1.Text == "NOTHING FOUND") {
                //////////////////////////////////////HOLDCAST/////////////////////////////////////////
                location = ImageRec.searchBitmap(HOLDCAST, Screenshot, tolerance);

                if (location.Width != 0)
                {
                    label7.Text = "HOLDCAST found in " + stopWatch.ElapsedMilliseconds + " ms.";
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 200);
                    textBox1.Text = "HOLDCAST";
                    
                }
                else
                {
                    label8.Text = "HOLDCAST not found.";

                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////
           
            ///   //////////////////////////////////////READY/////////////////////////////////////////
            if (textBox1.Text == "HOLDCAST")
            {
                location = ImageRec.searchBitmap(READY, Screenshot, tolerance);

                if (location.Width != 0)
                {
                    label7.Text = "READY found in " + stopWatch.ElapsedMilliseconds + " ms.";
                    textBox1.Text = "REEL IN";
                    System.Threading.Thread.Sleep(900);
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 5500);
                    System.Threading.Thread.Sleep(800);
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 1700);
                    System.Threading.Thread.Sleep(800);
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 1800);
                    System.Threading.Thread.Sleep(900);
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 1800);
                    System.Threading.Thread.Sleep(800);
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 1800);
                    System.Threading.Thread.Sleep(800);
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 1500);
                    System.Threading.Thread.Sleep(800);
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 1500);
                    System.Threading.Thread.Sleep(900);
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 1500);
                    System.Threading.Thread.Sleep(900);
                }
                else
                {
                    label8.Text = "READY not found.";

                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////HOOK/////////////////////////////////////////
           // if (textBox1.Text == "READY")
           // {
           //     location = ImageRec.searchBitmap(HOOK, bitmap2, tolerance);

           //     if (location.Width != 0)
           //     {
           //         label7.Text = "HOOK found in " + stopWatch.ElapsedMilliseconds + " ms.";
          //          Clickarino.leftClick(new Point(location.X, location.Y));
          //          textBox1.Text = "REEL IN";
          //          //widthTextBox.Text = bitmap1.Width.ToString();
          //          //heightTextBox.Text = bitmap1.Height.ToString();
          //      }
          //      else
          // /     {
          //         label8.Text = "HOOK not found.";

            //    }
            //}
            ////////////////////////////////////////////////////////////////////////////////////////
            ///
            //////////////////////////////////////REEL IN/////////////////////////////////////////
            if (textBox1.Text == "REEL IN") { 
            location = ImageRec.searchBitmap(PULLSAFE, Screenshot, tolerance);

            if (location.Width != 0)
            {
                    label7.Text = "REEL IN found in " + stopWatch.ElapsedMilliseconds + " ms.";
                    timeout = 0;
                    textBox1.Text = "REEL IN";
                    
                    Clickarino.holDownLeft(new Point(location.X, location.Y),2000);
                }
            else
            {
                    label8.Text = "REEL not found.";

            }
        }
            ////////////////////////////////////////////////////////////////////////////////////////
            ///

            //////////////////////////////////////REEL IN/////////////////////////////////////////
            if (textBox1.Text == "REEL IN")
            {
                location = ImageRec.searchBitmap(PULLSAFE2, Screenshot, tolerance);

                if (location.Width != 0)
                {
                    label7.Text = "REEL IN found in " + stopWatch.ElapsedMilliseconds + " ms.";
                    timeout = 0;
                    textBox1.Text = "REEL IN";
                    
                    Clickarino.holDownLeft(new Point(location.X, location.Y), 2000);
                }
                else
                {
                    label8.Text = "REEL not found.";

                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////REEL RED STOP IN/////////////////////////////////////////
            if (textBox1.Text == "REEL IN")
            {
                location = ImageRec.searchBitmap(PULLRED, Screenshot, tolerance);

                if (location.Width != 0)
                {
                    label7.Text = "REEL RED STOP! found in " + stopWatch.ElapsedMilliseconds + " ms.";
                    timeout = 0;
                    textBox1.Text = "REEL IN";
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    label8.Text = "REEL not found.";

                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////

            if (textBox1.Text == "REEL IN" && label8.Text == "REEL not found.") {
                timeout++;
                label2.Text = "Timeout :" + timeout.ToString();
           }

            if (timeout > 20) {
                textBox1.Text = "HOLDCAST";
            }

            stopWatch.Stop();
            HOLDCAST.Dispose();
            HOOK.Dispose();
            PULLSAFE.Dispose();
            Screenshot.Dispose();
            bitmap.Dispose();
           




        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            button1.Text = timer1.Enabled.ToString();
            searchForFish();
        }





}
}
