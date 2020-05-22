using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public enum Relative
    {
        LeftChild, RightChild, Parent, Root
    }

    public class Tree<T>
    {


        private Node<T> root;
        private Node<T> current;
        private int size;

        public Tree()
        {
            root = null;
            current = null;
            size = 0;
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public Node<T> Current
        {
            get
            {
                return current;
            }
        }

        public Node<T> Root
        {
            get
            {
                return root;
            }
        }

        public Boolean isEmpty
        {
            get
            {
                return root == null;
            }
        }

        public Boolean moveTo(Relative relative)
        {
            Boolean found = false;


            switch (relative)
            {
                case Relative.LeftChild:
                    if (current.Left != null)
                    {
                        current = current.Left;
                        found = true;
                    }

                    break;

                case Relative.RightChild:
                    if (current.Right != null)
                    {
                        current = current.Right;
                        found = true;
                    }
                    break;

                case Relative.Root:
                    if (root != null)
                    {
                        current = root;
                        found = true;
                    }
                    break;

                case Relative.Parent:
                    if (current != root)
                    {
                        current = findParent(current);
                        found = true;
                    }
                    break;
            }

            return found;
        }

        public Node<T> findParent(Node<T> node)
        {
            Stack<Node<T>> s = new Stack<Node<T>>();
            Node<T> n = root;

            while (n.Left != node && n.Right != node)
            {
                if (n.Right != null)
                    s.Push(n.Right);

                if (n.Left != null)
                    n = n.Left;
                else
                    n = s.Pop();
            }
            s.Clear();
            return n;
        }

        public Boolean Insert(T value, Relative relative)
        {
            Boolean inserted = true;
            Node<T> newNode = new Node<T>(value);

            if ((relative == Relative.LeftChild && current.Left != null) ||
                  relative == Relative.RightChild && current.Right != null)
            {
                inserted = false;
            }
            else
            {
                if (relative == Relative.LeftChild)
                {
                    current.Left = newNode;
                }
                else if (relative == Relative.RightChild)
                {
                    current.Right = newNode;
                }
                else if (relative == Relative.Root)
                {
                    if (root == null)
                    {
                        root = newNode;
                    }
                    current = root;
                }
            }

            if (inserted)
                size++;

            return inserted;
        }

        public Boolean Insert(Node<T> treeNode, Relative relative)
        {
            Boolean inserted = true;
            Node<T> newNode = new Node<T>(treeNode.Element);

            if ((relative == Relative.LeftChild && current.Left != null) ||
                  relative == Relative.RightChild && current.Right != null)
            {
                inserted = false;
            }
            else
            {
                if (relative == Relative.LeftChild)
                {
                    current.Left = newNode;
                }
                else if (relative == Relative.RightChild)
                {
                    current.Right = newNode;
                }
                else if (relative == Relative.Root)
                {
                    if (root == null)
                    {
                        root = newNode;
                    }
                    current = root;
                }
            }

            if (inserted)
                size++;

            return inserted;
        }


        public void Destroy(Node<T> node)
        {
            if (node != null)
            {
                Destroy(node.Left);
                Destroy(node.Right);
                node = null;
                size--;
            }
        }

        public void InOrder(Node<T> node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.Write(node.Element.ToString());
                InOrder(node.Right);
            }
        }

        public void PreOrder(Node<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Element.ToString());
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        public void PostOrder(Node<T> node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                Console.Write(node.Element.ToString());
            }
        }
    }
}
