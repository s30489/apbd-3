
using apbd;


Byt paliwo = new Plyn("Paliwo", true);
Byt mleko = new Plyn("Mleko", false);

Byt chlor = new Gaz("Chlor", true);
Byt hel = new Gaz("Hel", false);

Byt bananas = new Produkt("bananas", 13.3);
Byt chocolate = new Produkt("Chocolate", 18);
Byt fish = new Produkt("Fish", 2);
Byt meat = new Produkt("Meat", -15);
Byt iceCream = new Produkt("Ice Scream", -18);
Byt frozenPizza = new Produkt("Frozen pizza", -30);
Byt cheese = new Produkt("Cheese", 7.2);
Byt sausages = new Produkt("Sausages", 5);
Byt butter = new Produkt("Butter", 20.5);
Byt eggs = new Produkt("Eggs", 19);


Kontener plyn = new KontenerL(1000, 1000, 1000, 1000);
Kontener gaz = new KontenerG(1000, 1000, 1000, 1000);
Kontener produkt = new KontenerC(1000, 1000, 1000, 1000, "bananas", 14);
Kontener produkt2 = new KontenerC(1000, 1000, 1000, 1000, "Eggs", 19);

plyn.zaladowanie(500, paliwo);
gaz.zaladowanie(1000, chlor);
produkt.zaladowanie(1000, bananas);
produkt2.zaladowanie(1000, eggs);

Statek statek = new Statek(15, 10, 100);

statek.zaladujKontener(plyn);

List<Kontener> list = new List<Kontener>
{
    gaz,
    produkt
};
statek.zaladujKontener(list);
statek.usunKontener(plyn);

gaz.info();
statek.info();

