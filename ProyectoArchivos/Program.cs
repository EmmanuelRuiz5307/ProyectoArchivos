using System;
using System.IO;
namespace ProyectoArchivos
{
    class Program
    {
        static StreamReader lectura;
        static StreamWriter escritura, temporal;
        static string cadena, respuesta, noSerie, modelo, fabricante, color;
        static short anio;
        static double precio;
        static bool encontrado;
        static string[] campos = new string[6];


        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey(true);
        }

        //Creando Metodo Menu
        static void Menu()
        {
            byte opcion;
            opcion = 0;
            try
            {
                do
                {
                    Console.WriteLine("Menu de Opciones");
                    Console.WriteLine("1. Altas");
                    Console.WriteLine("2. Bajas");
                    Console.WriteLine("3. Consultas");
                    Console.WriteLine("4. Modificaciones");
                    Console.WriteLine("5. Ver Todos los registros");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine("¿Qué deseas hacer?");
                    opcion = Convert.ToByte(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            Console.WriteLine("*******************************************");
                            Console.WriteLine("***********Aplicacion Finalizada***********");
                            Console.WriteLine("*******************************************");
                            break;
                        default:
                            Console.WriteLine("*******************************************");
                            Console.WriteLine("***********Opcion Incorrecta***********");
                            Console.WriteLine("*******************************************");
                            break;
                    }
                } while (opcion != 6);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("Error! " + fe.Message);
                Console.WriteLine("*******************************************");
               // Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("Error! " + ex.Message);
                Console.WriteLine("*******************************************");
            }


        }
    }//Fin de la clase program
}
