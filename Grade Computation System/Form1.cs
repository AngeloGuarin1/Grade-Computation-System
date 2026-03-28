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

        double GetValue(TextBox txt)
        {
            double val;
            return double.TryParse(txt.Text, out val) ? val : 0;
        }

        // ===================== PRELIM =====================
        double ComputePrelim()
        {
            double classPerf = (
                GetValue(txtPrelimA1Score) +
                GetValue(txtPrelimA2Score) +
                GetValue(txtPrelimS1Score) +
                GetValue(txtPrelimS2Score) +
                GetValue(txtPrelimR1Score) +
                GetValue(txtPrelimR2Score)
            ) / 6 * 0.10;

            double lab = (
                GetValue(txtPrelimL1Score) +
                GetValue(txtPrelimL2Score)
            ) / 2 * 0.10;

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

            return classPerf + lab + quiz + labExam + written;
        }

        // ===================== MIDTERM =====================
        double ComputeMidterm()
        {
            double classPerf = (
                GetValue(txtMidtermA1Score) +
                GetValue(txtMidtermA2Score) +
                GetValue(txtMidtermS1Score) +
                GetValue(txtMidtermS2Score) +
                GetValue(txtMidtermR1Score) +
                GetValue(txtMidtermR2Score)
            ) / 6 * 0.10;

            double lab = (
                GetValue(txtMidtermL1Score) +
                GetValue(txtMidtermL2Score)
            ) / 2 * 0.10;

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

            return classPerf + lab + quiz + labExam + written;
        }

        // ===================== FINALS =====================
        double ComputeFinals()
        {
            double classPerf = (
                GetValue(txtFinalsA1Score) +
                GetValue(txtFinalsA2Score) +
                GetValue(txtFinalsS1Score) +
                GetValue(txtFinalsS2Score) +
                GetValue(txtFinalsR1Score) +
                GetValue(txtFinalsR2Score)
            ) / 6 * 0.05;

            double lab = (
                GetValue(txtFinalsL1Score) +
                GetValue(txtFinalsL2Score)
            ) / 2 * 0.10;

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

            return classPerf + lab + quiz + project + written;
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
            foreach (Control c in this.Controls)
                ClearTextBoxes(c);
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
            double prelim = ComputePrelim();
            double midterm = ComputeMidterm();
            double finals = ComputeFinals();

            txtPrelimGrade.Text = prelim.ToString("0.00");
            txtMidtermGrade.Text = midterm.ToString("0.00");
            txtFinalsGrade.Text = finals.ToString("0.00");

            double finalGrade = (prelim * 0.30) + (midterm * 0.30) + (finals * 0.40);
            txtFInalComputedGrade.Text = finalGrade.ToString("0.00");
        }

        private void ComputeGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
