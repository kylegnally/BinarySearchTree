using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

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
            RootNode = null;
            CurrentNode = null;
            TreeSize = 0;
        }

        public int TreeSize { get; private set; }

        public Node<T> CurrentNode { get; private set; }

        public Node<T> RootNode { get; private set; }

        public Boolean isEmpty
        {
            get => RootNode == null;
        }

        public Boolean moveTo(Relative relative)
        {
            Boolean found = false;


            switch (relative)
            {
                case Relative.LeftChild:
                    if (CurrentNode.Left != null)
                    {
                        CurrentNode = CurrentNode.Left;
                        found = true;
                    }

                    break;

                case Relative.RightChild:
                    if (CurrentNode.Right != null)
                    {
                        CurrentNode = CurrentNode.Right;
                        found = true;
                    }
                    break;

                case Relative.Root:
                    if (RootNode != null)
                    {
                        CurrentNode = RootNode;
                        found = true;
                    }
                    break;

                case Relative.Parent:
                    if (CurrentNode != RootNode)
                    {
                        CurrentNode = findParent(CurrentNode);
                        found = true;
                    }
                    break;
            }

            return found;
        }

        public Node<T> findParent(Node<T> node)
        {
            Stack<Node<T>> s = new Stack<Node<T>>();
            Node<T> n = RootNode;

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
            
            if (relative == Relative.LeftChild && current.Left != null ||
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

        public Boolean Insert(Node<T> treeNode, Relative relative)
        {
            Boolean inserted = true;
            Node<T> newNode = new Node<T>(treeNode.Element);

            if ((relative == Relative.LeftChild && CurrentNode.Left != null) ||
                  relative == Relative.RightChild && CurrentNode.Right != null)
            {
                inserted = false;
            }
            else
            {
                if (relative == Relative.LeftChild)
                {
                    CurrentNode.Left = newNode;
                }
                else if (relative == Relative.RightChild)
                {
                    CurrentNode.Right = newNode;
                }
                else if (relative == Relative.Root)
                {
                    if (RootNode == null)
                    {
                        RootNode = newNode;
                    }
                    CurrentNode = RootNode;
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
