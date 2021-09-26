using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool spel = true;
            while (spel == true)
            {
                int högtNummer = 0;
                int försök = 0;
                bool meny = true;

                while (meny == true)
                {
                    Console.WriteLine("Välkommen till gissa numret spelet! Vilken svårighetsgrad vill du ha?");
                    Console.WriteLine("(1) Lätt");
                    Console.WriteLine("(2) Medel");
                    Console.WriteLine("(3) Svår");
                    Console.WriteLine("(4) Jättesvår");
                    Console.WriteLine("(5) Vansinnigtsvår");

                    string svårighetsGrad = Console.ReadLine();

                    switch (svårighetsGrad)
                    {
                        case "1":
                        case "(1)":
                            högtNummer = 15;
                            försök = 6;
                            meny = false;
                            break;

                        case "2":
                        case "(2)":
                            högtNummer = 30;
                            försök = 6;
                            meny = false;
                            break;

                        case "3":
                        case "(3)":
                            högtNummer = 50;
                            försök = 5;
                            meny = false;
                            break;

                        case "4":
                        case "(4)":
                            högtNummer = 75;
                            försök = 5;
                            meny = false;
                            break;

                        case "5":
                        case "(5)":
                            högtNummer = 100;
                            försök = 4;
                            meny = false;
                            break;

                        default:
                            Console.WriteLine("Felaktig inmatning! Försök igen.");
                            break;
                    }
                }

                Console.WriteLine("Jag tänker på ett nummer mellan 1 och {0}. Kan du gissa vilket? Du får {1} försök.", högtNummer, försök);
                int svar = 0;
                Random random = new Random();
                int number = random.Next(1, högtNummer + 1);
                bool fel = false;

                for (int varv = 0; varv < försök; varv++)
                {
                    try
                    {
                        svar = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Bara siffror är acceptabla att mata in! Försök igen.");
                        varv--;
                        fel = true;
                    }
                    if (fel == false)
                    {
                        CheckGuess(number, svar);
                    }
                    if (number == svar)
                    {
                        varv = försök;
                    }
                    fel = false;
                }

                if (number != svar)
                {
                    Console.WriteLine("Tyvärr du lyckades inte gissa talet på {0} försök!", försök);
                }

                Console.WriteLine("");
                Console.WriteLine("Vill du spela igen?");
                Console.WriteLine("Ja -- starta om spelet.");
                Console.WriteLine("Nej -- avsluta spelet.");

                string spelaIgen = Console.ReadLine();

                switch (spelaIgen)
                {
                    case "Ja":
                    case "ja":
                        break;

                    default:
                        spel = false;
                        break;
                }
            }

            Console.ReadKey();





        }

        public static void CheckGuess(int number, int svar)
        {
            if (svar + 5 == number || svar + 4 == number || svar + 3 == number || svar + 2 == number || svar + 1 == number || svar - 5 == number || svar - 4 == number || svar - 3 == number || svar - 2 == number || svar - 1 == number)
            {
                Console.WriteLine("Det brinner! Du är väldigt nära det rätta talet!");
            }

            else if (svar > number + 40 || svar < number - 40)
            {
                Console.WriteLine("Det är iskallt! Du är väldigt långt ifrån det rätta talet!");
            }

            else if (svar < number)
            {
                Random random = new Random();
                int lågt = random.Next(1, 5);
                if (lågt == 1)
                {
                    Console.WriteLine("Tyvärr du gissade för lågt!");
                }
                else if (lågt == 2)
                {
                    Console.WriteLine("Det där var för lågt! Bättre kan du!");
                }
                else if (lågt == 3)
                {
                    Console.WriteLine("För lågt. Är detta för svårt?");
                }
                else
                {
                    Console.WriteLine("Du gissade för lågt. Kanske borde du sänka svårighetsgrad...");
                }
            }

            else if (svar > number)
            {
                Random random = new Random();
                int högt = random.Next(1, 5);
                if (högt == 1)
                {
                    Console.WriteLine("Tyvärr du gissade för högt!");
                }
                else if (högt == 2)
                {
                    Console.WriteLine("Det verkar som att du gissade för högt. Försök igen!");
                }
                else if (högt == 3)
                {
                    Console.WriteLine("Du gissade för högt! Är turen inte med dig idag?");
                }
                else
                {
                    Console.WriteLine("För högt... försöker du ens?");
                }
            }

            else
            {
                Random random = new Random();
                int rätt = random.Next(1, 4);
                if (rätt == 1)
                {
                    Console.WriteLine("Woho! Du gjorde det!");
                }
                else if (rätt == 2)
                {
                    Console.WriteLine("Grattis! du gissade rätt!");
                }
                else
                {
                    Console.WriteLine("Imponerande! Du har vunnit!");
                }
            }
        }
    }
}
