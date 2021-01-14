using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Json
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Book> Books = new List<Book>();
        JavaScriptSerializer Jserializer = new JavaScriptSerializer();
      
        private void button2_Click(object sender, EventArgs e)
        {

            Book newBook = new Book();
            newBook.Title = textBox1.Text;
            newBook.Price = numericUpDown1.Value;

            Books.Add(newBook);

            WriteJson(Books);

        }

        private void WriteJson(List<Book> books)
        {
            string Json = Jserializer.Serialize(books);//convert list json
            File.WriteAllText("../../Books.json", Json);
            MessageBox.Show("Succesfull");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Content = File.ReadAllText("../../Books.json");
            var List = Jserializer.Deserialize<List<Book>>(Content);


            listBox1.DisplayMember = "Title";

            foreach (Book book in List)
            {
                listBox1.Items.Add(book);
            }

        }
    }
}
