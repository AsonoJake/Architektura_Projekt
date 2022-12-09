// See https://aka.ms/new-console-template for more information
using Architektura_Projekt;
using System.IO.Pipes;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace Architektura_Projekt
{
    public class Program
    {
        public static string Randm()
        {
            Random rand = new Random();
            string str = "";
            int randValue = rand.Next(0, 2);
            if (randValue == 0)
            {
                randValue = rand.Next(0, 8);
                str = str + Convert.ToString(randValue);
                randValue = rand.Next(0, 6);
                str = str + Convert.ToChar(randValue + 65);
            }
            else
            {
                randValue = rand.Next(0, 6); 
                str = str + Convert.ToChar(randValue + 65);
                randValue = rand.Next(0, 8);
                str = str + Convert.ToString(randValue);
            }
            return str;
        } // Losowanie wartości do przypisania do zmiennych
        public static Dictionary<string, string> Zmienne = new Dictionary<string, string>(8); // Tworzenie słownika z podstawowymi zmiennymi
        public static Dictionary<int, string> Pamiec = new Dictionary<int, string>(65536); // Tworzenie słownika z pamięci
        public static void Pocz()
        {
            
            Zmienne.Add("AH", Randm());
            Zmienne.Add("AL", Randm());
            Zmienne.Add("BH", Randm());
            Zmienne.Add("BL", Randm());
            Zmienne.Add("CH", Randm());
            Zmienne.Add("CL", Randm());
            Zmienne.Add("DH", Randm());
            Zmienne.Add("DL", Randm());
        } // Generowanie początkowych wartości zmiennych (losowo do zrobienia)
        public static void Pocz2()
        {
            for (int i = 1; i < 65537; i++)
            {
                Pamiec.Add(i, "00");
            }
        } // Generowanie pamieci
        
        public static void Sprawdz()
        {
            Console.Clear();
            foreach (string item in Zmienne.Keys)
            {
                Console.WriteLine($"{item} = {Zmienne[item]}");
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        } // Wyświetlanie wartości zmiennych
        
        public static void Pierw()
        {
            char t1, t2;
            Console.Clear();
            foreach (string key in Zmienne.Keys)
            {
                do
                {
                    Console.Write($"Podaj zmienną {key}: ");
                    Zmienne[key] = Console.ReadLine();
                    Console.Clear();
                    if (Zmienne[key].Length == 2)
                    {
                        t1 = Zmienne[key][0];
                        t2 = Zmienne[key][1];
                        if (t1 == '0' || t1 == '1' || t1 == '2' || t1 == '3' || t1 == '4' || t1 == '5' || t1 == '6' || t1 == '7' || t1 == '8' || t1 == '9' || t1 == 'A' || t1 == 'B' || t1 == 'C' || t1 == 'D' || t1 == 'E' || t1 == 'F')
                        {
                            if (t2 == '0' || t2 == '1' || t2 == '2' || t2 == '3' || t2 == '4' || t2 == '5' || t2 == '6' || t2 == '7' || t2 == '8' || t2 == '9' || t2 == 'A' || t2 == 'B' || t2 == 'C' || t2 == 'D' || t2 == 'E' || t2 == 'F')
                            {
                                break;
                            }
                            else Console.WriteLine("Zmienna nie została ustawiona poprawnie"); Console.WriteLine("Spróbuj ponownie"); continue;
                        }
                        else Console.WriteLine("Zmienna nie została ustawiona poprawnie"); Console.WriteLine("Spróbuj ponownie"); continue;
                    }
                    else Console.WriteLine("Zmienna nie została ustawiona poprawnie"); Console.WriteLine("Spróbuj ponownie");
                } while (true);
            }
            Console.Clear();
            Console.WriteLine("Akcja pomyślna");
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        } // Przypisywanie nowych wartości zmiennych przez użytkownika
        
        public static void Drugie()
        {
            Console.Clear();
            Console.WriteLine("Które chcesz przekopiować i do którego? (wybierz dwa po spacji)");
            Console.WriteLine("1 - AH");
            Console.WriteLine("2 - AL");
            Console.WriteLine("3 - BH");
            Console.WriteLine("4 - BL");
            Console.WriteLine("5 - CH");
            Console.WriteLine("6 - CL");
            Console.WriteLine("7 - DH");
            Console.WriteLine("8 - DL");
            Console.WriteLine("0 - Powrót");
            Console.Write("Wybór: ");
            string temp = Console.ReadLine();
            if (temp.Count() != 3 && temp.Count(c => !Char.IsWhiteSpace(c)) != 2 || temp.Count() == 3 && temp.Count(c => !Char.IsWhiteSpace(c)) != 2 || temp == "0" || temp == "0 " || temp == " 0")
            {
                Console.Clear();
                Console.WriteLine("Błędnie wpisany wybór / Wracam");
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                Console.ReadKey();
                return;
            }
            else
            {
                string wybor1 = temp.Split(' ')[0], wybor2 = temp.Split(' ')[1];
                if (wybor1 == "1" || wybor1 == "2" || wybor1 == "3" || wybor1 == "4" || wybor1 == "5" || wybor1 == "6" || wybor1 == "7" || wybor1 == "8")
                {
                    if (wybor2 == "1" || wybor2 == "2" || wybor2 == "3" || wybor2 == "4" || wybor2 == "5" || wybor2 == "6" || wybor2 == "7" || wybor2 == "8")
                    {
                        string temp1 = Zmienne.ElementAt(int.Parse(wybor1) - 1).Key, temp2 = Zmienne.ElementAt(int.Parse(wybor2) - 1).Key;
                        Zmienne[temp2] = Zmienne[temp1];
                    }
                    else return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Niepoprawny wybór");
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                    Console.ReadKey();
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("Akcja pomyślna");
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        } // Kopiowanie wartości zmiennych

        public static void Trz()
        {
            Console.Clear();
            Console.WriteLine("Które chcesz zamienić i z którym? (wybierz dwa po spacji)");
            Console.WriteLine("1 - AH");
            Console.WriteLine("2 - AL");
            Console.WriteLine("3 - BH");
            Console.WriteLine("4 - BL");
            Console.WriteLine("5 - CH");
            Console.WriteLine("6 - CL");
            Console.WriteLine("7 - DH");
            Console.WriteLine("8 - DL");
            Console.WriteLine("0 - Powrót");
            Console.Write("Wybór: ");
            string temp = Console.ReadLine();
            string zmian = "";
            if (temp.Count() != 3 && temp.Count(c => !Char.IsWhiteSpace(c)) != 2 || temp.Count() == 3 && temp.Count(c => !Char.IsWhiteSpace(c)) != 2 || temp == "0" || temp == "0 " || temp == " 0")
            {
                Console.Clear();
                Console.WriteLine("Błędnie wpisany wybór / Wracam");
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                Console.ReadKey();
                return;
            }
            else
            {
                string wybor1 = temp.Split(' ')[0], wybor2 = temp.Split(' ')[1];
                if (wybor1 == "1" || wybor1 == "2" || wybor1 == "3" || wybor1 == "4" || wybor1 == "5" || wybor1 == "6" || wybor1 == "7" || wybor1 == "8")
                {
                    if (wybor2 == "1" || wybor2 == "2" || wybor2 == "3" || wybor2 == "4" || wybor2 == "5" || wybor2 == "6" || wybor2 == "7" || wybor2 == "8")
                    {
                        string temp1 = Zmienne.ElementAt(int.Parse(wybor1) - 1).Key, temp2 = Zmienne.ElementAt(int.Parse(wybor2) - 1).Key;
                        zmian = Zmienne[temp1];
                        Zmienne[temp1] = Zmienne[temp2];
                        Zmienne[temp2] = zmian;
                    }
                    else return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Niepoprawny wybór");
                    Console.ReadKey();
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("Akcja pomyślna");
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        } // Zamiana wartości zmiennych
        
        public static void Cztery()
        {
            do
            {
                string temp;
                Console.Clear();
                Console.WriteLine("Wybierz co chcesz zrobić?");
                Console.WriteLine("1 - Inwersja NOT");
                Console.WriteLine("2 - Dodanie INC");
                Console.WriteLine("3 - Odejmowanie DEC");
                Console.WriteLine("0 - Powrót");
                Console.Write("Wybór: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Na którym chcesz wykonać operację?: ");
                        Console.WriteLine("1 - AH");
                        Console.WriteLine("2 - AL");
                        Console.WriteLine("3 - BH");
                        Console.WriteLine("4 - BL");
                        Console.WriteLine("5 - CH");
                        Console.WriteLine("6 - CL");
                        Console.WriteLine("7 - DH");
                        Console.WriteLine("8 - DL");
                        Console.WriteLine("0 - Powrót");
                        Console.Write("Wybór: ");
                        temp = Console.ReadLine();
                        if (temp.Count() == 1 && temp != "0")
                        {
                            int i = Convert.ToInt32(Zmienne.ElementAt(int.Parse(temp) - 1).Value, 16);
                            string s = Convert.ToString(i, 2), dwojk = "";
                            char[] c = s.ToCharArray();
                            foreach (char ch in c)
                            {
                                if (ch == '1')
                                {
                                    dwojk += "0";
                                }
                                else
                                {
                                    dwojk += "1";
                                }
                            }
                            int licz = 8 - dwojk.Length;
                            while (licz > 0)
                            {
                                dwojk = "1" + dwojk;
                                licz--;
                            }
                            Zmienne[Zmienne.ElementAt(int.Parse(temp) - 1).Key] = Convert.ToString(Convert.ToInt32(dwojk, 2), 16);
                            Console.Clear();
                            Console.WriteLine("Akcja pomyślna");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                            break;
                        }
                        else if (temp == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("Wracam");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Niepoprawny wybór");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Na którym chcesz wykonać operację?: ");
                        Console.WriteLine("1 - AH");
                        Console.WriteLine("2 - AL");
                        Console.WriteLine("3 - BH");
                        Console.WriteLine("4 - BL");
                        Console.WriteLine("5 - CH");
                        Console.WriteLine("6 - CL");
                        Console.WriteLine("7 - DH");
                        Console.WriteLine("8 - DL");
                        Console.WriteLine("0 - Zakończ");
                        Console.Write("Wybór: ");
                        temp = Console.ReadLine();
                        if (temp.Count() == 1 && temp != "0")
                        {
                            int i = Convert.ToInt32(Zmienne.ElementAt(int.Parse(temp) - 1).Value, 16) + 1;
                            Zmienne[Zmienne.ElementAt(int.Parse(temp) - 1).Key] = Convert.ToString(i, 16);
                            Console.Clear();
                            Console.WriteLine("Akcja pomyślna");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                            break;
                        }
                        else if (temp == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("Wracam");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Niepoprawny wybór");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Na którym chcesz wykonać operację?: ");
                        Console.WriteLine("1 - AH");
                        Console.WriteLine("2 - AL");
                        Console.WriteLine("3 - BH");
                        Console.WriteLine("4 - BL");
                        Console.WriteLine("5 - CH");
                        Console.WriteLine("6 - CL");
                        Console.WriteLine("7 - DH");
                        Console.WriteLine("8 - DL");
                        Console.WriteLine("0 - Zakończ");
                        Console.Write("Wybór: ");
                        temp = Console.ReadLine();
                        if (temp.Count() == 1 && temp != "0")
                        {
                            int i = Convert.ToInt32(Zmienne.ElementAt(int.Parse(temp) - 1).Value, 16) - 1;
                            Zmienne[Zmienne.ElementAt(int.Parse(temp) - 1).Key] = Convert.ToString(i, 16);
                            Console.Clear();
                            Console.WriteLine("Akcja pomyślna");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                            break;
                        }
                        else if (temp == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("Wracam");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Niepoprawny wybór");
                            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Wracam");
                        Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Niepoprawny wybór");
                        Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                        Console.ReadKey();
                        break;

                }
            } while (true);
        }  // Dodawanie, odejmowanie i inwersja

        public static void Piec()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Co chcesz zrobić?");
                Console.WriteLine("1 - Operacja AND");
                Console.WriteLine("2 - Operacja OR");
                Console.WriteLine("3 - Operacja XOR");
                Console.WriteLine("4 - Operacja ADD");
                Console.WriteLine("5 - Operacja SUB");
                Console.WriteLine("0 - Zakończ");
                Console.Write("Wybór: ");
                switch (Console.ReadLine())
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Wracam");
                        Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Niepoprawny wybór");
                        Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                        Console.ReadKey();
                        break;
                }
            } while (true);
        } // AND, OR, XOR, ADD, SUB

        static void Main(string[] args)
        {
            Pocz(); // Inicjowanie
            do
            {
                Console.Clear();
                Console.WriteLine("Witaj, co chciałbyś zrobić?: ");
                Console.WriteLine("1 - Wprowadź wartości");
                Console.WriteLine("2 - Przekopiuj wartości");
                Console.WriteLine("3 - Zamień wartości");
                Console.WriteLine("4 - Inne funkcje 3.5");
                Console.WriteLine("5 - Inne funkcje 4.0");
                Console.WriteLine("6 - Wyświetl wartości");
                Console.WriteLine("0 - Zakończ");
                Console.Write("Wybór: ");
                switch (Console.ReadLine()) // Wybór
                {
                    case "1":
                        Pierw();
                        break;
                    case "2":
                        Drugie();
                        break;
                    case "3":
                        Trz();
                        break;
                    case "4":
                        Cztery();
                        break;
                    case "5":
                        Piec(); // Do zrobienia
                        break;
                    case "6":
                        Sprawdz();
                        break;
                    case "7":
                        Randm();
                        Console.ReadKey();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Zakończono działanie programu");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Niepoprawny wybór");
                        Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}
