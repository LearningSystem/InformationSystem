using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Prepod
{
    public partial class TestEditXml : Form
    {
        public TestEditXml()
        {
            InitializeComponent();
        }

        private void TestEditXml_Load(object sender, EventArgs e)
        {
            //XmlTextReader reader = new XmlTextReader("C:\\Users\\User\\Desktop\\Текущие проекты\\Версия на тестирование\\НОВОЕ\\Prepod\\Prepod\\bin\\Debug\\General\\Ромашкина Татьяна Витальевна\\Тесты\\Методы.xml");
            string text = System.IO.File.ReadAllText(@"C:\\Users\\User\\Desktop\\Текущие проекты\\Версия на тестирование\\НОВОЕ\\Prepod\\Prepod\\bin\\Debug\\General\\Ромашкина Татьяна Витальевна\\Тесты\\Методы.xml");
            rTB.Text = text;
        }
    }
}
