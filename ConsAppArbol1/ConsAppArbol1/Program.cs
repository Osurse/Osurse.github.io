using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppArbol1
{
    public class Nodo
    {
        public int Info { set; get; }
        public Nodo Izq { set; get; }
        public Nodo Der { set; get; }
    }
    public class ArbolBinario
    {
        int conteo=0;
        int cant = 0;
        public Nodo Raiz { set; get; }

        public ArbolBinario()
        {
            Raiz = null;
        }
        public void Insertar(int valor)
        {
            Nodo nuevo = new Nodo();
            nuevo.Info = valor;
            nuevo.Der = null;
            nuevo.Izq = null;
            

            //Recorrer el arbol
            if (Raiz==null)
            {
                Raiz = nuevo;
                conteo++;
            }
            else
            {
                conteo++;
                Nodo anterior = null;
                Nodo reco = Raiz;
                while (reco != null)
                {
                    anterior = reco;
                    if (valor < reco.Info)
                    {
                        reco = reco.Izq;
                    }
                    else
                    {
                        reco = reco.Der;
                    }
                }
                if (valor < anterior.Info)
                {
                    anterior.Izq = nuevo;
                }
                else
                {
                    anterior.Der = nuevo;
                }
            }

        }

        public void Contar()
        {
            Console.WriteLine("El numero de nodos totales es: "+conteo);
        }

        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Console.Write(reco.Info + " ");
                ImprimirPre(reco.Izq);
                ImprimirPre(reco.Der);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(Raiz);
            Console.WriteLine();
        }

        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.Izq);
                Console.Write(reco.Info + " ");
                ImprimirEntre(reco.Der);
            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(Raiz);
            Console.WriteLine();
        }

        private void CantidadNodosHoja(Nodo reco)
        {
            if (reco != null)
            {
                if (reco.Izq == null && reco.Der == null)
                    cant++;
                CantidadNodosHoja(reco.Izq);
                CantidadNodosHoja(reco.Der);
            }
        }

        public int CantidadNodosHoja()
        {
            cant = 0;
            CantidadNodosHoja(Raiz);
            return cant;
        }

        public void MayorValorl()
        {
            if (Raiz != null)
            {
                Nodo reco = Raiz;
                while (reco.Der != null)
                    reco = reco.Der;
                Console.WriteLine("Mayor valor del árbol:" + reco.Info);
            }
        }

        public void BorrarMenor()
        {
            if (Raiz != null)
            {
                if (Raiz.Izq == null)
                    Raiz = Raiz.Der;
                else
                {
                    Nodo atras = Raiz;
                    Nodo reco = Raiz.Izq;
                    while (reco.Izq != null)
                    {
                        atras = reco;
                        reco = reco.Izq;
                    }
                    atras.Izq = reco.Der;
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario miArbol = new ArbolBinario();
            miArbol.Insertar(100);
            miArbol.Insertar(50);
            miArbol.Insertar(25);
            miArbol.Insertar(120);
            miArbol.Insertar(75);
            miArbol.Insertar(150);
            miArbol.Insertar(110);
            Console.WriteLine("Impresion Pre: ");
            miArbol.ImprimirPre();
            miArbol.Contar();
            miArbol.CantidadNodosHoja();
            miArbol.MayorValorl();
            Console.WriteLine("Impresion Entre: ");
            miArbol.ImprimirEntre();
            miArbol.BorrarMenor();
            Console.WriteLine("Impresion Entre con el valor menor borrador: ");
            miArbol.ImprimirEntre();
            Console.ReadKey();
        }
    }
}
