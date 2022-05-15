using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class CLass1
{
    public dynamic names;
    public dynamic numCustomers;
    public dynamic pedidos;
    public dynamic productos;
    public dynamic camiones;
    public dynamic camionesCapacidad;
    public dynamic totalCamiones;
    public dynamic unidadesCamiones;

    public CLass1()
    {
        StreamReader r = new StreamReader("../../../data_base.json");
        string json = r.ReadToEnd();

        //string o1 = File.ReadAllText("../../../data_base.json");


        dynamic hola = JsonConvert.DeserializeObject(json);
        //Console.Write(hola);
        //Console.Write(hola.names);
        names = hola.names;
        numCustomers = hola.numCustomers;
        pedidos = hola.pedidos;
        productos = hola.productos;
        camiones = hola.camiones;
        camionesCapacidad = hola.camionesCapacidad;
        totalCamiones = hola.totalCamiones;
        unidadesCamiones = hola.unidadesCamiones;



        /*
        public static string[] names = stuff.names;
        public static int[,] pedidos = stuff.pedidos;
        public static String[] productos = stuff.productos;
        public static String[] camiones = stuff.camiones;
        public static int[] camionesCapacidad = stuff.camionesCapacidad;
        public static int totalCamiones = stuff.totalCamiones;
        public static int[] unidadesCamiones = stuff.unidadesCamiones;
        public static int numCustomers = 2;
        */
    }
    public void writeChanges()
    {

    }



}
