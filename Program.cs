//8
using System.Data;

int alma = 10;

Console.WriteLine(alma);
Console.WriteLine("alma");
Console.WriteLine("kétszerese: " + alma*2);
Console.WriteLine("kettővel kevesebb: " + (alma-2));
Console.WriteLine("a fele: " + alma/2);
Console.WriteLine("a négyzete: " + alma*alma);
Console.WriteLine("2, 3, 5-tel osztási maradék: " + alma%2 + " " + alma%3 + " " + alma%5);

//9
int korte = 5;
korte++;
Console.WriteLine(korte);
korte += 5;
Console.WriteLine(korte);
korte--;
Console.WriteLine(korte);
korte -= 3;
Console.WriteLine(korte);
korte *= 4;
Console.WriteLine(korte);
korte /= 2;
Console.WriteLine(korte);
korte %= 3;
Console.WriteLine(korte);

//10

int a;
int b, c, d;
a = 6;
Console.WriteLine(a);
a = 1916;
Console.WriteLine(a);
a += 100;
Console.WriteLine(a);
Console.Write("Add meg a neved: ");
string nev =  Console.ReadLine();

Console.Write("Add meg a születési évedet: ");
int szulev = int.Parse(Console.ReadLine());
int kor = a - szulev;

Console.WriteLine($"Én, {nev} {kor} éves vagyok.");

//11

double l;
l = 5; 
Console.WriteLine(l);  
Console.WriteLine("A szám kétszerese: "+ (l*2));
l += 3;
Console.WriteLine("+3: "+ l);
int k = 3;
Console.WriteLine("k tízszerese: " + (k * 10));
double p = l / k;
Console.WriteLine("l/k hányadosa: " + p);

//12
int barack = 50;
int szilva = 30;
int osszeg = barack + szilva;
Console.WriteLine("barack + szilva= "+ osszeg);

//13

int x = 7;
int y = 1;
int w = 3;

int eredmeny1 = (x - y) / w;
Console.WriteLine("(x - y) / w =  (" + x + " - " + y + ") / " + w + " = "+ eredmeny1);

int eredmeny2 = ((x + y) * (2 * x - w));
Console.WriteLine("(x + y)(2x - w) = (" + x + " + " + y + ")(" + "2*" + x + " - " + w + ") = " + eredmeny2);

int eredmeny3 = (3 * x - 3 * y) / w;
Console.WriteLine("(3x - 3y) / w = (3*" + x + " - 3*" + y + ") / " + w + " = " + eredmeny3);

int eredmeny4 = 2 * x * w + 4 * y;
Console.WriteLine("2xw + 4y = 2*" + x + "*" + w + " + 4*" + y + " = " + eredmeny4);

// 14

int szam1 = 17;
int szam2 = 5;

int hanyadosInt = szam1 / szam2;
int maradekInt = szam1 % szam2;

Console.WriteLine("Egész számok:");
Console.WriteLine(szam1 + " / " + szam2 + " = " + hanyadosInt);
Console.WriteLine(szam1 + " % " + szam2 + " = " + maradekInt);

double valos1 = 17.0;
double valos2 = 5.0;

double hanyadosDouble = valos1 / valos2;

Console.WriteLine("\nValós számok:");
Console.WriteLine(valos1 + " / " + valos2 + " = " + hanyadosDouble);

double maradekDouble = valos1 % valos2;
Console.WriteLine(valos1 + " % " + valos2 + " = " + maradekDouble);

int szam3 = 23;
int szam4 = 4;
Console.WriteLine("\nMás értékek (egész számok):");
Console.WriteLine(szam3 + " / " + szam4 + " = " + (szam3 / szam4));
Console.WriteLine(szam3 + " % " + szam4 + " = " + (szam3 % szam4));

//15

Console.Write("x = ");
double x1 = Convert.ToDouble(Console.ReadLine());

Console.Write("y = ");
double y2 = Convert.ToDouble(Console.ReadLine());

double osszeg2 = x1 + y2;
double kulonbseg = x1 - y2;
double szorzat = x1 * y2;
double hanyados = x1 / y2;

double x1Negyzet = Math.Pow(x1, 2);
double y2Negyzet = Math.Pow(y2, 2);

double x1Kob = Math.Pow(x1, 3);
double y2Kob = Math.Pow(y2, 3);

Console.WriteLine("\n--- Eredmények ---");
Console.WriteLine($"x = {x1}");
Console.WriteLine($"y = {y2}");
Console.WriteLine($"x + y = {osszeg2}");
Console.WriteLine($"x - y = {kulonbseg}");
Console.WriteLine($"x * y = {szorzat}");
Console.WriteLine($"x / y = {hanyados:F2}"); 
Console.WriteLine($"x^2 = {x1Negyzet}");
Console.WriteLine($"y^2 = {y2Negyzet}");
Console.WriteLine($"x^3 = {x1Kob}");
Console.WriteLine($"y^3 = {y2Kob}");

//16

Console.Write("Adjon meg egy valós számot (d): ");
double d1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Adjon meg egy pozitív egész számot (n): ");
int n2 = Convert.ToInt32(Console.ReadLine());

double kerekitett = Math.Round(d1, n2);

Console.WriteLine($"A/az {d1} {n2} tizedes jegyre kerekített értéke: {kerekitett}");


