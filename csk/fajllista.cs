List<int> lista = new List<int> { 3, 7, 11, 15, 22 };

Console.WriteLine("Kezdeti lista (sorban):");
foreach (int szam in lista)
{
    Console.WriteLine(szam);
}

List<int> fajlszamok = new List<int>();
if (File.Exists("szamok.txt"))
{
    string[] sorok = File.ReadAllLines("szamok.txt");
    foreach (string sor in sorok)
    {
        if (int.TryParse(sor, out int szam))
        {
            fajlszamok.Add(szam);
        }
    }
}

lista.AddRange(fajlszamok);

Console.WriteLine("\nLista az összes számmal (egymás mellett):");
Console.WriteLine(string.Join(" ", lista));

if (lista.Count > 0) lista.RemoveAt(0);
Console.WriteLine("\nAz első elem törlése után:");
Console.WriteLine(string.Join(" ", lista));

if (lista.Count > 0) lista.RemoveAt(lista.Count - 1);
Console.WriteLine("\nAz utolsó elem törlése után:");
Console.WriteLine(string.Join(" ", lista));

int kozepeIndex = lista.Count / 2;
if (lista.Count > 0 && kozepeIndex < lista.Count)
{
    lista.RemoveAt(kozepeIndex);
    Console.WriteLine("\nA középső elem törlése után:");
    Console.WriteLine(string.Join(" ", lista));
}

lista = lista.Where(x => x % 2 != 0).ToList();
Console.WriteLine("\nPáros számok törlése után (csak páratlanok maradtak):");
Console.WriteLine(string.Join(" ", lista));

List<int> megduplazott = new List<int>();
foreach (int szam in lista)
{
    megduplazott.Add(szam * 2);
}
Console.WriteLine("\nMegduplázott lista:");
Console.WriteLine(string.Join(" ", megduplazott));

Random rnd = new Random();
List<int> lottoSzamok = new List<int>();
while (lottoSzamok.Count < 6)
{
    int szam = rnd.Next(1, 46);
    if (!lottoSzamok.Contains(szam))
    {
        lottoSzamok.Add(szam);
    }
}
lottoSzamok.Sort();

List<int> nyeroSzamok = new List<int> { 7, 9, 11, 21, 28, 34 };

int találat = 0;
foreach (int szam in lottoSzamok)
{
    if (nyeroSzamok.Contains(szam))
    {
        találat++;
    }
}

Console.WriteLine($"\nLottó számok: {string.Join(" ", lottoSzamok)}");
Console.WriteLine($"Nyerőszámok: {string.Join(" ", nyeroSzamok)}");
Console.WriteLine($"Találatok száma: {találat}");
