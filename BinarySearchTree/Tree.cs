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
        public Tree()
        {
            Root = null;
            Current = null;
            Size = 0;
        }

        public int Size { get; private set; }

        public Node<T> Current { get; private set; }

        public Node<T> Root { get; private set; }

        public Boolean isEmpty
        {
            get => Root == null;
        }

        public Boolean moveTo(Relative relative)
        {
            Boolean found = false;


            switch (relative)
            {
                case Relative.LeftChild:
                    if (Current.Left != null)
                    {
                        Current = Current.Left;
                        found = true;
                    }

                    break;

                case Relative.RightChild:
                    if (Current.Right != null)
                    {
                        Current = Current.Right;
                        found = true;
                    }
                    break;

                case Relative.Root:
                    if (Root != null)
                    {
                        Current = Root;
                        found = true;
                    }
                    break;

                case Relative.Parent:
                    if (Current != Root)
                    {
                        Current = findParent(Current);
                        found = true;
                    }
                    break;
            }

            return found;
        }

        public Node<T> findParent(Node<T> node)
        {
            Stack<Node<T>> s = new Stack<Node<T>>();
            Node<T> n = Root;

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

            if ((relative == Relative.LeftChild && Current.Left != null) ||
                  relative == Relative.RightChild && Current.Right != null)
            {
                inserted = false;
            }
            else
            {
                if (relative == Relative.LeftChild)
                {
                    Current.Left = newNode;
                }
                else if (relative == Relative.RightChild)
                {
                    Current.Right = newNode;
                }
                else if (relative == Relative.Root)
                {
                    if (Root == null)
                    {
                        Root = newNode;
                    }
                    Current = Root;
                }
            }

            if (inserted)
                Size++;

            return inserted;
        }

        public Boolean Insert(Node<T> treeNode, Relative relative)
        {
            Boolean inserted = true;
            Node<T> newNode = new Node<T>(treeNode.Element);

            if ((relative == Relative.LeftChild && Current.Left != null) ||
                  relative == Relative.RightChild && Current.Right != null)
            {
                inserted = false;
            }
            else
            {
                if (relative == Relative.LeftChild)
                {
                    Current.Left = newNode;
                }
                else if (relative == Relative.RightChild)
                {
                    Current.Right = newNode;
                }
                else if (relative == Relative.Root)
                {
                    if (Root == null)
                    {
                        Root = newNode;
                    }
                    Current = Root;
                }
            }

            if (inserted)
                Size++;

            return inserted;
        }


        public void Destroy(Node<T> node)
        {
            if (node != null)
            {
                Destroy(node.Left);
                Destroy(node.Right);
                node = null;
                Size--;
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
