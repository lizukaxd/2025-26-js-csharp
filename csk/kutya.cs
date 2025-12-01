int m = 8;
int maxpont = 10;
int also = 4;
int minpont = 3;

Console.Write("Add meg a kutyák számát (n): ");
if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
{
    Console.WriteLine("Érvénytelen n.");
    return;
}
var veletlen = new Random();
int[,] pontok = new int[n, m];
for (int i = 0; i < n; i++)
    for (int j = 0; j < m; j++)
        pontok[i, j] = veletlen.Next(minpont, maxpont + 1);
Console.WriteLine("\nPontmátrix:");
for (int i = 0; i < n; i++)
{
    Console.Write($"Kutya {i + 1,2}: ");
    for (int j = 0; j < m; j++)
        Console.Write($"{pontok[i, j],2} ");
    Console.WriteLine();
}
int[] osszpont = new int[n];
for (int i = 0; i < n; i++)
{
    int osszeg = 0;
    for (int j = 0; j < m; j++) osszeg += pontok[i, j];
    osszpont[i] = osszeg;
}
Console.WriteLine("\nKutyák összpontjai:");
for (int i = 0; i < n; i++)
    Console.WriteLine($"Kutya {i + 1}: {osszpont[i]} pont");
List<int> kiesettkutyak = new List<int>();
for (int i = 0; i < n; i++)
{
    bool kiesik = false;
    for (int j = 0; j < m; j++)
        if (pontok[i, j] < also) { kiesik = true; break; }
    if (kiesik) kiesettkutyak.Add(i + 1);
}
Console.WriteLine("\nAutomatikusan kieső kutyák:");
Console.WriteLine(kiesettkutyak.Count > 0 ? string.Join(", ", kiesettkutyak) : "Nincs ilyen.");
int[] maxkategoriak = new int[m];
List<int>[] gyoztesekkategoria = new List<int>[m];
for (int j = 0; j < m; j++)
{
    int max = int.MinValue;
    for (int i = 0; i < n; i++) if (pontok[i, j] > max) max = pontok[i, j];
    maxkategoriak[j] = max;
    var gyoztesek = new List<int>();
    for (int i = 0; i < n; i++) if (pontok[i, j] == max) gyoztesek.Add(i + 1);
    gyoztesekkategoria[j] = gyoztesek;
}
List<int> mindengyoztes = new List<int>();
for (int i = 0; i < n; i++)
{
    bool mindenben = true;
    for (int j = 0; j < m; j++)
        if (pontok[i, j] != maxkategoriak[j]) { mindenben = false; break; }
    if (mindenben) mindengyoztes.Add(i + 1);
}
Console.WriteLine("\nKutyák, akik minden kategóriában győztesek:");
Console.WriteLine(mindengyoztes.Count > 0 ? string.Join(", ", mindengyoztes) : "Nincs ilyen.");
List<int> holtversenykategoriak = new List<int>();
for (int j = 0; j < m; j++)
    if (gyoztesekkategoria[j].Count > 1) holtversenykategoriak.Add(j + 1);
Console.WriteLine("\nKategóriák, ahol holtverseny volt:");
Console.WriteLine(holtversenykategoriak.Count > 0 ? string.Join(", ", holtversenykategoriak) : "Nincs ilyen.");
List<int> mindenkiesett = new List<int>();
for (int i = 0; i < n; i++)
{
    bool mindenki = true;
    for (int j = 0; j < m; j++)
        if (pontok[i, j] >= also) { mindenki = false; break; }
    if (mindenki) mindenkiesett.Add(i + 1);
}
Console.WriteLine("\nKutyák, akik minden kategóriában kiestek:");
Console.WriteLine(mindenkiesett.Count > 0 ? string.Join(", ", mindenkiesett) : "Nincs ilyen.");
Dictionary<int, int> gyozelmek = new Dictionary<int, int>();
for (int i = 0; i < n; i++) gyozelmek[i + 1] = 0;
for (int j = 0; j < m; j++)
    foreach (var d in gyoztesekkategoria[j]) gyozelmek[d]++;
var tobbszorosgyoztesek = gyozelmek.Where(kv => kv.Value >= 2).Select(kv => kv.Key).ToList();
Console.WriteLine("\nKutyák, akik több kategóriában is győztesek:");
Console.WriteLine(tobbszorosgyoztesek.Count > 0 ? string.Join(", ", tobbszorosgyoztesek) : "Nincs ilyen.");
List<int> kategoriakiesesnelkul = new List<int>();
for (int j = 0; j < m; j++)
{
    bool voltkieses = false;
    for (int i = 0; i < n; i++)
        if (pontok[i, j] < also) { voltkieses = true; break; }
    if (!voltkieses) kategoriakiesesnelkul.Add(j + 1);
}
Console.WriteLine("\nKategóriák, ahol nem volt kieső:");
Console.WriteLine(kategoriakiesesnelkul.Count > 0 ? string.Join(", ", kategoriakiesesnelkul) : "Nincs ilyen.");
