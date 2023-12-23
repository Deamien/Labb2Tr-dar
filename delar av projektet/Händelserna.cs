namespace Labb2Trådar
{
    public class Händelserna
    {
        public void HanteraHändelser(object state)
        {

            Bil bil = (Bil)state;

            if (bil.HarLoppetAvslutats())
            {
                return;
            }

            // Slumpa fram en händelse baserat på sannolikheten
            int slumpTal = bil.slumpGenerator.Next(1, 51);

            if (slumpTal <= 1) // 1/50 sannolikhet
            {
                Console.WriteLine($"{bil.Namn} har slut på bensin och behöver tanka. Stannar 50 sekunder.");
                bil.Stanna(50); // 50 sekunders stopp
            }
            else if (slumpTal <= 5)
            {
                Console.WriteLine($"{bil.Namn} har punktering och behöver byta däck. Stannar 30 sekunder.");
                bil.Stanna(30); // 30 sekunders stopp
            }
            else if (slumpTal <= 12)
            {
                Console.WriteLine($"{bil.Namn} har en fågel på vindrutan och behöver tvätta den. Stannar 20 sekunder.");
                bil.Stanna(20); // 20 sekunders stopp
            }
            else if (slumpTal <= 25)
            {
                Console.WriteLine($"{bil.Namn} har motorfel och hastigheten sänks med 40 km/h.");
                bil.MinskaHastighet(40); // Minska hastigheten med 40 km/h
            }
            else if (slumpTal <= 50)
            {
                Console.WriteLine($"{bil.Namn} hanterar inte regnet bra och hastigheten sänks med 20 km/h.");
                bil.MinskaHastighet(20); // Minska hastigheten med 20 km/h
            }
        }
    }
}