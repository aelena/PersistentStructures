using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistentStructures.Types;
using PersistentStructures.Types.SimpleTypes;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            PersistentList<int> pl = new PersistentList<int>(new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
            Console.WriteLine("Añadiendo nodo con valor 22");
            Console.WriteLine("Ultimo Nodo: {0}", pl.LastNode);
            pl.Add(22);
            Console.WriteLine("Añadiendo nodo con valor 42");
            Console.WriteLine("Ultimo Nodo: {0}", pl.LastNode);
            pl.Add(42);
            Console.WriteLine("Añadiendo nodo con valor 62");
            Console.WriteLine("Ultimo Nodo: {0}", pl.LastNode);
            pl.Add(62);
            Console.WriteLine("Añadiendo nodo con valor 82");
            Console.WriteLine("Ultimo Nodo: {0}", pl.LastNode);
            pl.Add(82);

            Print(pl);
            Console.WriteLine("Last Node : {0}", pl.LastNode);

            Console.WriteLine(" ===================================================== ");

            Console.WriteLine("Deshaciendo ultima operacion ( eliminar nodo con valor 82 )");
            pl.Undo();
            Console.WriteLine("Ultimo Nodo: {0}", pl.LastNode);
            Console.WriteLine("Deshaciendo ultima operacion ( eliminar nodo con valor 62 )");
            pl.Undo();
            Console.WriteLine("Ultimo Nodo: {0}", pl.LastNode);

            Print(pl);
            Console.WriteLine("Last Node : {0}", pl.LastNode);
            Console.ReadLine();
        }

        static void Print(PersistentList<int> pl)
        {
            Node<int> _node = pl.FirstNode;     // puntero nodo 0
            while (_node != null)
            {
                Console.WriteLine(_node);
                _node = _node.Next;
            }
        }
    }
}
