using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using FlaUI.Core.AutomationElements;
using System.Runtime.ConstrainedExecution;

namespace BlumClicker
{
    public partial class Form1 : Form
    {
        FlaUIHelper blumFUI;
        private List<Color> colorsBlue;
        private List<Color> colorsGreen;

        #region RegisterHotKey
        // Константы для модификаторов клавиш
        private const int MOD_NONE = 0x0; // Без модификаторов
        private const int WM_HOTKEY = 0x0312; // Сообщение для горячей клавиши

        // Регистрация функции WinAPI для глобальных горячих клавиш
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void WndProc(ref Message m)
        {
            // Проверяем, если это сообщение о горячей клавише
            if (m.Msg == WM_HOTKEY)
            {
                // Обработка нажатия горячей клавиши
                int id = m.WParam.ToInt32();
                if (id == 1) // Если это наша зарегистрированная горячая клавиша
                {
                    timer1.Stop();
                    buttonStart.Text = "Запустить";
                }
            }
            base.WndProc(ref m);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, 1, MOD_NONE, (int)Keys.Pause);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
        }

        #endregion

        public Form1()
        {

            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorsBlue = new List<Color>();
            colorsGreen = new List<Color>();

            colorsBlue.Add(ColorTranslator.FromHtml("#82DCE9"));
            colorsBlue.Add(ColorTranslator.FromHtml("#82DCE8"));
            colorsBlue.Add(ColorTranslator.FromHtml("#83DDE9"));
            colorsBlue.Add(ColorTranslator.FromHtml("#5FCFDF"));
            colorsGreen.Add(ColorTranslator.FromHtml("#CDDC00"));
            colorsGreen.Add(ColorTranslator.FromHtml("#E4F47C"));

            if (radioButtonLD.Checked)
            {
                blumFUI = new FlaUIHelper("LDPlayer");
                blumFUI.WindowFocus();
            }
            else if(radioButtonDesktop.Checked)
            {
                blumFUI = new FlaUIHelper("Telegram.exe", "Qt51513QWindow");
                blumFUI.WindowFocus();
            }


            if (timer1.Enabled)
            {
                buttonStart.Text = "Запустить";
                timer1.Stop();
            }
            else
            {
                buttonStart.Text = "Остановить";
                timer1.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap screen = blumFUI.WindowCapture();
            
            BitmapHelper bmh = new BitmapHelper(screen);
            Point pBlue = bmh.SearchPixel(colorsBlue);
            if (pBlue != Point.Empty)
                blumFUI.WindowMouseClick(pBlue);

            screen = blumFUI.WindowCapture();

            bmh = new BitmapHelper(screen);
            Point pGreen = bmh.SearchPixel(colorsGreen);
            if (pGreen != Point.Empty)
                blumFUI.WindowMouseClick(pGreen);

            bmh = new BitmapHelper(screen);

            if (radioButtonLD.Checked)
            {
                if (bmh.IsPixelColor(new Point(28, 890), Color.FromArgb(255, 255, 255)))
                {
                    blumFUI.WindowMouseClick(new Point(246, 910)); ;
                    Thread.Sleep(200);
                }
            }
            else if (radioButtonDesktop.Checked)
            {
                if (bmh.IsPixelColor(new Point(70, 750), Color.FromArgb(255, 255, 255)))
                {
                    blumFUI.WindowMouseClick(new Point(240, 760)); ;
                    Thread.Sleep(200);
                }
            }


        }
    }
}
