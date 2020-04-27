using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Карточки_студентов
{
    public partial class Form1 : Form
    {
        int filtr;
        int add;
        string path;
        string cource;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Открыть
        {
            Open();
        }
        private void button2_Click(object sender, EventArgs e) //Записать
        {
            Add();
            Save();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }
        private void button3_Click(object sender, EventArgs e) //Сортировка
        {
            textBox1.Clear();
            switch (filtr)
            {
                case 0:
                    MessageBox.Show("Задайте параметры сортировки!");
                    break;
                case 1:
                    {
                        Director();
                        cource = comboBox1.Text;
                        string s;
                        string[] files = Directory.GetFiles(path);
                        for (int i = 0; i < files.Length; i++)
                        {
                            s = System.IO.File.ReadAllText(files[i]);
                            if (s.Contains(cource))
                            {
                                textBox1.Text += "Студент " + files[i] + " обучается на " + cource + Environment.NewLine;
                            }
                            comboBox1.SelectedItem = null;
                        }
                        break;
                    }
                case 2:
                    {
                        Director();
                        cource = comboBox2.Text;
                        string s;
                        string[] files = Directory.GetFiles(path);
                        for (int i = 0; i < files.Length; i++)
                        {
                            s = System.IO.File.ReadAllText(files[i]);
                            if (s.Contains(cource))
                            {
                                textBox1.Text += "Студент " + files[i] + " обучается на " + cource + Environment.NewLine;
                            }
                            comboBox2.SelectedItem = null;
                        }
                        break;
                    }
                case 3:
                    {
                        Director();
                        cource = comboBox3.Text;
                        string s;
                        string[] files = Directory.GetFiles(path);
                        for (int i = 0; i < files.Length; i++)
                        {
                            s = System.IO.File.ReadAllText(files[i]);
                            if (s.Contains(cource))
                            {
                                textBox1.Text += "Студент " + files[i] + " обучается на " + cource + Environment.NewLine;
                            }
                            comboBox3.SelectedItem = null;
                        }
                        break;
                    }
                case 4:
                    {
                        Director();
                        cource = comboBox4.Text;
                        string s;
                        string[] files = Directory.GetFiles(path);
                        for (int i = 0; i < files.Length; i++)
                        {
                            s = System.IO.File.ReadAllText(files[i]);
                            if (s.Contains(cource))
                            {
                                textBox1.Text += "Студент " + files[i] + " обучается на " + cource + Environment.NewLine;
                            }
                            comboBox4.SelectedItem = null;
                        }
                        break;
                    }
                default:
                    break;
            }

        }
        private void button4_Click(object sender, EventArgs e)//Сохранить
        {
            if(textBox1.Text != "") 
            Save();
        }
        public void Add()
        {
            Stud st = new Stud();
            st.FIO = textBox2.Text.ToString();
            st.Сurriculum_ = new List<Сurriculum>();
            st.Сurriculum_.Add(new Сurriculum
            {
                Faculty = textBox3.Text.ToString(),
                Speciality = textBox4.Text.ToString(),
                Cource = textBox5.Text.ToString(),
                Group = textBox6.Text.ToString()
            });
            st.Address_ = new List<Address>();
            st.Address_.Add(new Address
            {
                City = textBox7.Text.ToString(),
                PostIndex = textBox8.Text.ToString(),
                Street = textBox9.Text.ToString()
            });
            st.Contacts_ = new List<Contacts>();
            st.Contacts_.Add(new Contacts
            {
                Phone = textBox10.Text.ToString(),
                Email = textBox11.Text.ToString()
            });
            string json = JsonConvert.SerializeObject(st, Formatting.Indented);
            textBox1.Text = json;
        }
        public void Save()
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
            if (sav.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sav.FileName, textBox1.Text);
            }
        }
        public void Director()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(FBD.SelectedPath);
                path = FBD.SelectedPath;
            }
        }
        public void Open()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFile.FileName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                filtr = 0;
            }
            else if (comboBox1.Text != "")
            {
                filtr = 1;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                filtr = 0;
            }
            else if (comboBox2.Text != "")
            {
                filtr = 2;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                filtr = 0;
            }
            else if (comboBox3.Text != "")
            {
                filtr = 3;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "")
            {
                filtr = 0;
            }
            else if (comboBox4.Text != "")
            {
                filtr = 4;
            }
        }

        private void button5_Click(object sender, EventArgs e)//Очистить
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox17.Clear();
            textBox19.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            comboBox5.SelectedItem = null;

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "КУРС")
            {
                add = 1;
            }
            else if (comboBox5.Text == "ФАКУЛЬТЕТ")
            {
                add = 2;
            }
            else if (comboBox5.Text == "СПЕЦИАЛЬНОСТЬ")
            {
                add = 3;
            }
            else if (comboBox5.Text == "ГРУППА")
            {
                add = 4;
            }
        }

        private void button6_Click(object sender, EventArgs e)//Добввить
        {
            switch (add)
            {
                case 0:
                    MessageBox.Show("Ошибка! Введите значение.");
                    break;
                case 1:
                    comboBox1.Items.Add(textBox17.Text.ToString());
                    break;
                case 2:
                    comboBox2.Items.Add(textBox17.Text.ToString());
                    break;
                case 3:
                    comboBox3.Items.Add(textBox17.Text.ToString());
                    break;
                case 4:
                    comboBox4.Items.Add(textBox17.Text.ToString());
                    break;
            }
            comboBox5.SelectedItem = null;
            textBox17.Clear();
        }

        private void button7_Click(object sender, EventArgs e) //поиск по ФИО
        {
            Director();
            cource = textBox19.Text.ToString();
            string s;
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                s = System.IO.File.ReadAllText(files[i]);
                if (s.Contains(cource))
                {
                    textBox1.Text += "Студент " + files[i] + " " + cource + Environment.NewLine;
                }
                textBox19.Clear();
            }
        }
    }

    public class Stud
    {
        public string FIO { get; set; }
        public List<Сurriculum> Сurriculum_ { get; set; }
        public List<Address> Address_ { get; set; }
        public List<Contacts> Contacts_ { get; set; }
    }
    public class Сurriculum
    {
        public string Faculty { get; set; }
        public string Speciality { get; set; }
        public string Cource { get; set; }
        public string Group { get; set; }
    }
    public class Address
    {
        public string City { get; set; }
        public string PostIndex { get; set; }
        public string Street { get; set; }
    }
    public class Contacts
    {
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
