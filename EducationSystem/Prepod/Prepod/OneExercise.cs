using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Word=Microsoft.Office.Interop.Word;

namespace Prepod
{
    public class OneExercise
    {
        public string Path;
        public string NumberShablon;
        public string TextPon;
        public string[] NumberMetod;
        public string[] SxodNumPon;
        public string PoriadokPon; //Если 1, то это новое понятие-вносим в БД и т.д.; если 2- меняем лишь обозначение.
        //---
        public string TextShablon;
        public string NamePon;
        public string NumberPon;
        public string Exercise; //Текст конечной задачи
        public string OboznachMetod;
        public string NameMetod;
        public int NumberTekMetodInExercise=1;//Номер текущего метода для вывода в текст задачи
        int n=5;//Длина генерируемого имени понятия
        //Word.Application application;
        //Word.Document document;
        //public bool NoParameters = false;
        public struct IzvParameters
        {
            public int NumberParam;
            public string NameParam;
            public string ObozParam;
            public int NizZnach;
            public int VverxZnach;
            public int selectZnach;
            public string Type;
            public bool NoParameters;
        }
         public struct NeIzvParameters
         {
             public int NumberParam;
             public string NameParam;
             public string ObozParam;
             //public int NizZnach;
             //public int VverxZnach;
             //public int selectZnach;
             public string Type;
             public bool NoParameters;
         }

         IzvParameters[] parameters1;
         NeIzvParameters[] parameters2;
        //нужен массив структур для хранения набора Параметров. Если их несколько.
         public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
         SqlConnection sconn;
        public OneExercise(string _path,string _numbershab,string _textpon, string[] _numbermetod,string []_sxodnumpon,string _poriadpon)
        {
            Path = _path;
            NumberShablon = _numbershab;
            TextPon = _textpon;
            NumberMetod = _numbermetod;
            SxodNumPon = _sxodnumpon;
            PoriadokPon = _poriadpon;
            //LoadTextShablon();
            GenerateNamePon(n);
            //InsertPon();
            WorkToPon(PoriadokPon);
            WorkToMetods();
            ExerciseInWord();
        }
        public void LoadTextShablon()//загрузка текста шаблона в TextShablon
        {
            //
        }
        public void GenerateNamePon(int _n) //Генерация названия понятия
        {
           Random rnd = new Random();
           Char[] pwdChars = new Char[26] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
           NamePon = String.Empty;
           for (int i = 0; i < _n-1; i++)
              NamePon += pwdChars[rnd.Next(0, 25)];
        }
        public void WorkToPon(string _poriadpon)
        {
            if (_poriadpon == "1")
            {
                InsertPon();
                SelectNumberPon();
                InsertNamePon();
                InsertShablPon();
                int i = 0;
                while (SxodNumPon[i] != null)
                {
                    InsertSxodPon(SxodNumPon[i]);
                    i++;
                }
            }
            else
            {
                SelectNumberPon();
                InsertNamePon();
            }
        }  //Работа с понятиями
        public void InsertPon() //Вставка понятия в БД в табл Понятия
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = "Insert into Понятия([Понятие]) values('"+ TextPon +"')";
                try
                {
                    scommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //вставка диструктора
                }

            } sconn.Close();

