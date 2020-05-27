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
            //Boolean inserted = true;
            //Node<T> newNode = new Node<T>(value);

            //// if (we are already on the left child AND it already has data) OR (we are already on the right child AND it already has data)
            //if ((relative == Relative.LeftChild && CurrentNode.Left != null) ||
            //      relative == Relative.RightChild && CurrentNode.Right != null)
            //{
            //    // we insert nothing
            //    inserted = false;
            //}
            //else
            //{   // if the relative we were passed equals the one stored in the left child
            //    if (relative == Relative.LeftChild)
            //    {
            //        // make the left child of the current node equal to the value that was passed in
            //        CurrentNode.Left = newNode;
            //    }
            //    // if the relative we were passed equals the one stored in the right child
            //    else if (relative == Relative.RightChild)
            //    {
            //        // make the right child of the current node equal to the value that was passed in
            //        CurrentNode.Right = newNode;
            //    }
            //    // if the relative we were passed equals the one stored in the relative root 
            //    else if (relative == Relative.Root)
            //    {
            //        // if the value ofr the relative that was passed in is null
            //        if (RootNode == null)
            //        {
            //            // set the root node equal to the value of the new node we created above
            //            RootNode = newNode;
            //        }
            //        // set CurrentNodce's value equal to that of the RootNode
            //        CurrentNode = RootNode;
            //    }
            //}

            //// increase the value of Size if we did an insert
            //if (inserted)
            //    TreeSize++;

            //// return the flag
            //return inserted;
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
