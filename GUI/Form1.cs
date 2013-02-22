using Evolution;
using Evolution.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            txtGrowth.Enabled = false;
            txtMutation.Enabled = false;
            txtReproduction.Enabled = false;
            txtSeed.Enabled = false;
            cmbCrossover.Enabled = false;

            int seed = int.Parse(txtSeed.Text);
            int reproduction = int.Parse(txtReproduction.Text);
            int mutation = int.Parse(txtMutation.Text);
            int growth = int.Parse(txtGrowth.Text);

            Params pa = new Params(seed, reproduction, mutation, ((ComboboxItem)cmbCrossover.SelectedItem).Value.ToString(), growth);
            string xml = Serialiser.Serialise<Params>(pa);
            StreamWriter file = new System.IO.StreamWriter("./params.xml");
            file.WriteLine(xml);

            file.Close();

            try
            {

                Process firstProc = new Process();
                firstProc.StartInfo.FileName = Application.StartupPath + "/Evolution.exe";
                firstProc.EnableRaisingEvents = true;

                firstProc.Start();

                firstProc.WaitForExit();

                btnStart.Enabled = true;
                txtGrowth.Enabled = true;
                txtMutation.Enabled = true;
                txtReproduction.Enabled = true;
                txtSeed.Enabled = true;
                cmbCrossover.Enabled = true;
                btnStart.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred!!!: " + ex.Message);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            cmbCrossover.Items.Add(new ComboboxItem("One-Point Crossover", "ONE_POINT"));
            cmbCrossover.Items.Add(new ComboboxItem("Multi-Point Crossover", "MULTI_POINT"));
            cmbCrossover.SelectedIndex = 0;
        }
    }
}

public class ComboboxItem
{
    public string Text { get; set; }
    public object Value { get; set; }

    public ComboboxItem(string text, object value)
    {
        this.Text = text;
        this.Value = value;
    }

    public override string ToString()
    {
        return Text;
    }
}
