using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grade_Computation_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ================= SAFE INPUT =================
        double GetValue(TextBox txt)
        {
            try
            {
                return Convert.ToDouble(txt.Text);
            }
            catch
            {
                return 0;
            }
        }

        // ================= PRELIM =================
        double ComputePrelim()
        {
            TextBox[] classPerf =
            {
                txtPrelimA1Score, txtPrelimA2Score,
                txtPrelimS1Score, txtPrelimS2Score,
                txtPrelimR1Score, txtPrelimR2Score
            };

            double sum = 0;

            for (int i = 0; i < classPerf.Length; i++)
            {
                sum += GetValue(classPerf[i]);
            }

            double classPerfAvg = (sum / classPerf.Length) * 0.10;

            double lab = (GetValue(txtPrelimL1Score) + GetValue(txtPrelimL2Score)) / 2 * 0.10;

            double quiz = (
                GetValue(txtPrelimQ1Score) +
                GetValue(txtPrelimQ2Score) +
                GetValue(txtPrelimQ3Score)
            ) / 3 * 0.20;

            double labExam = (
                GetValue(txtPrelimLE1Score) +
                GetValue(txtPrelimLE2Score)
            ) / 2 * 0.20;

            double written = GetValue(txtPrelimEScore) * 0.40;

            return classPerfAvg + lab + quiz + labExam + written;
        }

        // ================= MIDTERM =================
        double ComputeMidterm()
        {
            TextBox[] classPerf =
            {
                txtMidtermA1Score, txtMidtermA2Score,
                txtMidtermS1Score, txtMidtermS2Score,
                txtMidtermR1Score, txtMidtermR2Score
            };

            double sum = 0;

            for (int i = 0; i < classPerf.Length; i++)
            {
                sum += GetValue(classPerf[i]);
            }

            double classPerfAvg = (sum / classPerf.Length) * 0.10;

            double lab = (GetValue(txtMidtermL1Score) + GetValue(txtMidtermL2Score)) / 2 * 0.10;

            double quiz = (
                GetValue(txtMidtermQ1Score) +
                GetValue(txtMidtermQ2Score) +
                GetValue(txtMidtermQ3Score)
            ) / 3 * 0.20;

            double labExam = (
                GetValue(txtMidtermLE1Score) +
                GetValue(txtMidtermLE2Score)
            ) / 2 * 0.20;

            double written = GetValue(txtMidtermEScore) * 0.40;

            return classPerfAvg + lab + quiz + labExam + written;
        }

        // ================= FINALS =================
        double ComputeFinals()
        {
            TextBox[] classPerf =
            {
                txtFinalsA1Score, txtFinalsA2Score,
                txtFinalsS1Score, txtFinalsS2Score,
                txtFinalsR1Score, txtFinalsR2Score
            };

            double sum = 0;

            for (int i = 0; i < classPerf.Length; i++)
            {
                sum += GetValue(classPerf[i]);
            }

            double classPerfAvg = (sum / classPerf.Length) * 0.05;

            double lab = (GetValue(txtFinalsL1Score) + GetValue(txtFinalsL2Score)) / 2 * 0.10;

            double quiz = (
                GetValue(txtFinalsQ1Score) +
                GetValue(txtFinalsQ2Score) +
                GetValue(txtFinalsQ3Score)
            ) / 3 * 0.20;

            double project = (
                GetValue(txtFinalsPScore) +
                GetValue(txtFinalsMScore)
            ) / 2 * 0.25;

            double written = GetValue(txtFinalsEScore) * 0.40;

            return classPerfAvg + lab + quiz + project + written;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox86_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Control[] ctrls = this.Controls.Find("", true);

            for (int i = 0; i < ctrls.Length; i++)
            {
                if (ctrls[i] is TextBox)
                {
                    ctrls[i].Text = "";
                }
            }
        }

        void ClearTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
                else
                    ClearTextBoxes(c);
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                double prelim = ComputePrelim();
                double midterm = ComputeMidterm();
                double finals = ComputeFinals();

                txtPrelimGrade.Text = prelim.ToString("0.00");
                txtMidtermGrade.Text = midterm.ToString("0.00");
                txtFinalsGrade.Text = finals.ToString("0.00");

                double finalGrade = (prelim * 0.30) + (midterm * 0.30) + (finals * 0.40);

                txtFInalComputedGrade.Text = finalGrade.ToString("0.00");

                // IF-ELSE + NESTED IF
                if (finalGrade >= 75)
                {
                    if (finalGrade >= 90)
                    {
                        MessageBox.Show("Excellent! High grade!");
                    }
                    else
                    {
                        MessageBox.Show("Passed!");
                    }
                }
                else
                {
                    MessageBox.Show("Failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void ComputeGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
