	using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// Utworzenie zmiennych niezbędnych do działania programu:
        /// <paramref /> private Stopwatch stoper; Zainicjowanie obiektu stoper klasy Stopwatch
        /// <paramref /> private string odpX = string.Empty; gdzie X to numer z przedziału 1-6 zmienne do przechowywania odpowiedzi
        /// <paramref /> private int wynikO; przechowuje wynik z części ogólnej
        /// <paramref /> private int wynikM; przechowuje wynik z części matematycznej
        /// <paramref /> private int wynikP; przechowuje wynik z części języka polskiego
        /// </summary>
        private Stopwatch stoper;
        private string odp1 = string.Empty;
        private string odp2 = string.Empty;
        private string odp3 = string.Empty;
        private string odp4 = string.Empty;
        private string odp5 = string.Empty;
        private string odp6 = string.Empty;
        private int wynikO;
        private int wynikM;
        private int wynikP;
        private int trybTreningu;

        private int menuPytania = 0;
        /// <summary>
        /// Inicjalizacja obiektu formularza
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Wywołanie panelu informującego użytkownika o tym czym jest program oraz tworzenie obiektu klasy Stopwatch.
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Show();
            panel1.BringToFront();
            panel2.Hide();
            panel3.Hide();
            pTest.Hide();
            pKoniec1.Hide();
            pKoncowy.Hide();
            pWyborTreningu.Hide();
            pWyborKategorii.Hide();
            stoper = new Stopwatch();
        }
        /// <summary>
        /// Wywołanie zdarzenia sprawdzającego, czy użytkownik potwierdził zgodę. Jeśli zgoda jest potwierdzona 
        /// otwiera się panel do wpisywania danych użytkownika, jeśli nie wyświetla się MessageBox z komunikatem o błędzie
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bDalej2_Click(object sender, EventArgs e)
        {
            if (cPotwierdzenie1.Checked == true)
            {
                panel1.Hide();
                panel3.Hide();
                panel2.Show();
                panel2.BringToFront();
            }
            else
            {
                MessageBox.Show("Nie potwierdziłeś zgody", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// Wywołanie metody SprawdzPoprawnosc();
        /// </summary>        
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bDalej1_Click(object sender, EventArgs e)
        {
            SprawdzPoprawnosc();
        }
        /// <summary>
        /// Ustawia wartość zmiennych
        /// <paramref /> menuPytania = 0;
        /// <paramref />trybTreningu = 0;
        /// Następnie ukrywa poprzednie panele i ładuje panel odpowiedzialny za test,
        /// oraz wywołuje funkcję losującą zestaw pytań
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bTest_Click(object sender, EventArgs e)
        {
            menuPytania = 0;
            trybTreningu = 0;
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            pTest.BringToFront();
            pTest.Show();
            StworzPytaniaOgolna();
            stoper.Start();
        }
        /// <summary>
        /// Ustawia wartość zmiennej trybTreningu na 1, co sprawia, że wywoływany jest  panel odpowiedzialny za test 
        /// oraz wywołuje funkcję losującą zestaw pytań
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bTreningCalosc_Click(object sender, EventArgs e)
        {
            menuPytania = 0;
            trybTreningu = 1;
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            pTest.BringToFront();
            pTest.Show();
            StworzPytaniaOgolna();
            stoper.Start();
        }
        /// <summary>
        /// ustawia wartość tryb treningu na 2 co sprawia, 
        /// że wywoływany jest panel z wyborem kategorii
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bTreningPoszczegolne_Click(object sender, EventArgs e)
        {
            trybTreningu = 2;
            pWyborKategorii.BringToFront();
            pWyborKategorii.Show();
            pWyborTreningu.Hide();
        }
        /// <summary>
        /// wywołuje panel wyboru rodzaju treningu
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bTrening_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            pWyborTreningu.BringToFront();
            pWyborTreningu.Show();
        }
        /// <summary>
        /// zostaje utworzona tablica z pytaniami i odpowiedziami do nich, następnie następuje losowanie zestawu pytań. 
        /// To samo następuje w funkcjach public void StworzPytaniaMatematyka() i public void StworzPytaniaPolski()
        /// </summary>
        public void StworzPytaniaOgolna()
        {
            string[][] tab = new string[9][];
            for (int i = 0; i < 9; i++)
            {
                tab[i] = new string[2];
            }
            tab[0][0] = "Czy w Polsce mamy obecnie króla?";
            tab[0][1] = "Nie";
            tab[1][0] = "Czy USA należy do Unii Europejskiej?";
            tab[1][1] = "Nie";
            tab[2][0] = "W którym roku był chrzest Polski?";
            tab[2][1] = "966";
            tab[3][0] = "Czy Polska należy do Unii Europejskiej?";
            tab[3][1] = "Tak";
            tab[4][0] = "Morze bałtyckie jest na północy czy na południu Polski?";
            tab[4][1] = "Północy";
            tab[5][0] = "W którym wieku była II wojna światowa?";
            tab[5][1] = "XX";
            tab[6][0] = "Zamrożona woda to?";
            tab[6][1] = "Lód";
            tab[7][0] = "Ile województw jest w Polsce";
            tab[7][1] = "16";
            tab[8][0] = "Jakie miasto jest stolicą Polski";
            tab[8][1] = "Warszawa";

            int number;
            Random rand = new Random();

            List<int> listNumbers = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                do
                {
                    number = rand.Next(0, 8);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }

            lPytanie1.Text = "1/6 " + tab[listNumbers[0]][0];
            lPytanie2.Text = "2/6 " + tab[listNumbers[1]][0];
            lPytanie3.Text = "3/6 " + tab[listNumbers[2]][0];
            lPytanie4.Text = "4/6 " + tab[listNumbers[3]][0];
            lPytanie5.Text = "5/6 " + tab[listNumbers[4]][0];
            lPytanie6.Text = "6/6 " + tab[listNumbers[5]][0];
            odp1 = tab[listNumbers[0]][1];
            odp2 = tab[listNumbers[1]][1];
            odp3 = tab[listNumbers[2]][1];
            odp4 = tab[listNumbers[3]][1];
            odp5 = tab[listNumbers[4]][1];
            odp6 = tab[listNumbers[5]][1];
            Poczatek();
        }

        public void StworzPytaniaMatematyka()
        {
            string[][] tab = new string[9][];
            for (int i = 0; i < 9; i++)
            {
                tab[i] = new string[2];
            }
            tab[0][0] = "Ile to jest 72 + 27 ?";
            tab[0][1] = "99";
            tab[1][0] = "Czy kąt prosty ma 90 stopni?";
            tab[1][1] = "Tak";
            tab[2][0] = "Czy dozwolone jest mnożenie razy 0";
            tab[2][1] = "Tak";
            tab[3][0] = "Suma kątów w trójkącie wynosi";
            tab[3][1] = "180";
            tab[4][0] = "8 zapisane w systemie rzymskim to będzie";
            tab[4][1] = "VIII";
            tab[5][0] = "Czy kwadrat jest prostokątem";
            tab[5][1] = "Tak";
            tab[6][0] = "Czy dozwolone jest dzielenie przez 0";
            tab[6][1] = "Nie";
            tab[7][0] = "Ala miała 10 jabłek zjadła 6 ile jej zostało?";
            tab[7][1] = "4";
            tab[8][0] = "Wynik działania 2+2*2 to?";
            tab[8][1] = "6";

            int number;
            Random rand = new Random();

            List<int> listNumbers = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                do
                {
                    number = rand.Next(0, 8);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }

            lPytanie1.Text = "1/6 " + tab[listNumbers[0]][0];
            lPytanie2.Text = "2/6 " + tab[listNumbers[1]][0];
            lPytanie3.Text = "3/6 " + tab[listNumbers[2]][0];
            lPytanie4.Text = "4/6 " + tab[listNumbers[3]][0];
            lPytanie5.Text = "5/6 " + tab[listNumbers[4]][0];
            lPytanie6.Text = "6/6 " + tab[listNumbers[5]][0];
            odp1 = tab[listNumbers[0]][1];
            odp2 = tab[listNumbers[1]][1];
            odp3 = tab[listNumbers[2]][1];
            odp4 = tab[listNumbers[3]][1];
            odp5 = tab[listNumbers[4]][1];
            odp6 = tab[listNumbers[5]][1];

            Poczatek();
        }
        public void StworzPytaniaPolski()
        {
            string[][] tab = new string[9][];
            for (int i = 0; i < 9; i++)
            {
                tab[i] = new string[2];
            }
            tab[0][0] = "Jak nazywał się pierwszy polski noblista w dziedzinie literatury?";
            tab[0][1] = "Henryk Sienkiewicz";
            tab[1][0] = "Jak nazywał się najsłynniejszy polski kompozytor? (autor Mazurków)";
            tab[1][1] = "Fryderyk Chopin";
            tab[2][0] = "Jaki kolor miały włosy Ani z Zielonego Wzgórza";
            tab[2][1] = "Rudy";
            tab[3][0] = "Po spółgłoskach b, d, g piszemy RZ czy Ż";
            tab[3][1] = "rz";
            tab[4][0] = "Rzeczownik odmienia się przez czasy czy liczby?";
            tab[4][1] = "Liczby";
            tab[5][0] = "Jak nazywał się inaczej Jacek Spolica z Pana Tadeusza";
            tab[5][1] = "Ksiądz Robak";
            tab[6][0] = "Jak nazywała się siostra Balladyny";
            tab[6][1] = "Alina";
            tab[7][0] = "Pod jakim pseudonimem pisał Aleksander Głowacki";
            tab[7][1] = "Bolesław Prus";
            tab[8][0] = "Podaj imię głównego bohatera Ten Obcy";
            tab[8][1] = "Zenek";

            int number;
            Random rand = new Random();

            List<int> listNumbers = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                do
                {
                    number = rand.Next(0, 8);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }

            lPytanie1.Text = "1/6 " + tab[listNumbers[0]][0];
            lPytanie2.Text = "2/6 " + tab[listNumbers[1]][0];
            lPytanie3.Text = "3/6 " + tab[listNumbers[2]][0];
            lPytanie4.Text = "4/6 " + tab[listNumbers[3]][0];
            lPytanie5.Text = "5/6 " + tab[listNumbers[4]][0];
            lPytanie6.Text = "6/6 " + tab[listNumbers[5]][0];
            odp1 = tab[listNumbers[0]][1];
            odp2 = tab[listNumbers[1]][1];
            odp3 = tab[listNumbers[2]][1];
            odp4 = tab[listNumbers[3]][1];
            odp5 = tab[listNumbers[4]][1];
            odp6 = tab[listNumbers[5]][1];
            Poczatek();
        }
        /// <summary>
        /// wywołuje wylosowane w public void StworzPytaniaOgolna()/public void StworzPytaniaMatematyka() /  public void StworzPytaniaPolski() 
        /// zestawy pytań i odpowiedzi. 
        /// </summary>
        private void Poczatek()
        {
            lPytanie1.Show();
            lPytanie2.Show();
            lPytanie3.Show();
            lPytanie4.Show();
            lPytanie5.Show();
            lPytanie6.Show();
            lPytanie1.BringToFront();
            lPytanie2.BringToFront();
            lPytanie3.BringToFront();
            lPytanie4.BringToFront();
            lPytanie5.BringToFront();
            lPytanie6.BringToFront();
            tOdpowiedz1.Show();
            tOdpowiedz2.Show();
            tOdpowiedz3.Show();
            tOdpowiedz4.Show();
            tOdpowiedz5.Show();
            tOdpowiedz6.Show();
            tOdpowiedz1.BringToFront();
            tOdpowiedz2.BringToFront();
            tOdpowiedz3.BringToFront();
            tOdpowiedz4.BringToFront();
            tOdpowiedz5.BringToFront();
            tOdpowiedz6.BringToFront();

        }
        /// <summary>
        /// wywołuje public void Sprawdz() oraz sprawdza którą część testu użytkownik już wykonał, 
        /// po czym wyświetla mu komunikat o zakończeniu tej części.
        /// </summary>
        ///<para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void lKoniec1_Click(object sender, EventArgs e)
        {
            Zakonczenia zakonczenia = new Zakonczenia();

            Sprawdz();
            pTest.Hide();
            if (menuPytania == 0)
            {
                lZakonczenie.Text = zakonczenia.DajZakonczenie(0);
            }
            else if (menuPytania == 1)
            {
                lZakonczenie.Text = zakonczenia.DajZakonczenie(1);
            }
            else if (menuPytania == 2)
            {
                lZakonczenie.Text = zakonczenia.DajZakonczenie(2);
            }

            pKoniec1.BringToFront();
            pKoniec1.Show();
        }
        /// <summary>
        /// w poszczególnych iteracjach porównuje wartości wpisane przez użytkownika z wartościami w tabeli. Z racji tego że C# jest językiem Case sensitivity zostaje wywołana funkcja, 
        /// która sprawia że wielkość liter nie ma znaczenia. Na koniec funkcja Sprawdź oblicza wynik z poszczególnych części testu.
        /// </summary>
        public void Sprawdz()
        {
            Walidator nowyWalidator = new Walidator();
            
            int wynik = 0;
            
            if (nowyWalidator.SprawdzCzyRowne(tOdpowiedz1.Text, odp1)) 
            {
                wynik++;
            }
            if (nowyWalidator.SprawdzCzyRowne(tOdpowiedz2.Text, odp2)) 
            {
                wynik++;
            }
            if (nowyWalidator.SprawdzCzyRowne(tOdpowiedz3.Text, odp3)) 
            {
                wynik++;
            }
            if (nowyWalidator.SprawdzCzyRowne(tOdpowiedz4.Text, odp4)) 
            {
                wynik++;
            }
            if (nowyWalidator.SprawdzCzyRowne(tOdpowiedz5.Text, odp5)) 
            {
                wynik++;
            }
            if (nowyWalidator.SprawdzCzyRowne(tOdpowiedz6.Text, odp6)) 
            {
                wynik++;
            }

            lWynik.Text = wynik.ToString();
            if (menuPytania == 0)
            {
                wynikO = wynik;
            }
            else if (menuPytania == 1)
            {
                wynikM = wynik;
            }
            else if (menuPytania == 2)
            {
                wynikP = wynik;
            }

        }
        /// <summary>
        /// odpowiada za przechodzenie na następną część testu, sprawdzając wpierw w której części testu się znajduje. Po tym wyświetla panel następnej części testu, losuje odpowiednie do części testu pytania.
        /// Jeśli wartość menu pytania jest równa 2 co oznacza że test się zakończył, więc następuje podliczenie punktów, a następnie wyświetlenie wyniku dla poszczególnych części oraz sumy punktów. Po czym,  
        /// jeśli użytkownik był w trybie treningowym, to wyświetla się panel z menu głównym.
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bDalejOgolna_Click(object sender, EventArgs e)
        {
            tOdpowiedz1.Text = "";
            tOdpowiedz2.Text = "";
            tOdpowiedz3.Text = "";
            tOdpowiedz4.Text = "";
            tOdpowiedz5.Text = "";
            tOdpowiedz6.Text = "";
            pKoniec1.Hide();
            if (menuPytania == 0 && (trybTreningu == 0 || trybTreningu == 1))
            {
                pTest.BringToFront();
                pTest.Show();
                StworzPytaniaMatematyka();
                menuPytania++;
            }
            else if (menuPytania == 1 && (trybTreningu == 0 || trybTreningu == 1))
            {
                pTest.BringToFront();
                pTest.Show();
                StworzPytaniaPolski();
                menuPytania++;
            }
            else if (menuPytania == 2 && (trybTreningu == 0 || trybTreningu == 1))
            {
                stoper.Stop();
                pKoncowy.BringToFront();
                pKoncowy.Show();
                int suma = wynikO + wynikM + wynikP;
                lWynikO.Text = "Twój wynik z części ogólnej: " + wynikO.ToString() + "/6";
                lWynikM.Text = "Twój wynik z części matematycznej: " + wynikM.ToString() + "/6";
                lWynikP.Text = "Twój wynik z części języka polskiego: " + wynikP.ToString() + "/6";
                lSumaWynikow.Text = "Łącznie uzyskano " + suma.ToString() + " punktów";
            }
            if (trybTreningu == 2)
            {

                panel3.BringToFront();
                panel3.Show();
            }
        }
        /// <summary>
        /// sprawdza czy użytkownik rozwiązywał test czy trening. Jeśli był to test, to wysyła dane do pliku funkcją public void WyslijDane() i zamyka program,
        /// w przeciwnym wypadku zatrzymuje czas i cofa użytkownika do menu wyboru rodzaju testu.
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bZakoncz_Click(object sender, EventArgs e)
        {
            if (trybTreningu == 0)
            {
                WyslijDane();
                this.Close();
            }
            else
            {
                pKoncowy.Hide();
                panel3.BringToFront();
                panel3.Show();
                stoper.Reset();
            }
        }
        /// <summary>
        /// ustawia format stopera
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lStoper.Text = string.Format("{0:hh\\:mm\\:ss}", stoper.Elapsed);
        }
        /// <summary>
        /// wywołuje panel z testem oraz tworzy pytania za pomocą StworzPytaniaOgolna();. Tak samo dzieje się to w przypadku private void bMatematyka_Click oraz private void bPolski_Click
        /// </summary>
        /// <para>Metody obsługujące zdarzenia posiadają dwa argumenty:</para>
        /// <param name="sender">Zawiera odniesienie do obiektu, który wywołuje zdarzenia opisane wyżej</param>
        /// <param name="e">przekazuje obiekt do obsługiwanego zdarzenia</param>
        private void bWiedzaOgolna_Click(object sender, EventArgs e)
        {
            menuPytania = 0;
            pTest.BringToFront();
            pTest.Show();
            StworzPytaniaOgolna();
        }
        private void bMatematyka_Click(object sender, EventArgs e)
        {
            menuPytania = 1;
            pTest.BringToFront();
            pTest.Show();
            StworzPytaniaMatematyka();
        }
        private void bPolski_Click(object sender, EventArgs e)
        {
            menuPytania = 2;
            pTest.BringToFront();
            pTest.Show();
            StworzPytaniaPolski();
        }
        /// <summary>
        /// zapisuje w utworzonym w tej samej lokalizacji co program pliku tekstowym o nazwie „wynik” wyniki z testu w postaci Imię, Nazwisko, Pesel oraz kolejno wyniki z części Ogólnej, Matematycznej i Języka polskiego. 
        /// Sprawdza przy okazji czy plik istnieje, jeśli istnieje to zapisuje w nim dane, jeśli nie to tworzy go, a następnie zapisuje.
        /// </summary>
        public void WyslijDane()
        {
            string path = @"wynik.txt";
            StreamWriter sw;
            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
            }
            else
            {
                sw = new StreamWriter(path, true);
            }
            string dane = tImie.Text.ToString() + " " + tNazwisko.Text.ToString() + " " + tPesel.Text.ToString() + " Wynik z ogolnego " + wynikO.ToString() + " Wynik z matematyki " + wynikM.ToString() + " Wynik z języka polskiego " + wynikP.ToString();
            sw.WriteLine(dane);
            sw.Close();

        }

        /// <summary>
        /// Sprawdzane jest czy w polach do wpisywania danych osobowych wpisywana jest odpowiednia ilość znaków. 
        /// Jeśli któraś z wartości jest podana nieprawidłowo, wyświetla Messagebox z komunikatem błędu. 
        /// Jeśli wprowadzone dane są prawidłowe wywołuje panel z napisem „Cześć! I w stawia imię wpisane przez użytkownika. 
        /// </summary>
        public void SprawdzPoprawnosc()
        {
            if (tImie.Text.Length < 2)
            {
                MessageBox.Show("Za krótkie imie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (tNazwisko.Text.Length < 2)
            {
                MessageBox.Show("Za krótkie nazwisko", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tPesel.Text.Length < 11)
            {
                MessageBox.Show("Pesel powinien składać się z 11 cyfr", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!(tPesel.Text.Length == 11 && (tPesel.Text.All(char.IsDigit))))
            {
                MessageBox.Show("Pesel powinien składać się z 11 cyfr ", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                lmenu.Text = "Cześć! " + tImie.Text.ToString();
                panel3.BringToFront();
                panel2.Hide();
                panel1.Hide();
                panel3.Show();
            }
        }
    }

    /// <summary>
    /// Klasa która ma sprawdzać czy teksty są sobie równe
    /// </summary>
    public class Walidator
    {
        /// <summary>
        /// Sprawdza czy podane teksty są sobie równe
        /// </summary>
        /// <param name="tOdpowiedz1">tekst pierszy</param>
        /// <param name="odp">tekst drugi</param>
        /// <returns>zwraca wartość boolowską</returns>
        public bool SprawdzCzyRowne(string tOdpowiedz1, string odp)
        {
            return string.Equals(tOdpowiedz1, odp, StringComparison.CurrentCultureIgnoreCase);
        }
    }


    /// <summary>
    /// Klasa przechowująca i zwracająca teksty zakończeń
    /// </summary>
    public class Zakonczenia
    {
        private List<string> zakonczenia = new List<string> 
        { 
            "Część ogólna zakończona",
            "Część matematyczna zakończona",
            "Częśc języka polskiego zakończona"
        };

        /// <summary>
        /// Metoda pozwalająca na pobranie zakończenia od danego indexu
        /// </summary>
        /// <param name="index">element listy</param>
        /// <returns>tekst zakończenia</returns>
        public string DajZakonczenie(int index)
        {
            return zakonczenia[index];
        }
    }
}
