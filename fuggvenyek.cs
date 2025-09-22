//1

Console.Write("Medence átmérője: ");
double atmero = Convert.ToDouble(Console.ReadLine());
Console.Write("Medence mélysége: ");
double melyseg = Convert.ToDouble(Console.ReadLine());
double sugar = atmero / 2;
double terfogat = Math.PI * sugar * sugar * melyseg;
double eredmeny = Math.Round(terfogat, 1);
Console.WriteLine("Ennyi köbméter víz fér bele: "+ eredmeny);

//2

Console.Write("Kölcsön összege: ");
double osszeg = Convert.ToDouble(Console.ReadLine());
Console.Write("Az éves kamat: ");
double kamat = Convert.ToDouble(Console.ReadLine());
Console.Write("Futamidő években: ");
int futamido = Convert.ToInt32(Console.ReadLine());

double kamat1 = kamat / 12 / 100;
int futamido1 = futamido * 12;

double reszlet = osszeg * (kamat1 * Math.Pow(1 + kamat1, futamido1)) / (Math.Pow(1 + kamat1, futamido1) - 1);
double havitorleszto = Math.Round(reszlet, 2);
Console.WriteLine($"Havi törlesztőrészlet: {havitorleszto} Ft");

//3

Console.WriteLine("Első időpont:");
Console.Write("Óra: ");
int ora1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Perc: ");
int perc1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Másodperc: ");
int mp1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\nMásodik időpont:");
Console.Write("Óra: ");
int ora2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Perc: ");
int perc2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Másodperc: ");
int mp2 = Convert.ToInt32(Console.ReadLine());

int masodperc1 = ora1 * 3600 + perc1 * 60 + mp1;
int masodperc2 = ora2 * 3600 + perc2 * 60 + mp2;
int kulonbseg = Math.Abs(masodperc2 - masodperc1);

Console.WriteLine($"A két időpont közötti különbség: {kulonbseg} másodperc.");

//4

Console.Write("Az első szám: ");
int szam = Convert.ToInt32(Console.ReadLine());
Console.Write("Az második szám: ");
int szam2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("A két szám összegének négyzetgyöke: "+ Math.Sqrt(szam + szam2) );

//5

Console.Write("Egy pozitív valós szám: ");
double val1 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($" A megadott szám a {Math.Floor(val1)} és a {Math.Ceiling(val1)} egész számok között van, és ezek közül a {Math.Round(val1)} számhoz van közelebb.\r\n A szám egész része: {Math.Floor(val1)}\r\n A szám törtrésze: {val1- Math.Floor(val1)}");

//6

Console.Write("Első egész szám: ");
int eg1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Második egész szám: ");
int eg2 = Convert.ToInt32(Console.ReadLine());

int ed;

if (eg1 > eg2)
{
    ed = eg1 - eg2;
}
else if (eg2 > eg1)
{
    ed = eg2 - eg1;
}
else
{
    ed = 0;
}

Console.WriteLine($"A két szám különbsége: {ed}");

//7

Console.Write("Az első szám: ");
int sza1 = Convert.ToInt32(Console.ReadLine());
Console.Write("A második szám: ");
int sza2 = Convert.ToInt32(Console.ReadLine());
Console.Write("A harmadik szám: ");
int sza3 = Convert.ToInt32(Console.ReadLine());

int min = Math.Min(sza1, Math.Min(sza2, sza3));
int max = Math.Max(sza1, Math.Max(sza2, sza3));
int kozep = sza1 + sza2 + sza3 - min - max;

Console.WriteLine($"A számok növekvő sorrendben: {min}, {kozep}, {max}");

//8

Console.Write("Első befogó: ");
double a = Convert.ToDouble(Console.ReadLine());

Console.Write("Második befogó: ");
double b = Convert.ToDouble(Console.ReadLine());

double c = Math.Sqrt(a * a + b * b);
double alfa = Math.Atan(a / b) * (180 / Math.PI);
double beta = Math.Atan(b / a) * (180 / Math.PI);

Console.WriteLine($"Átfogó: {c}");
Console.WriteLine($"Alfa: {alfa} fok");
Console.WriteLine($"Béta: {beta} fok");



