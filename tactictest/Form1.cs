using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace tactictest
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        XDocument xdoc = XDocument.Load("questlist.xml");
        int[] random_array;
        int iteration = 0;
        int last = 10; // ограничение кол-ва вопросов (в данном случае первые 10 случайных вопросов из общего пула >=10 )
        int question_id;
        int option_id = 0;
        int right_answer_value = 0;
        int right_answers_count = 0;
        int wrong_answers_count = 0;

        public Form1()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            IEnumerable<Question> items = from xe in xdoc.Element("questions").Elements("question")
                                          select new Question();
            random_array = Enumerable.Range(1, items.Count()).ToArray();
            for (int i = items.Count() - 1; i >= 1; i--)
            {
                int j = r.Next(i + 1);
                int temp = random_array[j];
                random_array[j] = random_array[i];
                random_array[i] = temp;
            }
            Next_Question();
        }
        private void Next_Question()
        {
            IEnumerable<Question> items = from xe in xdoc.Element("questions").Elements("question")
                                          //where xe.Attribute("id").Value == question_id.ToString()
                                          select new Question
                                          {
                                              Id = Convert.ToInt32(xe.Attribute("id").Value),
                                              Name = xe.Attribute("name").Value,
                                              Option1 = xe.Element("option1").Attribute("url").Value,
                                              Option2 = xe.Element("option2").Attribute("url").Value,
                                              Option3 = xe.Element("option3").Attribute("url").Value,
                                              Option4 = xe.Element("option4").Attribute("url").Value,
                                              Option5 = xe.Element("option5").Attribute("url").Value,
                                              Answer = Convert.ToInt32(xe.Element("answer").Value)
                                          };

            question_id = random_array[iteration];
            iteration++;
            label2.Text = question_id.ToString();
            foreach (var item in items.Where(p => p.Id == question_id))
            {
                label1.Text = item.Name;
                button1.BackgroundImage = new Bitmap($@"{item.Option1}");
                button2.BackgroundImage = new Bitmap($@"{item.Option2}");
                button3.BackgroundImage = new Bitmap($@"{item.Option3}");
                button4.BackgroundImage = new Bitmap($@"{item.Option4}");
                button5.BackgroundImage = new Bitmap($@"{item.Option5}");
                right_answer_value = item.Answer;
            }
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            if (right_answer_value == option_id)
            {
                right_answers_count++;
                MessageBox.Show("Верно");
            }
            else
            {
                wrong_answers_count++;
                MessageBox.Show("Не верно");
            }
            if (iteration == last)
            {
                MessageBox.Show("Тестирование окончено");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                label2.Visible = true;
                label3.Visible = true;
                label1.Text = $"Правильных ответов: {right_answers_count}";
                label2.ForeColor = Color.Red;
                label2.Text = $"Неправильных ответов: {wrong_answers_count}";
                label3.Text = $"Всего: {iteration}";
            }
            else
            {
                Next_Question();
            }
        }

        private void Option_Click(object sender, EventArgs e)
        {
            option_id = Convert.ToInt32((sender as Button).Tag);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
