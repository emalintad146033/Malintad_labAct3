using System;
using System.Windows.Forms;

namespace Malintad_labAct3
{
    public partial class Form1 : Form
    {
        private int queueNumber = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // ADD TO QUEUE BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            string patientName = textBox1.Text.Trim();
            string reason = textBox2.Text.Trim();
            string ageText = textBox3.Text.Trim();
            string patientType = comboBox1.Text.Trim();

            // Check if all fields are filled
            if (patientName == "" ||
                ageText == "" ||
                reason == "" ||
                patientType == "")
            {
                MessageBox.Show(
                    "Please complete all patient information.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Check if age is a valid number
            if (!int.TryParse(ageText, out int age))
            {
                MessageBox.Show(
                    "Please enter a valid age using numbers only.",
                    "Invalid Age",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox3.Focus();
                return;
            }

            // Check age range
            if (age < 1 || age > 120)
            {
                MessageBox.Show(
                    "Please enter an age between 1 and 120.",
                    "Invalid Age",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox3.Focus();
                return;
            }

            // Increase queue number
            queueNumber++;

            // Create queue number
            string queueCode = "Q" + queueNumber.ToString("D3");

            // Determine expected priority
            string priority;

            if (patientType.Equals("Emergency", StringComparison.OrdinalIgnoreCase))
            {
                priority = "EMERGENCY";
            }
            else if (patientType.Equals("Pregnant", StringComparison.OrdinalIgnoreCase))
            {
                priority = "PRIORITY";
            }
            else if (patientType.Equals("Senior", StringComparison.OrdinalIgnoreCase))
            {
                priority = "SENIOR";
            }
            else if (age >= 60)
            {
                priority = "SENIOR";
            }
            else
            {
                priority = "REGULAR";
            }

            // Display queue number
            textBox4.Text = queueCode;

            // Display patient type
            textBox5.Text = patientType.ToUpper();

            // Display expected priority
            textBox6.Text = priority;

            // Display priority at the top
            comboBox2.Text = priority;

            MessageBox.Show(
                "Patient successfully added to the queue!\n\n" +
                "Queue Number: " + queueCode + "\n" +
                "Patient Name: " + patientName + "\n" +
                "Age: " + age + "\n" +
                "Reason for Visit: " + reason + "\n" +
                "Patient Type: " + patientType + "\n" +
                "Expected Priority: " + priority,
                "Queue Result",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // CLEAR BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";

            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }
    }
}