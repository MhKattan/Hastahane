using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;

namespace hastakayit
{
    public partial class hastalik : Form
    {
        public hastalik()
        {
            InitializeComponent();
        }

        kutuphane veri=new kutuphane();
        private void hastalik_Load(object sender, EventArgs e)
        {
            veri.openconnection();
            doldur();
        }

        private void hastalik_FormClosing(object sender, FormClosingEventArgs e)
        {
            veri.closeconnection();
        }
        private void doldur()
        {
            dataGridView1.DataSource = veri.doldur("select *from hastalik");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle="insert into hastalik (hastalik_adi)values('"+textBox1.Text+"')";
            veri.crud(cumle);
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen Listeden Seçim Yapınız");
            }
            else
            {
                string cumle = "update hastalik set hastalik_adi='" + textBox1.Text + "' where Id='" + textBox2.Text + "'";
                veri.crud(cumle);
                doldur();
            }
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int secim = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Bu Kaydı Silmek İstiyor musunuz", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                string cumle = "delete from hastalik where Id='" + textBox2.Text + "'";
                veri.crud(cumle);
                doldur();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ara = Interaction.InputBox("Hastalık Adını Girin");
            string cumle = "Select * from hastalik where hastalik_adi='" + ara + "'";
            dataGridView1.DataSource = veri.doldur(cumle);
        }
    }
}
