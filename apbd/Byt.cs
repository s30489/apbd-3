namespace apbd;

public class Byt
{
    public string Name { get; set; }
    public virtual double GetKey() => -1;
    public virtual bool Hazardous => false;
    public virtual double Temperatura => 0;
    

    public bool hazard()
    {
        return false;
    }
}

public class Plyn : Byt
{
    private bool hazardous;
    public override bool Hazardous => hazardous;
    private double key = 0;

    public Plyn(string name, bool hazardous)
    {
        Name = name;
        this.hazardous = hazardous;
    }

    public override double GetKey() => key;
}

public class Gaz : Byt
{
    private bool hazardous;
    public override bool Hazardous => hazardous;
    private double key = 1;

    public Gaz(string name, bool hazardous)
    {
        Name = name;
        this.hazardous = hazardous;
    }

    public override double GetKey() => key;
}

public class Produkt : Byt
{
    private double temperatura;
    public override double Temperatura => temperatura;
    private double key = 2;

    public Produkt(string name, double temperatura)
    {
        Name = name;
        this.temperatura = temperatura;
    }

    public override double GetKey() => key;
}