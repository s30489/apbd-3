namespace apbd;

public class Kontener
{
    private double Masa { get; set; }
    double Wysokosc { get; set; }
    double WagaKontenera { get; set; }
    private double Glebokosc { get; set; }
    private string nrSeryjny = "KON-";
    private double MaxLadownosc { get; set; }

    static int nrKont = 1;

    public void oproznienie()
    {

    }

    public void zaladowanie()
    {

    }
}

class KontenerL : Kontener, lHazardNotifier//Kontener na plyny
{
    private char type = 'L';
}

class KontenerG : Kontener, lHazardNotifier //Kontener na gaz
{
    private char type = 'G';
}

class KontenerC : Kontener //Kontener chlodniczy
{
    private char type = 'C';
}
