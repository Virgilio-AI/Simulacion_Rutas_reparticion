// See https://aka.ms/new-console-template for more information
using System.Web;
using System;



class Program
{
    public static int numCustomers = 2;



    public static String[] names = { "tienda1", "tienda2","tienda3","tienda4" };

    public static int[,] pedidos = { { 1, 2 }, { 3, 4 },{ 25, 5 },{ 30, 0 } };

    public static String[] productos = { "refresco", "pan" };



    static int[] sortIndeces(int[,] pedidos)
    {

        List<int> list = new List<int>();

        for(int i =0;i<names.Length;i++)
        {
            int sumi = 0;
            for(int j=0;j<productos.Length;j++)
            {
                sumi += pedidos[i, j];
            }
            list.Add(sumi);
        }



        int N = list.Count;
        int[] index = Enumerable.Range(0, N).ToArray<int>();
        Array.Sort<int>(index, (a, b) => list[a].CompareTo(list[b]));
        int[] ansi = index.ToArray();
        int[] ans = new int[ansi.Length];
        for(int i=ansi.Length-1;i>=0;i--)
        {
            ans[ansi.Length - 1 - i] = ansi[i];
        }

        return ans;


    }
    static void IniciarReparticion()
    {
        Console.Write("Iniciando reparticion de productos");
        int[] idxs = sortIndeces(pedidos);
        for (int i = 0; i < names.Length; i++)
        {
            //repartir productos
            Console.Write("\n repartiendo en la tienda " + names[idxs[i]] + "\n");
            for (int j = 0; j < productos.Length; j++)
            {
                Console.Write("\nProducto " + productos[j] + " -- "+ pedidos[idxs[i],j]  + "\n");
            }
            Console.Write(" \n==== Reparticion Finalizada === \n\n");
            // levantar pedidos
            Console.Write("\n lavantando pedidos en la tienda" + names[idxs[i]]);
            for (int j = 0; j < productos.Length; j++)
            {
                Console.Write("\n cuantos productos de " + productos[j] +  " quiere?\n");
                int ans = int.Parse(Console.ReadLine());
                Console.Write("i: " + i + "j: " + j);
                pedidos[idxs[i],j] = ans;

            }
            Console.Clear();
        }

    }




    static void IniciarSimulacion()
    {
        Console.Write("Iniciando la simulacion");
    }
    static void FirstMenu()
    {
        Console.Write("==== Ingresa la accion que deseas ========\n\n");
        Console.Write("1) iniciar simulacion de reparticion\n");
        Console.Write("2) Iniciar reparticion de productos\n");
    }
    static void Main()
    {
        string option = "";
        int daysCount = 0;
        while (option == "" || option == "continue")
        {
            daysCount++;
            Console.Write("\nday:" + daysCount + "\n");
            FirstMenu();
            int x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                Console.Clear();
                IniciarSimulacion();
            }
            else
            {
                Console.Clear();
                IniciarReparticion();
            }
        }
    }
}
