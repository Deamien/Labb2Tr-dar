using Labb2Trådar;

public class Acceleration
{
    private readonly Action<Bil> LiveRaceCallback;

    public Acceleration(Action<Bil> LiveRaceCallback)
    {
        this.LiveRaceCallback = LiveRaceCallback;
    }

    public void Kör(object state)
    {
        Bil bil = (Bil)state;

        Console.Write($"{bil.Namn} startar!");
        bil.stopp.Start();

        while (bil.Position < bil.Sträcka) // Fortsätt köra tills sträckan är täckt
        {
            // hastighet
            bil.Position += bil.Hastighet / 3600.0; // Konvertera hastighet från km/h till km/s

            LiveRaceCallback(bil);

            if (bil.Position >= 75 && !bil.HarLoppetAvslutats())
            {
                bil.AvslutaLopp();
                break;
            } 

            Thread.Sleep(100);
        }
    }
}
