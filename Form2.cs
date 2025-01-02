using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstV1
{
    public partial class CodeFirst : Form
    {
        public CodeFirst()
        {
            InitializeComponent();
        }
        UrunlerContext db = new UrunlerContext();
        private void Form2_Load(object sender, EventArgs e)
        {
            SehirVeCinsiyet();

            dataGridView1.DataSource = db.Musteris.OrderByDescending(a => a.MusteriAd).ToList();
        }
        void SehirVeCinsiyet()
        {
            comboBox2.DataSource = db.Sehirs.Select(x => new
            {
                x.SehirID,
                x.SehirAdi
            }).ToList();
            comboBox2.DisplayMember = "SehirAdi";
            comboBox2.ValueMember = "SehirID";
            comboBox1.Items.Add("Erkek");
            comboBox1.Items.Add("Kadın");
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.MusteriAd = textBox1.Text;
            m.Soyad = textBox2.Text;
            m.Cinsiyet = comboBox1.SelectedItem.ToString();
            m.Gelir = int.Parse(textBox3.Text);
            m.Meslek = textBox4.Text;
            var selectedSehir = (dynamic)comboBox2.SelectedItem;
            m.Sehir = selectedSehir.SehirAdi;
            m.Yas = int.Parse(textBox5.Text);

            db.Musteris.Add(m);
            db.SaveChanges();

            dataGridView1.DataSource = db.Musteris.OrderByDescending(a => a.MusteriAd).ToList();
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Seçili satırdaki hücrelere erişim
                DataGridViewRow row = dataGridView1.CurrentRow;

                Musteri musteri = new Musteri
                {
                    MusteriAd = row.Cells["MusteriAd"].Value.ToString(),
                    Soyad = row.Cells["Soyad"].Value.ToString(),
                    Cinsiyet = row.Cells["Cinsiyet"].Value.ToString(),
                    Gelir = Convert.ToDecimal(row.Cells["Gelir"].Value),
                    Meslek = row.Cells["Meslek"].Value.ToString(),
                    Sehir = row.Cells["Sehir"].Value.ToString(), // Sadece SehirAdi
                    Yas = Convert.ToInt32(row.Cells["Yas"].Value)
                };

                textBox1.Text = musteri.MusteriAd;
                textBox2.Text = musteri.Soyad;
                comboBox1.Text = musteri.Cinsiyet;
                textBox3.Text = musteri.Gelir.ToString();
                textBox4.Text = musteri.Meslek;
                comboBox2.Text = musteri.Sehir; // Sadece SehirAdi
                textBox5.Text = musteri.Yas.ToString();
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            var m = db.Musteris.Find(dataGridView1.CurrentRow.Cells[0].Value);
            m.MusteriAd = textBox1.Text;
            m.Soyad = textBox2.Text;
            m.Cinsiyet = comboBox1.SelectedItem.ToString();
            var gelir = textBox3.Text.Split(',')[0];
            m.Gelir = int.Parse(gelir);
            m.Meslek = textBox4.Text;
            var selectedSehir = (dynamic)comboBox2.SelectedItem;
            m.Sehir = selectedSehir.SehirAdi;
            m.Yas = int.Parse(textBox5.Text);

            db.SaveChanges();

            MessageBox.Show("Güncelleme Başarılı!");

            dataGridView1.DataSource = db.Musteris.OrderByDescending(a => a.MusteriAd).ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Musteri sil = db.Musteris.Find(dataGridView1.CurrentRow.Cells[0].Value);
            db.Musteris.Remove(sil);
            db.SaveChanges();

            dataGridView1.DataSource = db.Musteris.OrderByDescending(a => a.MusteriAd).ToList();
        }
    }
}