            //-------
            //SelectNumberPon();
            //InsertNamePon();
            //InsertShablPon();
            //int i = 0;
            //while (SxodNumPon[i]!=null)
            //{
            //    InsertSxodPon(SxodNumPon[i]);
            //    i++;
            //}
            //InsertSxodPon();
        }
        void InsertNamePon()
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = "Insert into [Обозначения понятия]([№ понятия],[Обозначение понятия]) values('" + NumberPon + "','" + NamePon + "')";
                try
                {
                    scommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //вставка диструктора
                }

            } sconn.Close();
        } //Вставка нового обозначения для понятия в табл. Обозначения Понятия
        void SelectNumberPon()//Получение номера только что вставленного понятия
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"SELECT TOP 1 [№ понятия] from [Понятия] order by [№ понятия] desc";
                try
                {
                    scommand.ExecuteNonQuery();
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        NumberPon = dr[0].ToString();
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    //вставка диструктора
                }
            } sconn.Close();
        }
        void InsertShablPon()//Вставка в БД в табл Шаблоны и Понятия 
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = "Insert into [Шаблоны и понятия]([№ шаблона],[№ понятия]) values('" + NumberShablon + "','"+NumberPon+"')";
                try
                {
                    scommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //вставка диструктора
                }

            } sconn.Close();
        }
        void InsertSxodPon(string _select)//Вставка в БД в табл Схожие понятия 
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"INSERT INTO [Сходные понятия]([№ понятия],[№ схожего понятия]) values ('" + NumberPon + "','" + _select + "')";
                try
                {
                    scommand.ExecuteNonQuery();
                    scommand.CommandText = @"INSERT INTO [Сходные понятия]([№ понятия],[№ схожего понятия]) values ('" + _select + "','" + NumberPon + "')";
                    scommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }

        public void WorkToMetods()//Работа с методами
        {
            StartSborka();
            int l=0;
            while (NumberMetod[l]!=null)
            {
                GenerateOboznachMetod(n);
                InsertOboznachMetod(NumberMetod[l]);
                InsertPonMetod(NumberMetod[l],NumberPon);
                SelectNumberParameters(NumberMetod[l],"1");
                SelectNumberParameters(NumberMetod[l], "2");
                Sborka(OboznachMetod,NameMetod,parameters1,parameters2);
                NumberTekMetodInExercise++;
                l++;
            }
            DopiskaZnach(parameters1);   
        }
        void GenerateOboznachMetod(int _n)
        {
            Random rnd = new Random();
            Char[] pwdChars = new Char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            OboznachMetod = String.Empty;
            for (int i = 0; i < _n - 1; i++)
                OboznachMetod += pwdChars[rnd.Next(0, 25)];
        }
        void InsertOboznachMetod(string _numMetod)
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"INSERT INTO [Обозначения метода]([№ метода],[Обозначение метода])values('" + _numMetod + "','" + OboznachMetod + "')";
                try
                {
                    scommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }

        void InsertPonMetod(string _numMetod,string _numPon)
        {
            //sconn = new SqlConnection(connectionString);
            //using (sconn)
            //{
            //    sconn.Open();
            //    SqlCommand scommand = new SqlCommand();
            //    scommand.Connection = sconn;
            //    scommand.CommandText = @"UPDATE [Методы] SET [Обозначение метода]='" + OboznachMetod + "' WHERE [№ метода]='" + _numMetod + "'";
            //    try
            //    {
            //        scommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show(ex.Message);
            //    }
            //} sconn.Close();
        }

        void SelectNumberParameters(string _numMetod,string rez)
        {
            if (rez=="1")
               parameters1 = new IzvParameters[100];
            else
                parameters2 = new NeIzvParameters[100];
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                if (rez=="1")
                  scommand.CommandText = @"SELECT [№ параметра],[Название параметра],[Обозначение параметра],[Нижняя граница диапазона],[Верхняя граница диапазона],[Тип ссылки] from [Известные параметры] where [№ метода]='"+_numMetod+"'";
                else
                {
                    scommand.CommandText = @"SELECT [№ параметра],[Название параметра],[Обозначение параметра],[Тип ссылки] from [Неизвестные параметры] where [№ метода]='" + _numMetod + "'";
                }
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    int k = 0;
                    while(dr.Read())
                    {
                        if (rez == "1")
                        {
                            parameters1[k].NumberParam = Int32.Parse(dr[0].ToString());
                            if (dr[1].ToString()!="Отсутствуют")
                            {
                                parameters1[k].NameParam = dr[1].ToString();
                                parameters1[k].ObozParam = dr[2].ToString();
                                parameters1[k].NizZnach = Int32.Parse(dr[3].ToString());
                                parameters1[k].VverxZnach = Int32.Parse(dr[4].ToString());
                            }
                            else
                            {
                                parameters1[k].NoParameters = true;
                            }
                            //запилить функцию для рандома в границах
                            parameters1[k].Type = dr[5].ToString();
                            k++;
                        }
                        else
                        {
                            parameters2[k].NumberParam = Int32.Parse(dr[0].ToString());
                            if (dr[1].ToString() != "Отсутствуют")
                            {
                                parameters2[k].NameParam = dr[1].ToString();
                                parameters2[k].ObozParam = dr[2].ToString();
                            }
                            else
                            {
                                parameters2[k].NoParameters = true;
                            }
                            //parameters2[k].NizZnach = Int32.Parse(dr[3].ToString());
                            //parameters2[k].VverxZnach = Int32.Parse(dr[4].ToString());
                            parameters2[k].Type = dr[5].ToString();
                            k++;
                        }

                    } dr.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }

        void WriteOnePam()
        {

        }
        //-------
        public void StartSborka()
        {
            if (NumberShablon=="3")
              Exercise=Exercise + String.Format("Опишите класс {0}, представляющий {1}. Класс должен содержать необходимые поля и следующие методы: \n", NamePon, TextPon);
        }
        public void Sborka(string _obozn,string _name,IzvParameters[] _pam1,NeIzvParameters[] _pam2)
        {
            if (NumberShablon == "3")
            {
                Exercise = Exercise + String.Format(NumberTekMetodInExercise.ToString() + ". Метод {0} - {1} входные параметры - ", _obozn, _name);
                int i = 0;
                while (_pam1[i].NumberParam != 0)
                {
                    if (_pam1[i].NoParameters == false)
                    {
                        Exercise = Exercise + _pam1[i].NameParam + " " + _pam1[i].ObozParam + ",";
                        i++;
                    }
                    else
                    {
                        Exercise = Exercise + " отсутствуют;";
                        i++;
                    }

                }
                Exercise = Exercise + "; выходные параметры - ";
                i = 0;
                while (_pam2[i].NumberParam != 0)
                {
                    if (_pam2[i].NoParameters == false)
                    {
                        Exercise = Exercise + _pam2[i].NameParam + " " + _pam2[i].ObozParam + ",";
                        i++;
                    }
                    else
                    {
                        Exercise = Exercise + " отсутствуют;";
                        i++;
                    }
                }
                //Exercise = Exercise + "\n";
                //Exercise = Exercise + "При условии,что: \n ";
                //i = 0;
                //while (_pam1[i].NumberParam != 0)
                //{
                //    Exercise = Exercise + _pam1[i].NameParam + " " + _pam1[i].ObozParam + " = "+_pam1[i].selectZnach+", \n";
                //    i++;
                //}
                Exercise = Exercise + " \n";

            }
        }

        public void DopiskaZnach(IzvParameters[] _pam1)
        {
            Exercise = Exercise + "\n";
            Exercise = Exercise + "При условии, что: \n ";
            int i = 0;
            while (_pam1[i].NumberParam != 0)
            {
                Exercise = Exercise + _pam1[i].NameParam + " " + _pam1[i].ObozParam + " = " + _pam1[i].selectZnach + ", \n";
                i++;
            }
            Popravka();
        }
        void Popravka()
        {
            while (Exercise.IndexOf(",;")!=-1)
            {
                Exercise = Exercise.Replace(",;", ";");
            }
            while (Exercise.IndexOf(";;") != -1)
            {
                Exercise = Exercise.Replace(";;", ";");
            }
        }
        public void ExerciseInWord()
        {
            var WordApp = new Word.Application();
            WordApp.Visible = true;
            WordApp.Documents.Add();
            WordApp.Selection.Text = Exercise;
            object fileName = Path +  NamePon +".docx";
            //WordApp.ActiveDocument.SaveAs(ref fileName);
            WordApp.ActiveDocument.SaveAs(ref fileName);
            WordApp.Quit();
        }
        public void InsertProverka()
        {
        
        }
    }
}
