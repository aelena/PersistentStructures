using PersistentStructures.Types.SimpleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentStructures.Types
{
    class PersistentList<T>
    {

        private List<Node<T>> __list = new List<Node<T>>();
        private Stack<Node<T>> __listT = new Stack<Node<T>>();

        /// <summary>
        /// Devuelve el primer nodo de la lista.
        /// </summary>
        public Node<T> FirstNode
        {
            get { return __list[0]; }
        }

        /// <summary>
        /// Devuelve el último nodo de la lista
        /// </summary>
        public Node<T> LastNode
        {
            get { return __list[__list.Count - 1]; }
        }

        /// <summary>
        /// Cons. privado no llamable
        /// </summary>
        private PersistentList()
        { }

        /// <summary>
        /// Constructor parametrizado. Recibe una lista de T
        /// e inicia la lista con esos valores
        /// </summary>
        /// <param name="list"></param>
        public PersistentList(List<T> list)
        {
            int c = 0;
            foreach (T t in list)
            {
                Node<T> n = new Node<T>(t);
                n.Index = c;
                __list.Add(n);
                if (c == 0)
                {
                    ++c;
                    continue;
                }
                n.Parent = __list1;
                __list1.Next = n;
                ++c;
            }
        }

        /// <summary>
        /// Recibe un elemento de tipo T, lo añade a la lista y
        /// lo guarda en en el stack de elementos añadidos
        /// de manera que quede registrado el cambio en el contenido de la lista
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            /* crear un nodo */
            Node<T> n = new Node<T>(item);
            /* configurar su índice correctamente */
            n.Index = __list.Count;
            /* agregarlo a la lista subyacente */
            __listT.Push(n);
            /* actualizar la referencia del penúltimo nodo */
            __list[__list.Count - 1].Next = n;
            /* y la referencia al nodo padre del nodo añadido */
            n.Parent = __list[__list.Count - 1];
            __list.Add(n);
        }

        /// <summary>
        /// Deshace la última operación de adición a la lista.
        /// </summary>
        public void Undo()
        {
            /* se busca el nodo que hay que eliminar */
            Node<T> _removee = this.__listT.Pop();
            /* se pone a NULL la referencia del padre del nodo */
            _removee.Parent.Next = null;
            /* se elimina el nodo de la lista subyacente */
            this.__list.RemoveAt(_removee.Index);
        }

    }
}
