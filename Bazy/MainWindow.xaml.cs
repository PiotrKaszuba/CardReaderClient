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
using MySql.Data.MySqlClient;
using System.Windows.Controls.Primitives;
using System.Data;
using System.Data.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Data.Entity.Validation;
using LinqToDB.SqlQuery;
using System.Net.Mail;
using System.Net;
using MongoDB.Driver;
using System.Security.Cryptography;

//1406 data too long
//1048 cannot be null
//1062 duplicate
namespace CardReaderClient
{

    class student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int indeks { get; set; }
        public String imie { get; set; }
        public String nazwisko { get; set; }

    }

    class przedmiot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_przed { get; set; }

        public int prow_id { get; set; }
        public string dzien { get; set; }
        public string godzina { get; set; }
        public int sala { get; set; }
        public string nazwa { get; set; }
        //public DateTime? DataDolaczenia { get; set; }



/*
        public przedmiot(int idTean, int id, string kolor)
        {
            idDruzyny = idTean;
            idMeczu = id;
            Kolor_druzyny = kolor;
        }

        public druzyna()
        {

        }
        public override string ToString()
        {
            return "Drużyna: " + idDruzyny + " z meczu: " + idMeczu + " o kolorze: " + Kolor_druzyny;
        }
        */
    }

        class zajecia
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int id_zajec { get; set; }
            public DateTime? data { get; set; }
            public string nazwa { get; set; }
            
            public int typ_zaj { get; set; }
           
        }
        class prowadzacy
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int id_prow { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public string skrot_hasla { get; set; }
    }
        class obowiazek_obecnosci
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int id_obec { get; set; }

            public int stud_id { get; set; }
            public int przed_id { get; set; }
        }
    class obecnosc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int obec_id { get; set; }
        public int zaj_id { get; set; }


    }

        


    class CardReaderDB : DbContext
        {
            public DbSet<student> student { get; set; }
        //public DbSet<raport_dzienny> raport_dzienny { get; set; }
        public DbSet<zajecia> zajecia { get; set; }
            public DbSet<prowadzacy> prowadzacy { get; set; }
            public DbSet<przedmiot> przedmiot { get; set; }
            public DbSet<obowiazek_obecnosci> obowiazek_obecnosci { get; set; }
            public DbSet<obecnosc> obecnosc { get; set; }
            
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<student>().ToTable("student");
            modelBuilder.Entity<zajecia>().ToTable("zajecia");
            modelBuilder.Entity<prowadzacy>().ToTable("prowadzacy");
            modelBuilder.Entity<przedmiot>().ToTable("przedmiot");
            modelBuilder.Entity<obowiazek_obecnosci>().ToTable("obowiazek_obecnosci");
            modelBuilder.Entity<obecnosc>().ToTable("obecnosc");
        }
    }


        public partial class MainWindow : Window
        {/*
            private gracz get_gracz()
            {
                int ids = -1;
                string nicks;
                string steams;
                string nazwas;

                try
                {
                    if (id.Text.Equals(""))
                        ids = -1;
                    else ids = Convert.ToInt32(id.Text);
                }
                catch (System.FormatException e)
                {
                    MessageBox.Show("Zły format ID");
                    return null;
                }
                catch (System.OverflowException e)
                {
                    MessageBox.Show("Przekroczenie wartości zmiennej ID (Int32)");
                    return null;
                }

                if (nick.Text.Equals(""))
                    nicks = null;
                else nicks = nick.Text;
                if (steam.Text.Equals(""))
                    steams = null;
                else
                    steams = steam.Text;
                if (nazwa.Text.Equals(""))
                    nazwas = null;
                else
                    nazwas = nazwa.Text;



                return new gracz { IDGracza = ids, Nick = nicks, SteamID = steams, NazwaKontaWGrze = nazwas };
            }
            */
            public MainWindow()
            {
                InitializeComponent();
            

         
            }


        private void Imie(object sender, RoutedEventArgs e)
        {
            if (nameText.Text.Equals("Imie prowadzącego"))
                nameText.Text = String.Empty;
        }

        private void Nazwisko(object sender, RoutedEventArgs e)
        {
            if (surnameText.Text.Equals("Nazwisko prowadzącego"))
                surnameText.Text = String.Empty;
        }

        private void Haslo(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Equals("Hasło"))
                passwordBox.Password = String.Empty;
        }

        /*
           private void Dodaj(object sender, RoutedEventArgs e)
           {

               gracz g = get_gracz();
               if (g == null) return;

               var mDB = new BazyDB();

               if (!(bool)checkBox.IsChecked)
               {
                   mDB.gracz.Add(g);
                   try
                   {
                       if (mDB.SaveChanges() == 1) send_mail(g);


                   }
                   catch (DbUpdateException ex)
                   {
                       String trace = null;
                       switch (((MySqlException)(ex.InnerException.InnerException)).Number)
                       {
                           case 1062:
                               trace = "Pole ID lub Nick nie jest unikalne";
                               break;
                           case 1048:
                               trace = "Pola ID i Nick nie mogą być puste";
                               break;
                           case 1406:
                               trace = "Pole Nick, SteamID lub NazwaKontaWGrze przekracza maksymalna długość";
                               break;
                           default:
                               trace = "Niezidentyfikowany błąd";
                               break;
                       }


                       MessageBox.Show(trace);

                   }


               }

               else

               {

                   try
                   {
                       MySqlParameter id = new MySqlParameter("@id", g.IDGracza);
                       MySqlParameter nick = new MySqlParameter("@nick", g.Nick);
                       MySqlParameter steam = new MySqlParameter("@steamid", g.SteamID);
                       MySqlParameter nazwa = new MySqlParameter("@nazwakontawgrze", g.NazwaKontaWGrze);

                       if (mDB.Database.ExecuteSqlCommand("dodaj(@id,@nick,@steamid,@nazwakontawgrze)", id, nick, steam, nazwa) == 1) send_mail(g);
                   }
                   catch (MySqlException ex)
                   {
                       String trace = null;
                       int a = 0;
                       switch (ex.Number)
                       {
                           case 1062:
                               trace = "Pole ID lub Nick nie jest unikalne";
                               break;
                           case 1048:
                               trace = "Pola ID i Nick nie mogą być puste";
                               break;
                           case 1406:
                               trace = "Pole Nick, SteamID lub NazwaKontaWGrze przekracza maksymalna długość";
                               break;
                           case 20000:
                               trace = "Nie można dodać gracza o nicku admin lub root";
                               break;
                           case 20001:
                               trace = "Nie można zmienić nicku gracza na admin lub root";
                               break;
                           case 20002:
                               trace = "Nie można usunąć administratora";
                               break;
                           case 1644:
                               trace = ex.Message;
                               break;
                           default:
                               trace = "Niezidentyfikowany błąd";
                               break;
                       }


                       MessageBox.Show(trace);

                   }

               }




               Up();


           }

           private void Zmien(object sender, RoutedEventArgs e)
           {
               gracz g = get_gracz();
               if (g == null) return;


               var mDB = new BazyDB();
               if (!(bool)checkBox.IsChecked)
               {
                   (from p in mDB.gracz where p.IDGracza == g.IDGracza select p).ToList().ForEach(x => { x.Nick = g.Nick; x.SteamID = g.SteamID; x.NazwaKontaWGrze = g.NazwaKontaWGrze; });

                   try
                   {
                       mDB.SaveChanges();

                   }
                   catch (DbUpdateException ex)
                   {
                       String trace = null;
                       switch (((MySqlException)(ex.InnerException.InnerException)).Number)
                       {
                           case 1062:
                               trace = "Pole ID lub Nick nie jest unikalne";
                               break;
                           case 1048:
                               trace = "Pola ID i Nick nie mogą być puste";
                               break;
                           case 1406:
                               trace = "Pole Nick, SteamID lub NazwaKontaWGrze przekracza maksymalna długość";
                               break;
                           default:
                               trace = "Niezidentyfikowany błąd";
                               break;
                       }


                       MessageBox.Show(trace);


                   }
               }
               else
               {
                   try
                   {
                       MySqlParameter id = new MySqlParameter("@id", g.IDGracza);
                       MySqlParameter nick = new MySqlParameter("@nick", g.Nick);
                       MySqlParameter steam = new MySqlParameter("@steamid", g.SteamID);
                       MySqlParameter nazwa = new MySqlParameter("@nazwakontawgrze", g.NazwaKontaWGrze);
                       mDB.Database.ExecuteSqlCommand("zmien(@id,@nick,@steamid,@nazwakontawgrze)", id, nick, steam, nazwa);
                   }
                   catch (MySqlException ex)
                   {
                       String trace = null;
                       switch (ex.Number)
                       {
                           case 1062:
                               trace = "Pole ID lub Nick nie jest unikalne";
                               break;
                           case 1048:
                               trace = "Pola ID i Nick nie mogą być puste";
                               break;
                           case 1406:
                               trace = "Pole Nick, SteamID lub NazwaKontaWGrze przekracza maksymalna długość";
                               break;
                           case 20001:
                               trace = "Nie można zmienić nicku gracza na admin lub root";
                               break;
                           default:
                               trace = "Niezidentyfikowany błąd";
                               break;
                       }


                       MessageBox.Show(trace);

                   }
               }
               Up();
           }

           private void Usun(object sender, RoutedEventArgs e)
           {

               gracz g = get_gracz();
               if (g == null) return;

               var mDB = new BazyDB();
               if (!(bool)checkBox.IsChecked)
               {
                   try
                   {
                       gracz to_delete = (from x in mDB.gracz where x.IDGracza == g.IDGracza select x).Single();
                       mDB.gracz.Remove(to_delete);
                   }
                   catch (InvalidOperationException ex)
                   {
                       MessageBox.Show("Nie ma obiektu o takim ID");
                       return;
                   }



                   try
                   {
                       mDB.SaveChanges();
                   }
                   catch (DbUpdateException ex)
                   {
                       String trace = null;

                       MySqlException exc = (MySqlException)ex.InnerException.InnerException;
                       switch (exc.Number)
                       {
                           case 20002:
                               trace = "Nie można usunąć administratora";
                               break;
                           case 1644:
                               trace = exc.Message;
                               break;
                           default:
                               trace = "Niezidentyfikowany błąd";
                               break;
                       }


                       MessageBox.Show(trace);

                   }
               }
               else
               {
                   //procedura
                   MySqlParameter param = new MySqlParameter("@date", (object)g.IDGracza);
                   try
                   {
                       if (mDB.Database.ExecuteSqlCommand("usun(@date)", param) == 0)
                       {
                           MessageBox.Show("Nie ma obiektu o takim ID");
                       }
                   }
                   catch (MySqlException ex)
                   {
                       String trace = null;
                       switch (ex.Number)
                       {
                           case 20002:
                               trace = "Nie można usunąć administratora";
                               break;
                           case 1644:
                               trace = ex.Message;
                               break;
                           default:
                               trace = "Niezidentyfikowany błąd";
                               break;
                       }


                       MessageBox.Show(trace);

                   }


               }

               Up();
           }



           private void Id(object sender, RoutedEventArgs e)
           {
               if (id.Text.Equals("Wpisz id"))
                   id.Text = String.Empty;

           }

           private void Nick(object sender, RoutedEventArgs e)
           {
               if (nick.Text.Equals("Wpisz nick"))
                   nick.Text = String.Empty;
           }

           private void IdSteam(object sender, RoutedEventArgs e)
           {
               if (steam.Text.Equals("Wpisz steam id"))
                   steam.Text = String.Empty;
           }

           private void NickWGrze(object sender, RoutedEventArgs e)
           {
               if (nazwa.Text.Equals("Wpisz nazwe konta w grze"))
                   nazwa.Text = String.Empty;
           }

           private void RowDoubleClick(object sender, MouseButtonEventArgs e)
           {
               DataGridRow rowContainer = (DataGridRow)sender;
               gracz gra = (gracz)rowContainer.Item;


           dataGrid.ItemsSource = Bazy.Widoki.ReadActivity(gra.IDGracza, Bazy.Widoki.conn);

           object b = gra.SteamID;
               object c = gra.NazwaKontaWGrze;
               object d = gra.DataDolaczenia;

               if (b != System.DBNull.Value)
                   steam.Text = (String)b;
               else steam.Text = "";
               if (c != System.DBNull.Value)
                   nazwa.Text = (String)c;
               else nazwa.Text = "";

               if (d != System.DBNull.Value && d != null)
                   label.Content = ((DateTime)d).ToLongTimeString();
               else label.Content = "";

               id.Text = Convert.ToString(gra.IDGracza);
               nick.Text = gra.Nick;



           }
           */

        static byte[] compute(byte[] bytes, byte[] Salt, HashAlgorithm alg, Boolean use_salt)
        {
            if (!use_salt)
                return alg.ComputeHash(bytes);
            byte[] salted_input = new byte[Salt.Length + bytes.Length];
            Salt.CopyTo(salted_input, 0);
            bytes.CopyTo(salted_input, Salt.Length);
            return alg.ComputeHash(salted_input);
        }



        static byte[] MD5(byte[] bytes, byte[] Salt, Boolean use_salt)
        {
            MD5CryptoServiceProvider instance = new MD5CryptoServiceProvider();

            return compute(bytes, Salt, instance, use_salt);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            String imie = nameText.Text;
            String nazwisko = surnameText.Text;


            String haslo = passwordBox.Password;
            byte[] bypass = System.Text.Encoding.Default.GetBytes(haslo);

            String hashed = ByteArrayToString(MD5(bypass, null, false));
         
            var mDB = new CardReaderDB();
            IQueryable < prowadzacy > lista = (from x in mDB.prowadzacy where x.imie.Equals(imie) && x.nazwisko.Equals(nazwisko) && x.skrot_hasla.Equals(hashed) select x);

            if (lista.Count() == 0)
                MessageBox.Show("Nie znaleziono prowadzącego o podanych danych.");
            else
            {
                prowadzacy logged = lista.Single();

                this.Width = 1000;
                this.Height = 500;
                this.Content = new Bazy.Widoki();
            }

            
        }

    
    }
    
}