namespace apbd;

public class Kontener
{
    public double MasaLadunku { get; set; }
    double Wysokosc { get; set; }
    public double WagaKontenera { get; set; }
    private double Glebokosc { get; set; }
    public string NrSeryjny { get; set; }
    protected double MaxLadownosc { get; set; }

    static int nrKont = 1;
    protected double AcceptedKey { get; set; }

    public Kontener(double wysokosc, double wagaKontenera, double glebokosc, double maxLadownosc, char typ, double acceptedKey)
    {
        Wysokosc = wysokosc;
        WagaKontenera = wagaKontenera;
        Glebokosc = glebokosc;
        MaxLadownosc = maxLadownosc;
        NrSeryjny = $"KON-{typ}-{nrKont++}";
        AcceptedKey = acceptedKey;
    }

    public virtual void oproznienie()
    {
        MasaLadunku = 0;
    }

    public virtual void zaladowanie(double masaLadunku, Byt byt)
    {
        if (masaLadunku > MaxLadownosc)
        {
            throw new Exception("OverFlowExeption");
        }
        if (byt.GetKey() != AcceptedKey)
        {
            throw new Exception("Nie można załadować tego typu ładunku");
        }
        MasaLadunku = masaLadunku;
    }

    public void info()
    {
        Console.WriteLine("Wysokość: " + Wysokosc
        + ", Waga: " + WagaKontenera
        + ", Głębokość: " + Glebokosc
        + ", MaxLadowność: " + MaxLadownosc
        + ", NrSeryjny: " + NrSeryjny
       );
    }
}

class KontenerL : Kontener, lHazardNotifier  //Kontener na plyny
{
    private bool NiebezpiecznyLadunek { get; set; }

    public KontenerL(double wysokosc, double wagaKontenera, double glebokosc, double maxLadownosc)
        : base(wysokosc, wagaKontenera, glebokosc, maxLadownosc, 'L', 0)
    {
        
    }
    public override void zaladowanie(double masaLadunku, Byt byt)
    {
        if (byt.GetKey() != AcceptedKey)
        {
            throw new Exception("Nie można załadować tego typu ładunku"); //zły produkt np płyn w kontenerze z gazem
        }
        
        NiebezpiecznyLadunek = byt.Hazardous;
        double maxLadunek = NiebezpiecznyLadunek ? MaxLadownosc * 0.5 : MaxLadownosc * 0.9;
        if (NiebezpiecznyLadunek)
        {
            HazardAlert("Próba wykonania niebezpiecznej operacji");
        }
        if (masaLadunku > maxLadunek)
        {
            throw new Exception("OverFlowExeption");
        }
        MasaLadunku = masaLadunku;
    }

    public override void oproznienie()
    {
        MasaLadunku *= 0.05;
    }
    public void HazardAlert(string message)
    {
        Console.WriteLine(NrSeryjny + ": " + message);
    }
}

class KontenerG : Kontener, lHazardNotifier //Kontener na gaz
{
    private bool NiebezpiecznyLadunek { get; set; }
    
    public KontenerG(double wysokosc, double wagaKontenera, double glebokosc, double maxLadownosc)
        : base(wysokosc, wagaKontenera, glebokosc, maxLadownosc, 'G', 1)
    {
       
    }
    
    public override void zaladowanie(double masaLadunku, Byt byt)
    {
        if (byt.GetKey() != AcceptedKey)
        {
            throw new Exception("Nie można załadować tego typu ładunku"); //zły produkt np płyn w kontenerze z gazem
        }
        
        NiebezpiecznyLadunek = byt.Hazardous;
        
        if (NiebezpiecznyLadunek)
        {
            HazardAlert("Próba wykonania niebezpiecznej operacji");
        }
        
        if (masaLadunku > MaxLadownosc)
        {
            throw new Exception("OverFlowExeption");
        }
        MasaLadunku = masaLadunku;
    }
    
    public void HazardAlert(string message)
    {
        Console.WriteLine(NrSeryjny + ": " + message);
    }
}

class KontenerC : Kontener //Kontener chlodniczy
{
    public string Produkt { get; }
    public double Temperatura { get; }
    public KontenerC(double wysokosc, double wagaKontenera, double glebokosc, double maxLadownosc, string produkt, double temperatura)
        : base(wysokosc, wagaKontenera, glebokosc, maxLadownosc, 'C', 2)
    {
        Produkt = produkt;
        Temperatura = temperatura;
    }

    public override void zaladowanie(double masaLadunku, Byt byt)
    {
        if (byt.GetKey() != AcceptedKey)
        {
            throw new Exception("Nie można załadować tego typu ładunku"); //zły produkt np płyn w kontenerze z gazem
        }

        if (byt.Temperatura > Temperatura)
        {
            throw new Exception("Zła temperatura");
        }
        
        if (byt.Name != Produkt)
        {
            throw new Exception("Zły produkt");
        }

        if (masaLadunku >  MaxLadownosc)
        {
            throw new Exception("OverFlowExeption");
        }

        MasaLadunku = masaLadunku;
    }
}
