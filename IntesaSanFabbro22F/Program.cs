using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntesaSanFabbro22F
{
    internal class Program
    {
        // classe persona
        public class Persona
        {
            private string _nome;

            public string Nome
            {
                get { return _nome; }
                set
                {
                    _nome = value;
                    if (_nome.Length <= 2)
                    {
                        _nome = "Sconosciuto";
                    }
                }
            }

        }

        // classe conto

        public class Conto : Persona
        {
            private double saldo;
            private bool chiuso = false;

            public double Saldo
            {
                get { return saldo; }
                set
                {
                    saldo = value;
                   
                }
            }

            public bool Chiuso
            {
                get { return chiuso; }
                set
                {
                    chiuso = value;

                }
            }

            // apriconto

            public void Apriconto(string nome, double saldo_input)
            {
                chiuso = false;
                Nome = nome;
                saldo = saldo_input;
            }

            // chiudere un conto

            public void ChiudiConto()
            {
                if (chiuso == true) // conto chiuso
                {
                    Console.Clear();
                    Console.WriteLine("Il conto è già stato chiuso");
                    Console.ReadLine();
                }
                else // conto non chiuso
                {
                    Console.Clear();
                    saldo = 0;
                    chiuso = true;
                    Nome = null;
                    Console.WriteLine("Conto chiuso correttamente!");
                    Console.ReadLine();
                }
            }

            // depositare sul conto

            public void Deposita(double deposito)
            {
                if (chiuso == true) // conto chiuso
                {
                    Console.Clear();
                    Console.WriteLine("Conto chiuso. Impossibile proseguire");
                    Console.ReadLine();
                }
                else // conto non chiuso
                {
                    Console.Clear();
                    saldo += deposito;
                    Console.WriteLine("Saldo depositato correttamente");
                    Console.ReadLine();
                }
            }

            // vedere saldo del conto

            public void VisualizzaSaldo()
            {
                if (chiuso == true) // conto chiuso
                {
                    Console.Clear();
                    Console.WriteLine($"Conto chiuso. Impossibile Proseguire");
                    Console.ReadLine();
                }
                else // conto aperto
                {
                    Console.Clear();
                    Console.WriteLine($"Il saldo del sig.{Nome} è di {saldo} euro");
                    Console.ReadLine();
                }
            }

            // prelevare saldo dal conto

            public void Prelevare(double preleva)
            {
                if (chiuso == true) // conto chiuso
                {
                    Console.Clear();
                    Console.WriteLine($"Conto chiuso. Impossibile Proseguire");
                    Console.ReadLine();
                }
                else // conto aperto
                {
                    if (preleva > saldo)
                    {
                        // input errato
                        Console.Clear();
                        Console.WriteLine("L'importo da prelevare è maggiore rispetto al saldo da lei in possesso");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        saldo -= preleva;
                        Console.WriteLine("Importo prelevato correttamente!");
                        Console.ReadLine();
                    }
                }

            }

            // stato del conto

            public void StatoConto()
            {
                Console.Clear();

                string stato = "";

                // controllo stato conto

                if (chiuso == true) // conto chiuso
                {
                    stato = "CHIUSO";
                }
                else
                {
                    stato = "APERTO";
                }

                Console.WriteLine($"STATO DEL CONTO: {stato}");
                Console.WriteLine($"PROPRIETARIO: {Nome}");
                Console.WriteLine($"SALDO: {saldo}");
                Console.ReadLine();
            }
 
        }

        class Banca
        {
            private Conto[] array = new Conto[100];

            public void Crea()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = new Conto();
                }
            }

            // metodod che ricerca l'utente

            public int Ricerca(string nome)
            {
                int pos = -1;

                for (int i = 0; i < 100; i++)
                {
                    if (array[i].Nome == nome)
                    {
                        
                        pos = i;
                        break;
                    }
                    else if (array[i].Nome == null)
                    {

                        pos = i;
                        break;
                    }
                }

                return pos;
            }
            public void ApriConto(string Nome_Utente, double Saldo)
            {
                int pos = Ricerca(Nome_Utente);
                array[pos].Nome = Nome_Utente;
                array[pos].Apriconto(Nome_Utente, Saldo);

            }

            public void AzzeraConto(string Nome_Utente)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (array[i].Nome == Nome_Utente)
                    {
                        array[i].ChiudiConto();
                        array[i].Nome = null;
                        break;
                    }
                }
            }

            public void VisualizzaSaldo(string Nome_Utente)
            {
                int pos = Ricerca(Nome_Utente);
                Console.WriteLine($"Il saldo del sig.{array[pos].Nome} è di {array[pos].Saldo} euro");
                Console.ReadLine();
            }



        }
        static void Main(string[] args)
        {
            Banca banca = new Banca();
            banca.Crea();
            bool uscita = false;
            bool uscita2 = false;
            while (uscita == false)
            {
                Console.Clear();
                Console.WriteLine("Benvenuto nell'Intesa San Fabbro");
                Console.WriteLine("Vuole lavorare su un singolo conto (1) o su più conti? (2) ");

                switch (Console.ReadLine())
                {
                    case "1": // singolo conto

                        Conto conto = new Conto();
                        uscita2 = false;

                        while (uscita2 == false)
                        {
                            Console.Clear();
                            Console.WriteLine("1) Apri il conto");
                            Console.WriteLine("2) Azzera il conto");
                            Console.WriteLine("3) Deposita sul conto");
                            Console.WriteLine("4) Preleva dal conto");
                            Console.WriteLine("5) Vedi saldo sul conto");
                            Console.WriteLine("6) Visualizza info conto");
                            Console.WriteLine("0) Esci");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Inserisci il nome utente");
                                    string nome = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Inserisci il saldo");
                                    double saldo = Convert.ToDouble(Console.ReadLine());
                                    conto.Apriconto(nome, saldo);
                                    break;

                                case "2":
                                    Console.Clear();
                                    conto.ChiudiConto();
                                    break;

                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Inserisci l'importo da depositare");
                                    conto.Deposita(Convert.ToDouble(Console.ReadLine()));
                                    break;

                                case "4":
                                    Console.Clear();
                                    Console.WriteLine("Inserisci l'importo da prelevare");
                                    conto.Prelevare(Convert.ToDouble(Console.ReadLine()));
                                    break;

                                case "5":
                                    Console.Clear();
                                    conto.VisualizzaSaldo();
                                    break;

                                case "6":
                                    Console.Clear();
                                    conto.StatoConto();
                                    break;

                                case "0":
                                    uscita2 = true;
                                    break;
                            }
                        }

                        break;
                    case "2": // più conti
                        while (uscita2 == false)
                        {
                            
                            
                            Console.Clear();
                            Console.WriteLine("1) Apri il conto");
                            Console.WriteLine("2) Azzera il conto");
                            Console.WriteLine("3) Deposita sul conto");
                            Console.WriteLine("4) Preleva dal conto");
                            Console.WriteLine("5) Vedi saldo sul conto");
                            Console.WriteLine("6) Visualizza info conto");
                            Console.WriteLine("0) Esci");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Inserisci il nome utente");
                                    string nome = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Inserisci il saldo");
                                    double saldo = Convert.ToDouble(Console.ReadLine());
                                    banca.ApriConto(nome, saldo);
                                    break;

                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Inserisci il nome utente");
                                    banca.AzzeraConto(Console.ReadLine());
                                    break;

                                case "3":

                                    break;

                                case "4":

                                    break;

                                case "5":
                                    Console.Clear();
                                    Console.WriteLine("Inserisci il nome utente");
                                    banca.VisualizzaSaldo(Console.ReadLine());
                                    Console.ReadLine();
                                    break;

                                case "6":

                                    break;

                                case "0":
                                    uscita2 = true;
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Input Errato. Reinserire l'input");
                        Console.ReadLine();
                        break;
                }

            }
        }
    }
}


