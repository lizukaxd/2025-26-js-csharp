using System;
using System.Collections.Generic;
using System.IO;

class PostIt
{
    //az osztály egy összetett adatszerkezet
    //az objektum egy adat, aminek a típusa az osztály amit megadtunk
    public string HatterSzin { get; set; }
    public string Szoveg { get; set; }
    public string SzovegSzin { get; set; }

    public PostIt(string hatterSzin, string szoveg, string szovegSzin)
    {
        HatterSzin = hatterSzin;
        Szoveg = szoveg;
        SzovegSzin = szovegSzin;
    }
//a property 
    public void Torol()//osztaly metodus 
    {
        Szoveg = "";
    }

    public override string ToString()
    {
        return $"[{HatterSzin}] \"{Szoveg}\" ({SzovegSzin})";
    }
}

class Allat
{
    // Az állat neve
    public string Nev { get; set; }
    public int Ehseg { get; set; }
    public int Szomj { get; set; }

    //konstruktor egy specialis metodus ami beallitja az uj peldany attributumainak kezdoertekeit

    public Allat(string nev)
    {
        Nev = nev;
        Ehseg = 50;
        Szomj = 50;
    }
    public void Eszik()
    {
        Ehseg--;
    }

    public void Iszik()
    {
        Szomj--;
    }

    public void Jatszik()
    {
        Ehseg++;
        Szomj++;
    }

    public override string ToString()
    {
        return $"{Nev} - Éhség: {Ehseg}, Szomj: {Szomj}";
    }
}

// Állatok gyűjteménye, ami fájlból beolvas állatneveket
class Allatok
{
    // Lista az állatok tárolására
    private List<Allat> allatok;
    private Random random;

    // Konstruktor, ami beolvassa az adatok.txt fájlból az állatneveket
    public Allatok(string fajlnev)
    {
        allatok = new List<Allat>();
        random = new Random();

        string[] sorok = File.ReadAllLines(fajlnev);
        foreach (string sor in sorok)
        {
            Allat allat = new Allat(sor);
            allatok.Add(allat);
        }
    }

    private Allat VeletlenAllat()
    {
        int index = random.Next(allatok.Count);
        return allatok[index];
    }

    public void EtetVeletlenul()
    {
        for (int i = 0; i < 10; i++)
        {
            VeletlenAllat().Eszik();
        }
    }

    public void ItatVeletlenul()
    {
        for (int i = 0; i < 10; i++)
        {
            VeletlenAllat().Iszik();
        }
    }

    public void JatszikVeletlenul()
    {
        for (int i = 0; i < 10; i++)
        {
            VeletlenAllat().Jatszik();
        }
    }

    public override string ToString()
    {
        string eredmeny = "Állatok listája:\n";
        foreach (Allat allat in allatok)
        {
            eredmeny += allat.ToString() + "\n";
        }
        return eredmeny;
    }
}

class Program
{
    static void Main()
    {
        // 1. feladat: PostIt példák
        PostIt elso = new PostIt("sárga", "Első ötlet", "kék");
        PostIt masodik = new PostIt("rózsaszín", "Hurrá!", "fekete");
        PostIt harmadik = new PostIt("zöld", "Szuper!", "barna");

        //adattagok/attributumok változtatása
        elso.HatterSzin = "narancs";
        elso.SzovegSzin = "piros";
        elso.Torol();

        Console.WriteLine("PostIt címkék:");
        Console.WriteLine(elso);
        Console.WriteLine(masodik);
        Console.WriteLine(harmadik);
        Console.WriteLine();

        Allatok allatok = new Allatok("adatok.txt");

        allatok.EtetVeletlenul();
        
        allatok.ItatVeletlenul();
        
        allatok.JatszikVeletlenul();

        Console.WriteLine(allatok);
    }
}
