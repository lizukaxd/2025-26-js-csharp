Console.WriteLine("Minden 5. autó:");
if (!File.Exists("/home/liza/code/Feladat/gepjarmu.txt"))
{
    Console.WriteLine("A '/home/liza/code/Feladat/gepjarmu.txt' fájl nem található.");
    return;
}
string[] sorok = File.ReadAllLines("/home/liza/code/Feladat/gepjarmu.txt");
for (int i = 4; i < sorok.Length; i += 5)
{
    string[] adat = sorok[i].Split(';'); 
    if (adat.Length >= 2)
        Console.WriteLine("Modell: " + adat[0] + ", Teljesítmény: " + adat[1]);
}
Console.WriteLine();
Console.WriteLine("Minden 5. tanuló:");
if (!File.Exists("/home/liza/code/Feladat/tanulok.txt"))
{
    Console.WriteLine("A '/home/liza/code/Feladat/tanulok.txt' fájl nem található.");
    return;
}
sorok = File.ReadAllLines("/home/liza/code/Feladat/tanulok.txt");
for (int i = 4; i < sorok.Length; i += 5)
{      
    string[] adat = sorok[i].Split(';');
    if (adat.Length >= 3)
        Console.WriteLine("Név: " + adat[0] + ", Születési év: " + adat[2]);
}
Console.WriteLine();
