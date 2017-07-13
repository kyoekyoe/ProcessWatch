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
using System.Runtime.InteropServices;
namespace ProcessWatch
{
    public partial class Form1 : Form
    {
        string startName = "StartProcessname";
        string backprocessName = "StartProcessname";
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            IntPtr hWnd = GetForegroundWindow();
            int id;
            GetWindowThreadProcessId(hWnd, out id);
            string answer;
            answer = Process.GetProcessById(id).MainWindowTitle;
            MessageBox.Show(answer);
        }
    }
}
