public class Teglalap
{
    private Pont p1;
    private Pont p2;

    public Teglalap(Pont p1, Pont p2)
    {
        this.p1 = p1;
        this.p2 = p2;
    }

    // Kerület
    public double Kerulet()
    {
        double szelesseg = Math.Abs(p2.X - p1.X);
        double magassag = Math.Abs(p2.Y - p1.Y);
        return 2 * (szelesseg + magassag);
    }

    // Terület
    public double Terulet()
    {
        double szelesseg = Math.Abs(p2.X - p1.X);
        double magassag = Math.Abs(p2.Y - p1.Y);
        return szelesseg * magassag;
    }
}
