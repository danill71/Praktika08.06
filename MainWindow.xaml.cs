using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace WpfApp24
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int b = 0;
        public List<string> name = new List<string>();
        public List<string> surename = new List<string>();
        public List<string> otchestvo = new List<string>();
        public List<string> mail = new List<string>();
        public List<string> nomer = new List<string>();
        public List<string> snils = new List<string>();
        bool bmail = false;
        bool bnomer = false;
        bool bsnils = false;
        bool bname = false;
        bool bsurename = false;
        bool botchestvo = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (bmail == true && bnomer == true && bsnils == true && bname == true && bsurename == true && botchestvo == true)
            {
                name.Add(nameText.Text);
                surename.Add(surenameText.Text);
                otchestvo.Add(otchestvoText.Text);
                mail.Add(mailText.Text);
                nomer.Add(nomerText.Text);
                snils.Add(snilsText.Text);
                listBox.Items.Add($"Имя: {name[b]}\nФамилия: {surename[b]}\nОтчество: {otchestvo[b]}\nПочта: {mail[b]}\nНомер телефона: {nomer[b]}\nСНИЛС: {snils[b]}");
                b++;
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {

                if (deleteText.Text.Equals(surename[i]))
                {

                    listBox.Items.Remove($"Имя: {name[i]}\nФамилия: {surename[i]}\nОтчество: {otchestvo[i]}\nПочта: {mail[i]}\nНомер телефона: {nomer[i]}\nСНИЛС: {snils[i]}");
                    name.RemoveAt(i);
                    surename.RemoveAt(i);
                    otchestvo.RemoveAt(i);
                    mail.RemoveAt(i);
                    nomer.RemoveAt(i);
                    snils.RemoveAt(i);
                    b--;

                }
            }
        }

        private void snilsText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int counts = 0;
            for (int i = 0; i < snilsText.Text.Length; i++)
            {
                if (char.IsDigit(snilsText.Text[i]))
                {
                    counts++;
                }
            }
            if (snilsText.Text.Length == 3)
            {
                snilsText.Text += '-';
                snilsText.CaretIndex = 4;
            }
            else if(snilsText.Text.Length == 7){
                snilsText.Text += '-';
                snilsText.CaretIndex = 8;
            }
            else if(snilsText.Text.Length == 11)
            {
                snilsText.Text += ' ';
                snilsText.CaretIndex = 12;
            }

            if(counts == 11 && snilsText.Text.Length == 14)
            {
                tSnils.Text = "Верно";
                tSnils.Foreground = Brushes.Green;
                bsnils = true;
            }
            else
            {
                tSnils.Text = "Неверно введён номер";
                tSnils.Foreground = Brushes.Red;
                bsnils = false;
            }

        }

        private void mailText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string simvolm = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{1,3}))$";


            if (Regex.IsMatch(mailText.Text, simvolm, RegexOptions.IgnoreCase)) 
            {
                tMail.Text = "Верно";
                tMail.Foreground = Brushes.Green;
                bmail = true; 
            }
            else
            {
                tMail.Text = "Неверно введён email";
                tMail.Foreground = Brushes.Red;
                bmail = false;
            }
        }

        private void nomerText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int countc = 0;
            for (int i = 0; i < nomerText.Text.Length; i++) {
                if (char.IsDigit(nomerText.Text[i]))
                {
                    countc++;
                }
            }
            try
            {
                if (nomerText.Text[0] == '8' && countc == 11)
                {
                    tNomer.Text = "Верно";
                    tNomer.Foreground = Brushes.Green;
                    bnomer = true;
                }
                else
                {
                    tNomer.Text = "Неверно введён номер";
                    tNomer.Foreground = Brushes.Red;
                    bnomer = false;
                }
            }
            catch
            {
                tNomer.Text = "Неверно введён номер";
                tNomer.Foreground = Brushes.Red;
                bnomer = false;
            }
        }

        private void nameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int countn = 0;
            for(int i = 0; i < nameText.Text.Length; i++)
            {
                if (char.IsLetter(nameText.Text[i]) != true)
                {
                    countn++;
                }

            }
            if(countn == 0 && nameText.Text.Length > 0)
            {
                tName.Text = "Верно";
                tName.Foreground = Brushes.Green;
                bname = true;
            }
            else
            {
                tName.Text = "Неверно";
                tName.Foreground = Brushes.Red;
                bname = false;
            }

        }

        private void surenameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int countn = 0;
            for (int i = 0; i < surenameText.Text.Length; i++)
            {
                if (char.IsLetter(surenameText.Text[i]) != true)
                {
                    countn++;
                }

            }
            if (countn == 0 && surenameText.Text.Length > 0)
            {
                tSure.Text = "Верно";
                tSure.Foreground = Brushes.Green;
                bsurename = true;
            }
            else
            {
                tSure.Text = "Неверно";
                tSure.Foreground = Brushes.Red;
                bsurename = false;
            }
        }

        private void otchestvoText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int countn = 0;
            for (int i = 0; i < otchestvoText.Text.Length; i++)
            {
                if (char.IsLetter(otchestvoText.Text[i]) != true)
                {
                    countn++;
                }

            }
            if (countn == 0 && otchestvoText.Text.Length > 0)
            {
                tOtch.Text = "Верно";
                tOtch.Foreground = Brushes.Green;
                botchestvo = true;
            }
            else
            {
                tOtch.Text = "Неверно";
                tOtch.Foreground = Brushes.Red;
                botchestvo = false;
            }
        }


        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (searchText.Text.Equals(name[i]) || searchText.Text.Equals(surename[i]) || searchText.Text.Equals(otchestvo[i]))
                {

                }
            }
        }
    }
    
}
