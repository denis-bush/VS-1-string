using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Считывание строки из файла
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                StreamReader fs = new StreamReader(openFileDialog.FileName, Encoding.Default);
                richTextBox1.Text = fs.ReadToEnd();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Файл не найден");
            }
            catch (FileLoadException ex)
            {
                MessageBox.Show("Не удалось обработать файл");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
            
        }

        // Обработка полученной строки и вывод результатов
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string s = richTextBox1.Text;
                string[] a = s.Split(',', ' ', '.', ';').ToArray();
                int max = 0, k = 0;
                string maxs = "";
                for (int i = 0; i < a.Count(); i++)
                    if (a[i].Length > max) { max = a[i].Length; maxs = a[i]; }
                for (int i = 0; i < a.Count(); i++)
                    if (a[i] == maxs) k++;
                tbNum.Text = k.ToString();
                tbWord.Text = maxs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректный ввод");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Сохранение результатов во внешний файл
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {

                if (File.Exists(dlgSaveFile.FileName))
                {
                    if (MessageBox.Show(this, "Файл существует. Желаете ли Вы добавить данные в файл?", "Добавление данных в файл", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                }

                File.AppendAllText(dlgSaveFile.FileName, "Исходный текст: \r\n");
                File.AppendAllText(dlgSaveFile.FileName, richTextBox1.Text);
                File.AppendAllText(dlgSaveFile.FileName, "\r\nНаиболее часто встречаемое слово: " + tbWord.Text);
                File.AppendAllText(dlgSaveFile.FileName, "\r\nКоличество повторений: " + tbNum.Text + "\r\n\r\n");
            }
        }
    }
}
