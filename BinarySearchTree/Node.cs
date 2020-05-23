using System;


namespace BinarySearchTree
{
    public class Node<T>
    {
        public Node(T element)
        {
            Element = element;
            Left = null;
            Right = null;
        }

        public T Element { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Boolean isLeaf
        {
            get
            {
                return Left == null && Right == null;
            }
        }
    }
}
