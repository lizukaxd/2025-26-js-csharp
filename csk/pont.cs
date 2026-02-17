using System;

public class Pont
{
    private int x;
    private int y;

    // Paraméter nélküli konstruktor – origo
    public Pont()
    {
        x = 0;
        y = 0;
    }

    // Két paraméteres konstruktor
    public Pont(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // Egy paraméteres konstruktor – véletlenszerű [-N..N]
    public Pont(int n)
    {
        Random rnd = new Random();
        x = rnd.Next(-n, n + 1);
        y = rnd.Next(-n, n + 1);
    }

    // Property-k
    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    // ToString – [x;y]
    public override string ToString()
    {
        return $"[{x};{y}]";
    }

    // Távolság az origótól
    public double TavolsagOrigotol()
    {
        return Math.Sqrt(x * x + y * y);
    }

    // Két pont távolsága
    public double Tavolsag(Pont masik)
    {
        int dx = x - masik.x;
        int dy = y - masik.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    // Síknegyed meghatározása
    public int Siknegyed()
    {
        if (x < 0 && y > 0) return 1;
        if (x < 0 && y < 0) return 2;
        if (x > 0 && y < 0) return 3;
        if (x > 0 && y > 0) return 4;

        return 0; // tengelyen van
    }
}
