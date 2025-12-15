
List<int> lista = new List<int>();

lista.Add(5);
lista.Add(10);
lista.Add(15);
lista.Add(20);
lista.Add(25);

Console.WriteLine("Kezdeti lista:");
for (int i = 0; i < lista.Count; i++)
{
    Console.WriteLine(lista[i]);
}

string[] fajlSorok = File.ReadAllLines("szamok.txt");

for (int i = 0; i < fajlSorok.Length; i++)
{
    int szam = int.Parse(fajlSorok[i]);
    lista.Add(szam);
}

Console.WriteLine("\nLista a fajl szamaival:");
for (int i = 0; i < lista.Count; i++)
{
    Console.Write(lista[i]);
    if (i < lista.Count - 1) Console.Write(" ");
}
Console.WriteLine();

lista.RemoveAt(0);

Console.WriteLine("\nElso elem torlesere utan:");
for (int i = 0; i < lista.Count; i++)
{
    Console.Write(lista[i]);
    if (i < lista.Count - 1) Console.Write(" ");
}
Console.WriteLine();

lista.RemoveAt(lista.Count - 1);

Console.WriteLine("\nUtolso elem torlesere utan:");
for (int i = 0; i < lista.Count; i++)
{
    Console.Write(lista[i]);
    if (i < lista.Count - 1) Console.Write(" ");
}
Console.WriteLine();

int kozepIndex = lista.Count / 2;
lista.RemoveAt(kozepIndex);

Console.WriteLine("\nKozepso elem torlesere utan:");
for (int i = 0; i < lista.Count; i++)
{
    Console.Write(lista[i]);
    if (i < lista.Count - 1) Console.Write(" ");
}
Console.WriteLine();

List<int> paratlanok = new List<int>();
for (int i = 0; i < lista.Count; i++)
{
    if (lista[i] % 2 != 0)
    {
        paratlanok.Add(lista[i]);
    }
}
lista = paratlanok;

Console.WriteLine("\nParos szamok torlesere utan:");
for (int i = 0; i < lista.Count; i++)
{
    Console.Write(lista[i]);
    if (i < lista.Count - 1) Console.Write(" ");
}
Console.WriteLine();

List<int> meghozata = new List<int>();
for (int i = 0; i < lista.Count; i++)
{
    meghozata.Add(lista[i] * 2);
}

Console.WriteLine("\nMegduplazott lista:");
for (int i = 0; i < meghozata.Count; i++)
{
    Console.Write(meghozata[i]);
    if (i < meghozata.Count - 1) Console.Write(" ");
}
Console.WriteLine();

Random rand = new Random();
List<int> lottoSzamok = new List<int>();

while (lottoSzamok.Count < 6)
{
    int szam = rand.Next(1, 46);
    
    bool letezik = false;
    for (int i = 0; i < lottoSzamok.Count; i++)
    {
        if (lottoSzamok[i] == szam)
        {
            letezik = true;
        }
    }
    
    if (letezik == false)
    {
        lottoSzamok.Add(szam);
    }
}

int talatatok = 0;
int[] nyeroSzamok = new int[] { 7, 9, 11, 21, 28, 34 };

for (int i = 0; i < lottoSzamok.Count; i++)
{
    for (int j = 0; j < nyeroSzamok.Length; j++)
    {
        if (lottoSzamok[i] == nyeroSzamok[j])
        {
            talatatok = talatatok + 1;
        }
    }
}

Console.WriteLine("\nLottos szamok:");
for (int i = 0; i < lottoSzamok.Count; i++)
{
    Console.Write(lottoSzamok[i]);
    if (i < lottoSzamok.Count - 1) Console.Write(" ");
}
Console.WriteLine();

Console.WriteLine("\nNyeroek:");
for (int i = 0; i < nyeroSzamok.Length; i++)
{
    Console.Write(nyeroSzamok[i]);
    if (i < nyeroSzamok.Length - 1) Console.Write(" ");
}
Console.WriteLine();

Console.WriteLine("\nTalatatok:" + talatatok);

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
