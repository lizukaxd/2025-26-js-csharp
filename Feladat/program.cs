using System;

public class Forróital
{
    public string név { get; set; }
    public int ár { get; set; }
    public int cukor { get; set; }

    public Forróital(string név, int ár, int cukor)
    {
        this.név = név;
        this.ár = ár;
        this.cukor = cukor;
    }

    public void ÁremelésRendkívüli()
    {
        ár += 50;
    }

    public void ÁremelésszázalékosÉmeles(int százalék)
    {
        ár += (ár * százalék) / 100;
    }

    public void ÁremelésÁltalános(int összeg)
    {
        ár += összeg;
    }

    public override string ToString()
    {
        return $"Forróital: {név}, Ár: {ár} Ft, Cukor: {cukor}";
    }
}

public class Kávé : Forróital
{
    public int tej { get; set; }

    public Kávé(string név, int ár, int cukor, int tej)
        : base(név, ár, cukor)
    {
        this.tej = tej;
    }

    public override string ToString()
    {
        return $"Kávé: {név}, Ár: {ár} Ft, Cukor: {cukor}, Tej: {tej}";
    }
}

public class Tea : Forróital
{
    public int citrom { get; set; }

    public Tea(string név, int ár, int cukor, int citrom)
        : base(név, ár, cukor)
    {
        this.citrom = citrom;
    }

    public override string ToString()
    {
        return $"Tea: {név}, Ár: {ár} Ft, Cukor: {cukor}, Citrom: {citrom}";
    }
}

class Program
{
    static void Main()
    {
        Forróital forrócsoki = new Forróital("Forrócsoki", 80, 1);

        Tea earlGrey = new Tea("Earl Grey", 100, 1, 1);
        Tea englishBreakfast = new Tea("English Breakfast", 120, 2, 2);
        Tea ceylonGreenTea = new Tea("Ceylon Green Tea", 120, 0, 0);

        Kávé eszpresszó = new Kávé("Eszpresszó", 180, 2, 1);
        Kávé hosszúFekete = new Kávé("Hosszú Fekete", 190, 2, 0);

        Console.WriteLine("=== Eredeti adatok ===");
        Console.WriteLine(forrócsoki);
        Console.WriteLine(earlGrey);
        Console.WriteLine(englishBreakfast);
        Console.WriteLine(ceylonGreenTea);
        Console.WriteLine(eszpresszó);
        Console.WriteLine(hosszúFekete);

        Console.WriteLine("\n=== Áremelések után ===");
        
        forrócsoki.ÁremelésRendkívüli();
        Console.WriteLine($"Forrócsoki rendkívüli emelés után: {forrócsoki}");

        earlGrey.ÁremelésszázalékosÉmeles(10);
        Console.WriteLine($"Earl Grey 10%-os emelés után: {earlGrey}");

        eszpresszó.ÁremelésÁltalános(30);
        Console.WriteLine($"Eszpresszó 30 Ft általános emelés után: {eszpresszó}");
    }
}
