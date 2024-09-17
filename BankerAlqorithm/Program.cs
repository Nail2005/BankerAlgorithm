using System;
using System.Drawing;
namespace BankerAlqorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========BANKER ALGORITHM BY NAIL========");
            Console.Write("Start--->1\nExit--->2\nChoose: ");
            int secim = int.Parse(Console.ReadLine());
            if (secim == 2)
            {
                Console.WriteLine("Exit...(Click Enter)");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (secim == 1)
            {
                Console.Clear();
                Console.WriteLine("========BANKER ALGORITHM BY NAIL========\n");
                Console.Write("Instanslari daxil edin\nA: ");
                int A_ins = int.Parse(Console.ReadLine());
                int a = A_ins;
                Console.Write("B: ");
                int B_ins = int.Parse(Console.ReadLine());
                int b = B_ins;
                Console.Write("C: ");
                int C_ins = int.Parse(Console.ReadLine());
                int c = C_ins;
                Console.WriteLine("\n*********************************\n");
                Console.Write("Proseslerin sayini yazin: ");
                int say = int.Parse(Console.ReadLine());
                Console.WriteLine("\n*********************************\n");
                Console.WriteLine("Allocation yazin: ");
                int[,] Allocation = new int[say, 3];
                int n = 0;
                for (int i = 0; i < say; i++)
                {
                    Console.WriteLine("P" + n + ": ");
                    n++;
                    for (int j = 0; j < 3; j++)
                    {
                        Allocation[i, j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine();
                Console.WriteLine("ALLOCATION: ");
                n = 0;
                for (int i = 0; i < say; i++)
                {
                    Console.Write("P" + n + " ");
                    n++;
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(Allocation[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n*********************************");
                Console.WriteLine();
                Console.WriteLine("Max yazin: ");
                int[,] Max = new int[say, 3];
                n = 0;
                for (int i = 0; i < say; i++)
                {
                    Console.WriteLine("P" + n + ": ");
                    n++;
                    for (int j = 0; j < 3; j++)
                    {
                        Max[i, j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine();
                Console.WriteLine("MAX: ");
                n = 0;
                for (int i = 0; i < say; i++)
                {
                    Console.Write("P" + n + " ");
                    n++;
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(Max[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n*********************************");
                Console.WriteLine();
                Console.WriteLine("NEED(Max-Allocation): ");
                int[,] Need = new int[say, 3];
                n = 0;
                int d = 0;
                for (int i = 0; i < say; i++)
                {
                    Console.Write("P" + n + " ");
                    n++;
                    for (int j = 0; j < 3; j++)
                    {
                        Need[i, j] = Max[i, j] - Allocation[i, j];
                        Console.Write(Need[i, j] + " ");
                        if (Need[i, j] < 0) d++;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n*********************************");
                Console.Write("Neticeni gormek ucun---> Click Enter"); Console.Read(); Console.Clear();
                Console.WriteLine("========BANKER ALGORITHM BY NAIL========\n");
                if (d == 0)
                {
                    int[,] Available = new int[say + 1, 3];
                    for (int i = 0; i < say; i++)
                    {
                        Available[0, 0] = A_ins - Allocation[i, 0];
                        A_ins = Available[0, 0];
                        Available[0, 1] = B_ins - Allocation[i, 1];
                        B_ins = Available[0, 1];
                        Available[0, 2] = C_ins - Allocation[i, 2];
                        C_ins = Available[0, 2];
                    }
                    int k = 0,s=0;
                    string ardicil = " ";
                    while (s<8) //Available[say, 0] == 0
                    {
                        for (int i = 0; i < say; i++)
                        {
                            if (Need[i, 0] >= 0 && Need[i, 1] >= 0 && Need[i, 2] >= 0)
                            {
                                if (Available[k, 0] >= Need[i, 0] && Available[k, 1] >= Need[i, 1] && Available[k, 2] >= Need[i, 2])
                                {
                                    Available[k + 1, 0] = Available[k, 0] + Allocation[i, 0];
                                    Available[k + 1, 1] = Available[k, 1] + Allocation[i, 1];
                                    Available[k + 1, 2] = Available[k, 2] + Allocation[i, 2];
                                    Need[i, 0] *= (-1); Need[i, 1] *= (-1); Need[i, 2] *= (-1);
                                    k++;
                                    ardicil += "P" + i + "    ";
                                }
                            }
                        }
                        s++;
                        if (k == 0) break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Available: ");
                    for (int i = 0; i < say + 1; i++)
                    { 
                        Console.WriteLine(Available[i, 0] + " " + Available[i, 1] + " " + Available[i, 2]); 
                    }
                    Console.WriteLine();
                    if (a == Available[say, 0] && b == Available[say, 1] && c == Available[say, 2])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("*********************************\nARDICILLIQ : " + ardicil + "\nDEADLOCK BAS VERMEDI!!!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*********************************\nERROR!!!\nDEADLOCK BAS VERDI!!");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Need Menfi ola bilmez\nYeniden yoxlayin");
                }
                Console.Read();
            }
            else Console.Write("Secim sehvdir!!!"); Console.ReadLine();
        }
    }
}
