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

namespace JsonEmoji
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Category> GetEmojiList = GetEmoji();

        private static List<Category> GetEmoji()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string JsonContent = File.ReadAllText("../../smiley_content.json");

            return serializer.Deserialize<List<Category>>(JsonContent);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var List = GetEmoji();
            DisplayEmojiList(List);
        }

        private void DisplayEmojiList(List<Category> list)
        {
            foreach (Category item in list)
            {
                Label lbl = new Label()
                {
                    Text = item.category,

                };
                lbl.AutoSize = false;
                lbl.Width = this.ClientSize.Width;
                lbl.Font = new Font(FontFamily.GenericSansSerif, 16);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Margin = new Padding(5,20,5,20);
                flowLayoutPanel1.SetFlowBreak(lbl, true);
                flowLayoutPanel1.Controls.Add(lbl);

                DisplayItems(item);
            }
        }

        private void DisplayItems(Category item)
        {

            foreach ( Item i in item.items)
            {
                Button btn = new Button();
                btn.Text = i.art + Environment.NewLine + i.name;
                btn.Font = new Font(FontFamily.GenericSansSerif, 12);
                btn.Padding = new Padding(5);
                btn.Width = flowLayoutPanel1.ClientSize.Width/2-10;
                btn.Height = 80;
                btn.Click += Clicked;
                flowLayoutPanel1.Controls.Add(btn);

            }




        }

        private void Clicked(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;

            string[] info = clickedBtn.Text.Split('\n');

            Clipboard.SetText(info[0]);
            MessageBox.Show(clickedBtn.Text + "has copied to clipboard");


        }
    }
}
