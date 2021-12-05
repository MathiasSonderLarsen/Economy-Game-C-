using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace economy_1
{
    public partial class Form1 : Form
    {

        Controller controller = new Controller();

        public Form1()
        {
            InitializeComponent();
            richTextBox1.AppendText(controller.OutputTown());
        }

        private void NextTurn(object sender, EventArgs e)
        {
            controller.turn();
            richTextBox1.AppendText(controller.OutputTown());
            richTextBox2.AppendText(controller.OutputLog());
            
        }
    }
}
