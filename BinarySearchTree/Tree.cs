using System;
using System.Collections.Generic;

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
        public Tree()
        {
            Root = null;
            current = null;
            TreeSize = 0;
        }

        public int TreeSize { get; private set; }

        public Node<T> Current
        {
            get
            {
                return current;
            }
        }

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

        public Node<T> AddNode(T value)
        {
            Stack<Node<T>> nodeStack = new Stack<Node<T>>();
            Node<T> n = Root;

            while (!Equals(value))
            {
                string s = n.Element.ToString();
                if (s == value.ToString())
                {
                    Console.WriteLine("Found {0) at node: {1}", s, n);
                    return n;
                }
                return null;
            }
            Console.WriteLine("No matching items appear in the tree.");
            return null;
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
                TreeSize++;

            return inserted;
        }

        public int Size()
        {
            return TreeSize;
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
                TreeSize++;

            return inserted;
        }

        public void Destroy(Node<T> node)
        {
            if (node != null)
            {
                Destroy(node.Left);
                Destroy(node.Right);
                node = null;
                TreeSize--;
            }
        }

        public override string ToString()
        {
            return Current.Element.ToString();
        }

        public void InOrder(Node<T> node)
        {
            if (node == null) return;
            InOrder(node.Left);
            Console.Write(node.Element.ToString());
            InOrder(node.Right);
        }

        public void PreOrder(Node<T> node)
        {
            if (node != null) return;
            Console.Write(node.Element);
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void PostOrder(Node<T> node)
        {
            if (node == null) return;
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Element.ToString());
        }
    }
}
