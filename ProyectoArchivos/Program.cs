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
                            crearArchivo();
                            altas();
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
                //Capturamos la excepcion el cual despliega cuando el usuario haya insertado algo que no sea un caracter.
                //Por ejemplo un numero....
                Console.WriteLine("*******************************************");
                Console.WriteLine("Error! " + fe.Message);
                Console.WriteLine("*******************************************");
               // Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                //Capturamos cualquier excepcion que se nos presente al momento de agregar elementos.
                Console.WriteLine("*******************************************");
                Console.WriteLine("Error! " + ex.Message);
                Console.WriteLine("*******************************************");
            }


        }//Fin del metodo Menu 

        //Creando Metodo crearArchivo
        static void crearArchivo()
        {
            /*Estructura de un archivo...
             * Crear 
             * Escribir 
             * Cerrar
             */
            //Asignando nombre para el archivo , solamente es para agregar texto en el archivo
            escritura = File.AppendText("autos.txt");
            escritura.Close();
        }//Fin del metodo crearArchivo


        //creando metodo altas
        static void altas()
        {
            encontrado = false;
            try
            {
                //Preparando nuestro archivo para lectura
                lectura = File.OpenText("autos.txt");
                Console.Write("Ingresa el numero de serie del Auto: ");
                noSerie = Console.ReadLine();
                noSerie = noSerie.ToUpper();
                //Para recorrer nuestro archivo primero tenemos que hacer una lectura adelantada.
                cadena = lectura.ReadLine();

                //Usamos while para verificar si hay contenido en el archivo...
                //Buscamos para ver si no existe un auto , con este numero de serie.
                while (cadena != null)
                {
                    campos = cadena.Split(",");
                    //La condicion sigueinte es que , si la posicio 0 es igual a la cadena noSerie se encontro repetido.
                    if (campos[0].Trim().Equals(noSerie))
                    {
                        //Si encunetra uno igualito al que estamos ingresando , hay un elemento repetido...
                        encontrado = true;
                        break;
                    }
                    else
                    {
                        cadena = lectura.ReadLine();
                    }
                }
                //Si no agregamos el Close , no podemos usar el txt ya que se estaria ejecutando , se debe a que no se cerro 
                //en la ejecucion pasada.
                lectura.Close();
                //Preparamos para escribir en este archivo.
                escritura = File.AppendText("autos.txt");

                if (encontrado == false)
                {
                    Console.Write("Ingresa el modelo del auto: ");
                    modelo = Console.ReadLine();
                    modelo = modelo.ToUpper();
                    Console.Write("Ingresa el anio del auto: ");
                    anio = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Ingresa el fabricante del auto: ");
                    fabricante = Console.ReadLine();
                    fabricante = fabricante.ToUpper();
                    Console.Write("Ingresa el color del auto: ");
                    color = Console.ReadLine();
                    color = color.ToUpper();
                    Console.Write("Ingresa el precio del auto: ");
                    precio = Convert.ToDouble(Console.ReadLine());
                    //Escribiendo los datos en el archivo...
                    escritura.WriteLine(noSerie + ", " + modelo + ", " + anio + ", " + fabricante + ", " + color + ", " + precio);
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("***REGISTRO AGREGADO CORRECTAMENTE***");
                    Console.WriteLine("*******************************************");

                }
                else
                {
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("***Ya existe un auto con el No. de Serie " + noSerie + " , Intentalo de nuevo");
                    Console.WriteLine("*******************************************");
                }

                escritura.Close();

            }
            catch (FileNotFoundException fn)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("¡Error! " + fn.Message);
                Console.WriteLine("*******************************************");
            }
            catch (Exception e)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("¡Error! " + e.Message);
                Console.WriteLine("*******************************************");
            }
            finally
            {
                lectura.Close();
                escritura.Close();
            }
        }//Fin del metodo altas


    }//Fin de la clase program
}
