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
	public static string bitacora_path = "../../../bitacora.txt";
	public static string json_path = "../../../data_base.json";

	public dynamic names;
	public dynamic numCustomers;
	public dynamic pedidos;
	public dynamic productos;
	public dynamic camiones;
	public dynamic camionesCapacidad;
	public dynamic totalCamiones;
	public dynamic unidadesCamiones;
	// for loading the database
	public dynamic data_base;

	public CLass1()
	{
		StreamReader r = new StreamReader(json_path);
		string json = r.ReadToEnd();

		//string o1 = File.ReadAllText("../../../data_base.json");


		dynamic data_base = JsonConvert.DeserializeObject(json);
		//Console.Write(hola);
		//Console.Write(hola.names);
		names = data_base.names;
		numCustomers = data_base.numCustomers;
		pedidos = data_base.pedidos;
		productos = data_base.productos;
		camiones = data_base.camiones;
		camionesCapacidad = data_base.camionesCapacidad;
		totalCamiones = data_base.totalCamiones;
		unidadesCamiones = data_base.unidadesCamiones;



		/*
			+        public static string[] names = stuff.names;
			+        public static int[,] pedidos = stuff.pedidos;
			+        public static String[] productos = stuff.productos;
			+        public static String[] camiones = stuff.camiones;
			+        public static int[] camionesCapacidad = stuff.camionesCapacidad;
			+        public static int totalCamiones = stuff.totalCamiones;
			+        public static int[] unidadesCamiones = stuff.unidadesCamiones;
			+        public static int numCustomers = 2;
			+        */
	}
	public void writeChanges()
	{
		string output = Newtonsoft.Json.JsonConvert.SerializeObject(data_base, Newtonsoft.Json.Formatting.Indented);
		File.WriteAllText(json_path, output);
	}

	public void EscribirEnBitacora(string toWrite)
	{
		using (StreamWriter sw = File.AppendText(bitacora_path))
		{
			sw.WriteLine(toWrite);
		}
	}


	public void leerBitacora()
	{
		String line;
		try
		{
			//Pass the file path and file name to the StreamReader constructor
			StreamReader sr = new StreamReader(bitacora_path);
			//Read the first line of text
			line = sr.ReadLine();
			//Continue to read until you reach end of file
			while (line != null)
			{
				//write the line to console window
				Console.WriteLine(line);
				//Read the next line
				line = sr.ReadLine();
			}
			//close the file
			sr.Close();
			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine("Exception: " + e.Message);
		}
		finally
		{
			Console.WriteLine("Executing finally block.");
		}
	}

}
