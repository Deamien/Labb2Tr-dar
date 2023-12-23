namespace Labb2Trådar
{
    class Program
    {
        static void Main(string[] args)
        {
            static Acceleration CreateAcceleration()
            {
                return new Acceleration(LiveRace);
            }

            // Skapa en statisk samling av trådar
            List<Task> trådar = new();

            // Skapa bilar och trådar
            Bil bil1 = new Bil("Bil 1");
            trådar.Add(Task.Run(() => CreateAcceleration().Kör(bil1)));

            Bil bil2 = new Bil("Bil 2");
            trådar.Add(Task.Run(() => CreateAcceleration().Kör(bil2)));

            // Vänta på att båda trådarna ska avslutas innan programmet avslutas
            Task.WaitAll(trådar.ToArray());

            while (true)
            {
                Console.WriteLine("Tryck på Enter när som helst för att skriva ut status eller skriv 'avsluta' för att avsluta programmet.");
                ConsoleKeyInfo nyckelinfo = Console.ReadKey(intercept: true);

                if (nyckelinfo.Key == ConsoleKey.Enter)
                {
                    SkrivUtStatus(bil1);
                    SkrivUtStatus(bil2);

                    SkrivUtVinnaren(bil1, bil2);
                }
                else if (nyckelinfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        static void SkrivUtVinnaren(Bil bil1, Bil bil2)
        {
            if (bil1.Position > bil2.Position)
            {
                Console.WriteLine($"{bil1.Namn} vinner loppet!");
            }
            else if (bil1.Position < bil2.Position)
            {
                Console.WriteLine($"{bil2.Namn} vinner loppet!");
            }
            else
            {
                Console.WriteLine("Det är oavgjort. Ingen vinner loppet.");
            }
        }

        static void LiveRace(Bil bil)
            {
                Console.WriteLine($"{bil.Namn}: Position {bil.Position:F2} km, Hastighet {bil.Hastighet:F2} km/h");
            }

            static void SkrivUtStatus(Bil bil)
            {
                Console.WriteLine($"Status för {bil.Namn}: Position {bil.Position:F2} km, Hastighet {bil.Hastighet:F2} km/h, Tid förlorad {TidFörloradMeddelande(bil):F2}");
            }

           static string TidFörloradMeddelande(Bil bil)
            {
                return $"{bil.Namn} förlorade {bil.AckumuleradFörloradTid:F2} sekunder under tävlingen.";
            }
    }
    
}
