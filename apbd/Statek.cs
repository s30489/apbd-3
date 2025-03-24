namespace apbd;

public class Statek
{
    
    public double MaksymalnaPredkosc { get; }
    public int MaksymalnaLiczbaKontenerow { get; }
    public double MaksymalnaWagaKontenerow { get; }
    private List<Kontener> kontenery;

    public Statek(double maksPredkosc, int maksKontenery, double maksWaga)
    {

        MaksymalnaPredkosc = maksPredkosc;
        MaksymalnaLiczbaKontenerow = maksKontenery;
        MaksymalnaWagaKontenerow = maksWaga;
        kontenery = new List<Kontener>();
    }
    
    public void zaladujKontener(Kontener kontener)
    {
        if (kontenery.Count >= MaksymalnaLiczbaKontenerow ||
            kontenery.Sum(k => k.MasaLadunku + k.WagaKontenera) + kontener.MasaLadunku + kontener.WagaKontenera > MaksymalnaWagaKontenerow * 1000)
            throw new Exception("Nie można załadować więcej kontenerów");

        
        kontenery.Add(kontener);
    }

    public void zaladujKontener(List<Kontener> kontenerLista)
    {
        foreach (var kontener in kontenerLista)
        {
            zaladujKontener(kontener);
        }
    }

    public void usunKontener(Kontener kontener)
    {
        kontenery.Remove(kontener);
    }

    public void rozladuj()
    {
        kontenery.Clear();
    }

    public void zamien(Kontener kontener, string nrKontenera)
    {
        kontenery.Add(kontener); //brakuje usuniecia tam gdzie nrSeryjny
    }

    public void zamianaMiedzyStatkami()
    {
        //brak
    }

    public void info()
    {
        string konteneryS = string.Join(", ", kontenery.Select(p => p.NrSeryjny));
        Console.WriteLine("Maksymalna Prędkość: " + MaksymalnaPredkosc +
                          ", Maksymalna Liczba Kontenerow: " + MaksymalnaLiczbaKontenerow +
                          ", Maksymalna Waga Kontenerow: " + MaksymalnaWagaKontenerow +
                          "\nPrzewozi: " + konteneryS
                          
        );
    }

}