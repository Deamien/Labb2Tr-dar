using System.Diagnostics;
using System.Threading;


namespace Labb2Trådar
{
    public class Bil
    {
        public string Namn { get; set; }
        public double AckumuleradFörloradTid { get; set; }
        public double Position { get; set; }
        public double Hastighet { get; set; } // km/h
        public string LiveRaceStatus { get; set; }
        public string LedandeBil { get; set; }

        public double Sträcka = 75; // km
        public readonly Random slumpGenerator = new Random();
        private bool TävlingenAvslutas = false;
        public Stopwatch stopp = new Stopwatch();
        public Timer händelseTimer;
        // Håller reda på vilken bil som för närvarande leder loppet

        public void AvslutaLopp()
        {
            TävlingenAvslutas = true;

        händelseTimer.Change(Timeout.Infinite, Timeout.Infinite);
        händelseTimer.Dispose();
        }

        public bool HarLoppetAvslutats()
        {
            return TävlingenAvslutas;
        }
        
        private readonly Händelserna händelserna = new Händelserna();

        public Bil(string namn)
        {
            // Alla bilar har samma initiala hastighetd
            Hastighet = 600;
            Namn = namn;
            Position = 0.0;

            // Skapa en timer för händelser med en period på 30 sekunder

            händelseTimer = new Timer(händelserna.HanteraHändelser, this, TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(30));

        }

        public void MinskaHastighet(double minskning)
        {
            lock (this) // Lås för trådsäkerhet
            {
                Hastighet -= minskning;
            }
        }

        public void Stanna(int sekunder)
        {
            Thread.Sleep(sekunder * 1000);
            AckumuleradFörloradTid += sekunder;
        }

        public double TidFörlorad()
        {
            return stopp.Elapsed.TotalSeconds;
        }
    }

}