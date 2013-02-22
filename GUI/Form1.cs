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
            trackGrowth.Enabled = false;
            trackReproduction.Enabled = false;
            trackMutation.Enabled = false;
            txtSeed.Enabled = false;
            cmbCrossover.Enabled = false;


            int seed = (txtSeed.Text.Length == 0) ? -1 : txtSeed.Text.GetHashCode();
            int reproduction = trackReproduction.Value;
            int mutation = trackMutation.Value;
            int growth = trackGrowth.Value;

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
                trackGrowth.Enabled = true;
                trackReproduction.Enabled = true;
                trackMutation.Enabled = true;
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
            trackReproduction.Value = 89;
            trackMutation.Value = 4;
            trackGrowth.Value = 50;

            lblRepRate.Text = trackReproduction.Value + "%";
            lblMutRate.Text = trackMutation.Value + "%";
            lblGrowRate.Text = trackGrowth.Value + "%";

            cmbCrossover.Items.Add(new ComboboxItem("One-Point Crossover", "ONE_POINT"));
            cmbCrossover.Items.Add(new ComboboxItem("Multi-Point Crossover", "MULTI_POINT"));
            cmbCrossover.SelectedIndex = 0;
        }

        private void trackReproduction_Scroll(object sender, EventArgs e)
        {
            lblRepRate.Text = trackReproduction.Value + "%";
        }

        private void trackMutation_Scroll(object sender, EventArgs e)
        {
            lblMutRate.Text = trackMutation.Value + "%";
        }

        private void trackGrowth_Scroll(object sender, EventArgs e)
        {
            lblGrowRate.Text = trackGrowth.Value + "%";
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
