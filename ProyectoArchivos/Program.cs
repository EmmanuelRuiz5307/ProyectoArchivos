﻿using System;
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
                            bajas();
                            break;
                        case 3:
                            consultas();
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

        static void bajas()
        {
            encontrado = false;
            try
            {
                lectura = File.OpenText("autos.txt");
                temporal = File.CreateText("tmp.txt");
                Console.WriteLine("Ingresa el numero de seria del auto que deseas ELIMINAR");
                noSerie = Console.ReadLine();
                noSerie = noSerie.ToUpper();
                cadena = lectura.ReadLine();
                while (cadena != null)
                {
                    campos = cadena.Split(',');
                    //Si en la posicion del noSerie es igual al que andamos buscando , imprimimos los datos
                    //y establecemos la variable encontrado a verdadero
                    if (campos[0].Trim().Equals(noSerie))
                    {
                        encontrado = true;
                        Console.WriteLine("*******************************************");
                        Console.WriteLine("Auto encontrado con los siguientes Datos: ");
                        Console.WriteLine("No. Serie: " + campos[0]);
                        Console.WriteLine("Modelo: " + campos[1]);
                        Console.WriteLine("Anio: " + campos[2]);
                        Console.WriteLine("Marca : " + campos[3]);
                        Console.WriteLine("Color: " + campos[4]);
                        Console.WriteLine("Precio: " + campos[5]);
                        Console.WriteLine("*******************************************");
                        Console.WriteLine("Realmente deseas Eliminarlo(SI/NO)?....");
                        respuesta = Console.ReadLine();
                        respuesta = respuesta.ToUpper();

                        if (!respuesta.Equals("SI"))
                        {
                            temporal.WriteLine(cadena);
                        }
                    }
                    else
                    {
                        temporal.WriteLine(cadena);
                    }
                    //Lectura adelantada
                    cadena = lectura.ReadLine();
                }
                if (encontrado == false)
                {
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("***El un auto con el No. de Serie " + noSerie + " , no esta en la BD");
                    Console.WriteLine("*******************************************");
                } else if (respuesta.Equals("SI"))
                {
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("***Auto Eliminado***");
                    Console.WriteLine("*******************************************");
                }
                else
                {
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("***Operacion de Eliminacion Cancelada**");
                    Console.WriteLine("*******************************************");
                }
                lectura.Close();
                temporal.Close();
                File.Delete("autos.txt");
                File.Move("tmp.txt" , "autos.txt");
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
                temporal.Close();
            }
        }//Fin del metodo bajas....


        static void consultas()
        {
            encontrado = false;
            try
            {
                lectura = File.OpenText("autos.txt");
                Console.WriteLine("Ingresa el fabricante por el auto: ");
                fabricante = Console.ReadLine();
                fabricante = fabricante.ToUpper();
                cadena = lectura.ReadLine();
                while (cadena != null)
                {
                    campos = cadena.Split(',');
                    if (campos[3].Trim().Equals(fabricante))
                    {
                        encontrado = true;
                        Console.WriteLine("*******************************************");
                        Console.WriteLine("Auto encontrado con los siguientes Datos: ");
                        Console.WriteLine("No. Serie: " + campos[0]);
                        Console.WriteLine("Modelo: " + campos[1]);
                        Console.WriteLine("Anio: " + campos[2]);
                        Console.WriteLine("Marca : " + campos[3]);
                        Console.WriteLine("Color: " + campos[4]);
                        Console.WriteLine("Precio: " + campos[5]);
                        Console.WriteLine("*******************************************");  
                    }
                    cadena = lectura.ReadLine();
                }//fin del while

                //Si no hay autos con ese fabricante...
                if (encontrado == false)
                {
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("***No hay autos con el fabricante**" + fabricante);
                    Console.WriteLine("*******************************************");
                }
                lectura.Close();
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
            }finally
            {
                lectura.Close();
            }
        }

    }//Fin de la clase program
}
