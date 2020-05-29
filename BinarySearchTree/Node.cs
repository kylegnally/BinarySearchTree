using System;


namespace BinarySearchTree
{
    public class Node<T>
    {

        private T el;
        private Node<T> left;
        private Node<T> right;
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
