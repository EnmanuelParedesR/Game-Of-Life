using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeLaVida_Final._2
{
    class Juego_Celulas
    {
     
        public static int Columnas;
        public static int Filas;
        public bool[,] Matrix;
        public List<bool[,]> Matrices = new List<bool[,]>();
        public int Contador_Repeticiones = 0;

        public void Constructor(int columnas, int filas)
        {

            Columnas = columnas;
            Filas = filas;
            Matrix = new bool[Columnas, Filas];
        
        }

        public void Llenado_Aleatorio()
        {

            var Aleatorio = new Random();

            for (int x = 0; x < Columnas; x++)
            {

                for (int y = 0; y < Filas; y++)
                {

                    this.Matrix[x, y] = Aleatorio.NextDouble() < 0.20;
                }
            }
        }
        public void Llena_Porcentaje(float porcentaje)
        {

            var Aleatorio = new Random();

            for (int x = 0; x < Columnas; x++)
            {

                for (int y = 0; y < Filas; y++)
                {

                    this.Matrix[x, y] = Aleatorio.NextDouble() < porcentaje;
                }
            }
        }

        public void Siguiente_Generacion()
        {
            bool[,] Matrix_Secundaria = new bool[Columnas, Filas];
            
            if(Contador_Repeticiones == 0)
            {
                Matrices.Add(Matrix);      
            }

            for (int x = 0; x < Columnas; x++)
            {

                for (int y = 0; y < Filas; y++)
                {

                    Matrix_Secundaria[x, y] = this.GetNext(x, y);
                }
            }
            Matrices.Add(Matrix_Secundaria);          
            this.Matrix = Matrix_Secundaria;

            Contador_Repeticiones++;

        }

        private bool GetNext(int x, int y)
        {
            var Viva = this.Matrix[x, y];
            var Vivientes = this.Vecinos_Existentes(x, y);

            if (!Viva)
            {
                return (Vivientes == 3);
            }

            return (Vivientes == 2 || Vivientes == 3);
        }

        private int Vecinos_Existentes(int x, int y)
        {
            var Celulas_Vecinas = this.Celulas_Vivas(x - 1, y - 1) + this.Celulas_Vivas(x + 0, y - 1) +

                this.Celulas_Vivas(x + 1, y - 1) +

                this.Celulas_Vivas(x - 1, y) +

                this.Celulas_Vivas(x + 1, y) +

                this.Celulas_Vivas(x - 1, y + 1) +

                this.Celulas_Vivas(x + 0, y + 1) +

                this.Celulas_Vivas(x + 1, y + 1);

            return Celulas_Vecinas;

        }

        private int Celulas_Vivas(int x, int y)
        {
            if (x < 0 || x > Columnas - 1)
            {
                return 0;
            }
            if (y < 0 || y > Filas - 1)
            {
                return 0;
            }
            return this.Matrix[x, y] ? 1 : 0;
        }

        public void Imprimir()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 0; x < Columnas; x++)

            {
                for (int y = 0; y < Filas; y++)
                     
                    Console.Write("|{0}", this.Matrix[x, y] ? "■" : " ");

                Console.WriteLine("|");

            }
          
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        
        public void Creacion_Manual(int x, int y)
        {
            this.Matrix[x, y] = true;
        }
    }
}
