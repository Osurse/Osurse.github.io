using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppBanco
{
    public class Cliente
    {
        class Nodo
        {
            public int info;
            public Nodo sig;
        }

        private Nodo raiz, fondo;

        public void Cola()
        {
            raiz = null;
            fondo = null;
        }

        public bool Vacia()
        {
            if (raiz == null)
                return true;
            else
                return false;
        }

        public void Insertar(int info)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.info = info;
            nuevo.sig = null;
            if (Vacia())
            {
                raiz = nuevo;
                fondo = nuevo;
            }
            else
            {
                fondo.sig = nuevo;
                fondo = nuevo;
            }
        }

        public int Extraer()
        {
            if (!Vacia())
            {
                int informacion = raiz.info;
                if (raiz == fondo)
                {
                    raiz = null;
                    fondo = null;
                }
                else
                {
                    raiz = raiz.sig;
                }
                return informacion;
            }
            else
                return 0;
        }

        
        public int Cantidad()
        {
            int cant = 0;
            Nodo reco = raiz;
            while (reco != null)
            {
                cant++;
                reco = reco.sig;
            }
            return cant;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random ale = new Random();
            int caja = 0;
            int llegada = 2 + ale.Next(0, 2);
            int movimiento = 0;
            int movimientos = 0;
            int acu = 0;
            int salida = 0;
            int atendidos = 0;
            Cliente clie = new Cliente();
            for (int minuto = 0; minuto < 60000; minuto++)
            {
                if (llegada == minuto)
                {
                    if (caja == 0)
                    {
                        caja = 1;
                        movimientos = 1 + ale.Next(0, 4);//genera los movimientos que se realizaran por el cliente
                        for (int i = 0; i <= movimientos; i++)//ejecuta el numero de movimientos
                        {
                            movimiento = 1 + ale.Next(0, 3);//genera el tipo de movimiento que se realiza

                            switch (movimiento)//suma el timepo tardado por tipo de movimiento
                            {
                                case 1://deposito
                                    acu = acu + 4;
                                    break;
                                case 2://retiro
                                    acu = acu + 5;
                                    break;
                                case 3://operacion con cheques
                                    acu = acu + 7;
                                    break;
                                case 4://Transferencias
                                    acu = acu + 10;
                                    break;
                            }
                            }
                        salida = salida + acu;
                        }
                    }
                else
                {
                    clie.Insertar(llegada);
                }
                llegada = llegada +2+ ale.Next(0,2);
                if (salida==minuto)
                {
                    caja = 0;
                    atendidos++;
                    if (!clie.Vacia())
                    {
                        clie.Extraer();
                        caja = 1;
                        movimientos = 1 + ale.Next(0, 4);//genera los movimientos que se realizaran por el cliente
                        for (int i = 0; i <= movimientos; i++)//ejecuta el numero de movimientos
                        {
                            movimiento = 1 + ale.Next(0, 3);//genera el tipo de movimiento que se realiza

                            switch (movimiento)//suma el timepo tardado por tipo de movimiento
                            {
                                case 1://deposito
                                    acu = acu + 4;
                                    break;
                                case 2://retiro
                                    acu = acu + 5;
                                    break;
                                case 3://operacion con cheques
                                    acu = acu + 7;
                                    break;
                                case 4://Transferencias
                                    acu = acu + 10;
                                    break;
                            }
                        }
                        salida = salida + acu;
                    }
                }
                }
            Console.WriteLine("Atendidos:"+atendidos);
            Console.WriteLine("En Espera:"+clie.Cantidad());
            Console.WriteLine("tiempo de llegada:"+clie.Extraer());
            Console.ReadLine();



        }
        }
    }

/*Console.WriteLine("¿Cuanto tiempo quieres que dure tu simulacion (máximo 5min.)?");
int Tiempo = int.Parse(Console.ReadLine());
Queue<Cliente> Fila = new Queue<Cliente>();

int Timer = DateTime.Now.Minute;
int Timer2 = 0;
Cliente cliente = new Cliente(0);
Fila.Enqueue(cliente);
int NumeroClientes = 1;
do
{
    cliente = new Cliente(NumeroClientes);
    Fila.Enqueue(cliente);
    Timer2 = DateTime.Now.Minute;
} while (Timer2 - Timer != Tiempo);
Console.WriteLine("En la fila hay ..." + Fila.Count);
Console.ReadKey();*/


