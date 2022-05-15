// See https://aka.ms/new-console-template for more information
using System.Web;
using System;



class Program
{
    public static int numCustomers = 2;



    public static String[] names = { "tienda1", "tienda2","tienda3","tienda4" };

    public static int[,] pedidos = { { 1, 2 ,1}, { 3, 4 ,2},{ 25, 5,2 },{ 30, 0 ,1} };

    public static String[] productos = { "refresco", "pan","verdura" };

    public static String[] camiones = { "refresco", "pan", "verdura" };

    public static int[] camionesCapacidad = { 120,270,95};

    public static int totalCamiones = 5;
    public static int[] unidadesCamiones = { 3, 3, 3 };




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
                pedidos[idxs[i],j] = ans;

            }
            Console.Clear();
        }

    }




    static void IniciarSimulacion()
    {
        Console.Write("Iniciando la simulacion de productos");
        // este elemento es para guardar la maxima cantidad de camiones que pueden salir a repartir
        int tempCamiones = totalCamiones;
        // este arreglo es para llevar la cantidad que camiones que van a salir de cada tipo
        int[] camionesCantidad = new int[camiones.Length];

        // este arreglo es para incluir la cantidad de elementos 
        // en todos los camiones que van a salir a repartir
        int[] elementosARepartir = new int[camiones.Length];

        for(int i=0;i<camiones.Length;i++)
        {
            Console.Write("\nLos Camiones del tipo " + camiones[i] + "\ntienen capacidad para almacenar" + camionesCapacidad[i] + "elementos\n");
            Console.Write("\ncuantos camiones del tipo: " + camiones[i] + " max( " + totalCamiones + ")?\n");
            camionesCantidad[i] = int.Parse(Console.ReadLine());
            totalCamiones -= camionesCantidad[i];

            elementosARepartir[i] = camionesCantidad[i] * camionesCapacidad[i];
        }


        int[] idxs = sortIndeces(pedidos);
        for (int i = 0; i < names.Length; i++)
        {
            //repartir productos
            Console.Write("\n repartiendo en la tienda " + names[idxs[i]] + "\n");
            for (int j = 0; j < productos.Length; j++)
            {
                elementosARepartir[j] -= pedidos[idxs[i], j];
                // esta es la traba para seguir obteniendo los camiones
                while(elementosARepartir[j] < 0)
                {
                    Console.Write("\nNo se pudo satisfacer la demanda\n");
                    Console.Write("\nAgrega otro camion de " + productos[j] + "(yes/no)\n");
                    string answer = Console.ReadLine();
                    if(answer == "yes")
                    {
                        elementosARepartir[j] += camionesCapacidad[j];
                    }
                }
                Console.Write("\nProducto " + productos[j] + " -- " + pedidos[idxs[i], j] + "\n");
            }
            Console.Write(" \n==== Reparticion Finalizada === \n\n");
            // levantar pedidos
            Console.Write("\n lavantando pedidos en la tienda" + names[idxs[i]]);
            for (int j = 0; j < productos.Length; j++)
            {
                Console.Write("\n cuantos productos de " + productos[j] + " quiere?\n");
            }
            Console.Clear();
        }
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
        CLass1 data_base =  new CLass1();

        Console.Write("imported the class");
        Console.Write("names: " + data_base.names);


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
