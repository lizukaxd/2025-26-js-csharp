using System;

class Program
{
    static void Main()
    {
        Pont p1 = new Pont(2, 5);
        Pont p2 = new Pont(-3, -1);

        Teglalap t = new Teglalap(p1, p2);

        Console.WriteLine("Pont 1: " + p1);
        Console.WriteLine("Pont 2: " + p2);
        Console.WriteLine("Távolság: " + p1.Tavolsag(p2));
        Console.WriteLine("Kerület: " + t.Kerulet());
        Console.WriteLine("Terület: " + t.Terulet());
    }
}
