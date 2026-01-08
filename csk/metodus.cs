//1
Console.Write("elso szam: ");
double sz1 = Convert.ToDouble(Console.ReadLine());
Console.Write("masodik szam: ");
double sz2 = Convert.ToDouble(Console.ReadLine());

Nagyobb(sz1, sz2);

static void Nagyobb(double a, double b)
{
    if (a > b) Console.WriteLine("Nagyobb szám: " + a);
    else Console.WriteLine("Nagyobb szám: " + b);
}
//2
Console.Write("Év: ");
int ev = Convert.ToInt32(Console.ReadLine());
Console.Write("Hónap: ");
int honap = Convert.ToInt32(Console.ReadLine());
Console.Write("Nap: ");
int nap = Convert.ToInt32(Console.ReadLine());

HosszuDatum(ev, honap, nap);

static void HosszuDatum(int ev, int honap, int nap)
{
    string[] honapNevek = {"", "január", "február", "március", "április", "május", "június", 
                           "július", "augusztus", "szeptember", "október", "november", "december"};
    Console.WriteLine($"{ev}. {honapNevek[honap]} {nap}.");
}

//3
Console.Write("n: ");
int n = Convert.ToInt32(Console.ReadLine());

Szorzotabla(n);

static void Szorzotabla(int n)
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            Console.Write($"{i * j,4}");
        }
        Console.WriteLine();
    }
}

//4 
Random rnd = new Random();

Console.WriteLine("Nem: " + Nem());
Console.WriteLine("Monogram: " + Monogram());
Console.WriteLine("Születési idő: " + SzuletesiIdo());
Console.WriteLine("Rendszám: " + Rendszam());

static string Nem()
{
    Random r = new Random();
    return r.Next(2) == 0 ? "Férfi" : "Nő";
}

static string Monogram()
{
    Random r = new Random();
    char c1 = (char)r.Next('A', 'Z' + 1);
    char c2 = (char)r.Next('A', 'Z' + 1);
    return $"{c1}.{c2}.";
}

static string SzuletesiIdo()
{
    Random r = new Random();
    int ev = r.Next(1950, 2025);
    int honap = r.Next(1, 13);
    int nap = r.Next(1, 29);
    string[] honapNevek = {"", "január", "február", "március", "április", "május", "június", 
                           "július", "augusztus", "szeptember", "október", "november", "december"};
    return $"{ev}. {honapNevek[honap]} {nap}.";
}

static string Rendszam()
{
    Random r = new Random();
    char c1 = (char)r.Next('A', 'Z' + 1);
    char c2 = (char)r.Next('A', 'Z' + 1);
    char c3 = (char)r.Next('A', 'Z' + 1);
    int szam = r.Next(100, 1000);
    return $"{c1}{c2}{c3}-{szam}";
}

//5 
SzamKitalalosJatek();

static void SzamKitalalosJatek()
{
    char ujra;
    do
    {
        int szint = SzintValasztas();
        int gondoltSzam = veletlen(szint);
        int probalkozasok = 0;
        bool talalt = false;

        Console.WriteLine("Gondoltam egy számra! Találd ki!");

        while (!talalt)
        {
            int tipp = beker(szint);
            probalkozasok++;
            talalt = ellenoriz(gondoltSzam, tipp);
        }

        Console.WriteLine($"Gratulálok! {probalkozasok} próbálkozásból találtad el!");
        ujra = kilep();
    } while (ujra == 'i');
}

static int SzintValasztas()
{
    int szint;
    do
    {
        Console.WriteLine("Válassz szintet:");
        Console.WriteLine("1 - Könnyű (0-9)");
        Console.WriteLine("2 - Közepes (0-99)");
        Console.WriteLine("3 - Nehéz (0-999)");
        Console.Write("Szint: ");
        szint = Convert.ToInt32(Console.ReadLine());
    } while (szint < 1 || szint > 3);
    return szint;
}

static int veletlen(int szint)
{
    Random r = new Random();
    if (szint == 1) return r.Next(0, 10);
    if (szint == 2) return r.Next(0, 100);
    return r.Next(0, 1000);
}

static int beker(int szint)
{
    int max = szint == 1 ? 10 : (szint == 2 ? 100 : 1000);
    int tipp;
    do
    {
        Console.Write($"Tipped (0-{max - 1}): ");
        tipp = Convert.ToInt32(Console.ReadLine());
    } while (tipp < 0 || tipp >= max);
    return tipp;
}

static bool ellenoriz(int gondolt, int tipp)
{
    if (gondolt == tipp)
    {
        return true;
    }
    if (tipp > gondolt)
    {
        Console.WriteLine("Kisebb számra gondoltam!");
    }
    else
    {
        Console.WriteLine("Nagyobb számra gondoltam!");
    }
    return false;
}

static char kilep()
{
    char valasz;
    do
    {
        Console.Write("Szeretnél még egyet játszani? (i/n): ");
        valasz = Console.ReadLine()[0];
    } while (valasz != 'i' && valasz != 'n');
    return valasz;
}
