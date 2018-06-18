using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JuegoDeLaVida_Final._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Opcion;
            int FilasI = 10;
            int ColumnasI = 10;
            int contador2 = 0;
            List<Juego_Celulas> Generaciones = new List<Juego_Celulas>();
            List<bool[,]> Generacion_Copia = new List<bool[,]>();
            ConsoleKeyInfo Tecla;
           
            do
            {
                Console.Title = "Juego de la vida en c# | Enmanuel Paredes R 1071051";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n");
                Console.WriteLine("## Bienvenido al Juego de la Vida. ## \n " +
               "Presione la opcion deseada:\n" +
               "#1. Crear celulas aleatoriamente.\n" +
               "#2. Introducir Celulas en la matrix.\n" +
               "#3. Comenzar el juego en base a porcentaje de poblacion aleatoria \n" +
               "#4. Cambiar el tamano de la pantalla de juego. \n" +
               "#5. Salir del juego.\n");
             
                    Opcion = int.Parse(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Generaciones.Add(new Juego_Celulas());
                        Generaciones[contador2].Constructor(ColumnasI, FilasI);
                        Generaciones[contador2].Llenado_Aleatorio();
                        Cambio_Generaciones(contador2, Generaciones, Generacion_Copia, ColumnasI, FilasI);

                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Generaciones.Add(new Juego_Celulas());
                        Generaciones[contador2].Constructor(ColumnasI, FilasI);

                        do
                        {

                            int x, y;
                            Console.WriteLine("Creacion de la Generacion #1 manualmente");
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Introduzca la posicion en 'X': ");
                            x = int.Parse(Console.ReadLine());
                            Console.WriteLine("Introduzca la posicion en 'Y': ");
                            y = int.Parse(Console.ReadLine());

                            Generaciones[contador2].Creacion_Manual(x, y);

                            do
                            {
                                Console.WriteLine("Para seguir introduciendo celulas presione la flecha para bajar. Para salir presione Escape [Esc]");
                                Tecla = Console.ReadKey(true);
                                switch (Tecla.Key)
                                {
                                    case ConsoleKey.Escape:
                                        Console.WriteLine("Ha salido correctamente!");
                                        break;

                                    case ConsoleKey.DownArrow:

                                        break;

                                    default:
                                        Console.WriteLine("Opcion Erronea. Porfavor utilice la flecha para bajar para continuar o [Esc] para salir.");
                                        Console.WriteLine("");
                                        break;
                                }

                            } while (Tecla.Key != ConsoleKey.Escape && Tecla.Key != ConsoleKey.DownArrow);
                          
                        } while (Tecla.Key != ConsoleKey.Escape);

                        Cambio_Generaciones(contador2, Generaciones, Generacion_Copia, ColumnasI, FilasI);
                        break;

                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        float porcentaje;

                        while (true)
                        {
                            Console.WriteLine("Introduzca el porcentaje de poblacion que desea tener");

                            porcentaje = int.Parse(Console.ReadLine());
                            if (porcentaje > 100 || porcentaje < 0)
                            {
                                Console.WriteLine("Porcentaje invalido");
                            }
                            else
                            {
                                break;
                            }
                        }
                        porcentaje = porcentaje / 100;
                        Generaciones.Add(new Juego_Celulas());
                        Generaciones[contador2].Constructor(ColumnasI, FilasI);
                        Generaciones[contador2].Llena_Porcentaje(porcentaje);
                        Cambio_Generaciones(contador2, Generaciones, Generacion_Copia, ColumnasI, FilasI);

                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Introduzca la cantidad de columnas que tendra el juego");
                        ColumnasI = int.Parse(Console.ReadLine());
                        Console.WriteLine("Introduzca la cantidad de filas que tendra el juego");
                        FilasI = int.Parse(Console.ReadLine());

                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Ha Salido correctamente!");
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Opciòn invalida!");
                        break;
                }

            } while (Opcion != 5);
           
        }

        public static void Cambio_Generaciones(int contador2, List<Juego_Celulas> Generaciones, List<bool[,]> Generacion_Copia,int columna,int fila)
        {
            ConsoleKeyInfo Tecla1;
          

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Generacion  #{0}", contador2 + 1);
                Generaciones[contador2].Imprimir();

                do
                {
                  
                    Console.WriteLine("Presione la flecha de abajo para pasar a la siguiente generacion, presione Escape [Esc] salir del generador de generaciones.");

                    Tecla1 = Console.ReadKey(true);

                    switch (Tecla1.Key)
                    {
                        case ConsoleKey.Escape:
                            
                            if(contador2 -1 <= 0)
                            {
                                Console.WriteLine("Ha salido correctamente!");
                            }
                            else
                            {
                                Console.WriteLine("Ha salido correctamente!");
                                Generacion_Copia = Generaciones[contador2 - 1].Matrices;
                            }                       
                            break;

                        case ConsoleKey.DownArrow:
                            
                            break;                

                        default:
                            Console.WriteLine("Opcion Erronea. Porfavor utilice la flecha para bajar para continuar o [Esc] para salir.");
                            Console.WriteLine("");
                            break;
                    }
                } while (Tecla1.Key != ConsoleKey.Escape && Tecla1.Key != ConsoleKey.DownArrow);

                contador2++;
                Generaciones.Add(new Juego_Celulas());
                Generaciones[contador2] = Generaciones[contador2 - 1];
                Generaciones[contador2].Siguiente_Generacion();
                Console.Beep();
                Console.Clear();
            } while (Tecla1.Key != ConsoleKey.Escape);
                    
            do
            {
                if (contador2 - 1 < 0)
                {
                    Console.WriteLine("Presione [Esc] para salir.");
                }
                else
                {
                    Console.WriteLine("Presione la flecha para arriba si desea ver alguna generacion, de lo contrario presione Escape [Esc]");
                }
                   
                Tecla1 = Console.ReadKey(true);

                switch (Tecla1.Key)
                {
                    case ConsoleKey.Escape:
                        Console.WriteLine("Volviendo al menu principal...");
                        Thread.Sleep(1500);
                        break;

                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;

                        if (contador2 - 1 < 0)
                        {
                            Console.WriteLine("ha llegado al final de las generaciones");
                            Console.WriteLine(" ");
                            
                        }
                        else
                        {                            
                            bool[,] Matrices_Buscadas = new bool[columna, fila];

                            if(Generacion_Copia.Count == 0)
                            {
                                Console.WriteLine("No existe generacion anterior");
                                break;
                            }
                            Matrices_Buscadas = Generacion_Copia[contador2 - 1];

                            Console.WriteLine("Generacion #{0}", contador2);

                            for (int x = 0; x < columna; x++)

                            {
                                for (int y = 0; y < fila; y++)

                                    Console.Write("|{0}", Matrices_Buscadas[x, y] ? "■" : " ");

                                Console.WriteLine("|");

                            }                       
                        }
                        contador2--;
                        Console.Beep();
                        break;

                    default:         
                        
                            Console.WriteLine("Opcion Erronea. Porfavor utilice la flecha para bajar para continuar o [Esc] para salir.");
                            Console.WriteLine(" ");
                     
                        break;
                }
                
            } while (Tecla1.Key != ConsoleKey.Escape);

            Generaciones.Clear();
        }
    } 
}


