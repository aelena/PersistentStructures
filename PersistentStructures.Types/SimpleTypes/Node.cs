using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentStructures.Types.SimpleTypes
{
    public class Node<T>
    {
       
        public T Value { get; set; }
        
        public Node<T> Next { get; set; }
        
        public int Index { get; set; }
       
        public Node<T> Parent { get; set; }
       
        private Node()
        { }
        public Node(T value)
        {
            this.Value = value;
        }
        public override string ToString()
        {
            return String.Format("Valor: {0}, Indice: {1}, Padre: {2}, Hijo: {3}",
                   this.Value, this.Index, (this.Parent == null) ? "X" : this.Parent.Index.ToString(),
                    (this.Next == null) ? "X" : this.Next.Index.ToString());
        }

    }
}
