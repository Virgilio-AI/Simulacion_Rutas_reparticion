// See https://aka.ms/new-console-template for more information
using System.Web;
using System;



class Program
{
    public static int numCustomers = 2;



    public static dynamic names;

    public static dynamic pedidos;

    public static dynamic productos ;

    public static dynamic camiones ;

    public static dynamic camionesCapacidad;

    public static int totalCamiones;
    public static dynamic unidadesCamiones;

    public static dynamic wholeDatabase;

    public static bool databaseLoaded=false;




    static int[] sortIndeces(dynamic pedidos)
    {

        List<int> list = new List<int>();

        for(int i =0;i<names.Count;i++)
        {
            int sumi = 0;
            for(int j=0;j<productos.Count;j++)
            {
                sumi += (int)pedidos[i][j];
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
        Console.Write("====== Iniciando reparticion de productos ====== ");
        Console.Write("===== los camiones salieron a las rutas ======== ");
        Console.Write("------ se atenderan primero a los que generen mas dinero ---- ");


        int[] idxs = sortIndeces(pedidos);
        for (int i = 0; i < names.Count; i++)
        {
            //repartir productos
            Console.Write("\n repartiendo en la tienda " + names[idxs[i]] + "\n");
            for (int j = 0; j < productos.Count; j++)
            {
                Console.Write("\nProducto " + productos[j] + " -- "+ pedidos[idxs[i]][j]  + "\n");
            }
            Console.Write(" \n==== Reparticion Finalizada === \n\n");
            // levantar pedidos
            string toPrint = "\n lavantando pedidos en la tienda" + names[idxs[i]]+ " ===== " + getCurrentDateTime();

            Console.Write(toPrint);
            for (int j = 0; j < productos.Count; j++)
            {
                Console.Write("\n cuantos productos de " + productos[j] +  " quiere?\n");
                int ans = int.Parse(Console.ReadLine());
                pedidos[idxs[i]][j] = ans;

            }

            Console.Clear();
        }

    }

    static string getCurrentDateTime()
    {
        DateTime now = DateTime.Now;
        return now.ToString("F");
    }


    static void IniciarSimulacion()
    {
        string toPrint = "Iniciando la simulacion de productos";

        Console.Write(toPrint);
        wholeDatabase.EscribirEnBitacora(toPrint + "====="  + getCurrentDateTime());
        // este elemento es para guardar la maxima cantidad de camiones que pueden salir a repartir
        int tempCamiones = totalCamiones;
        // este arreglo es para llevar la cantidad que camiones que van a salir de cada tipo
        int[] camionesCantidad = new int[camiones.Count];

        // este arreglo es para incluir la cantidad de elementos 
        // en todos los camiones que van a salir a repartir
        int[] elementosARepartir = new int[camiones.Count];

        for(int i=0;i<camiones.Count;i++)
        {
            Console.Write("\nLos Camiones del tipo " + camiones[i] + "\ntienen capacidad para almacenar " + camionesCapacidad[i] + " elementos\n");
            Console.Write("\ncuantos camiones del tipo: " + camiones[i] + " max( " + totalCamiones + ")?\n");
            camionesCantidad[i] = int.Parse(Console.ReadLine());
            tempCamiones -= camionesCantidad[i];

            elementosARepartir[i] = camionesCantidad[i] * (int)camionesCapacidad[i];
        }


        int[] idxs = sortIndeces(pedidos);
        for (int i = 0; i < names.Count; i++)
        {
            //repartir productos
            Console.Write("\n repartiendo en la tienda " + names[idxs[i]] + "\n");
            for (int j = 0; j < productos.Count; j++)
            {
                elementosARepartir[j] -= (int)pedidos[idxs[i]][j];
                // esta es la traba para seguir obteniendo los camiones
                while(elementosARepartir[j] < 0)
                {
                    Console.Write("\nNo se pudo satisfacer la demanda\n");
                    Console.Write("\nAgrega otro camion de " + productos[j] + "(yes/no)\n");
                    string answer = Console.ReadLine();
                    if(answer == "yes")
                    {
                        elementosARepartir[j] += (int)camionesCapacidad[j];

                        toPrint = "se agrego un camion repartidor de " + productos[j] + getCurrentDateTime();

                        Console.Write(toPrint);
                        wholeDatabase.EscribirEnBitacora(toPrint);


                    }
                }
                Console.Write("\nProducto " + productos[j] + " -- " + pedidos[idxs[i]][j] + "\n");
            }
            Console.Write(" \n==== Simulacion de Reparticion Finalizada === \n\n");

            toPrint = "\n==== Simulacion de Reparticion Finalizada === " + getCurrentDateTime()  ;

            Console.Write(toPrint);
            wholeDatabase.EscribirEnBitacora(toPrint);



            Console.Write("simulacion exitosa");
            string tempAns = Console.ReadLine();

            Console.Clear();
        }
    }
    static void FirstMenu()
    {
        Console.Write("==== Ingresa la accion que deseas ========\n\n");
        Console.Write("1) mostrar bitacora\n");
        Console.Write("2) Iniciar reparticion de productos\n");
        Console.Write("3) salir\n");
    }
    static void InitVariables(CLass1 data_base)
    {
        //names = (String[])data_base.names;
        
        numCustomers = data_base.numCustomers;
        pedidos = data_base.pedidos;
        productos = data_base.productos;
        camiones = data_base.camiones;
        camionesCapacidad = data_base.camionesCapacidad;
        totalCamiones = data_base.totalCamiones;
        unidadesCamiones = data_base.unidadesCamiones;
        names = data_base.names;
        
        
    }
    static void LoadDatabase()
    {
        if(databaseLoaded == false)
        {
            wholeDatabase = new CLass1();
            InitVariables(wholeDatabase);
            Console.Write("\n ==== imported the class succesfully ==== \n");
            Console.Write("\n ======================================== \n");
            databaseLoaded = true;
        }
    }
    static void mostrarBitacora()
    {
        wholeDatabase.leerBitacora();
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
                LoadDatabase();
                mostrarBitacora();
                Console.Clear();
            }
            else if(x == 3)
            {
                option = "exit";
            }
            else
            {
                LoadDatabase();
                IniciarSimulacion();
                Console.Clear();
                IniciarReparticion();
            }
        }
    }
}
