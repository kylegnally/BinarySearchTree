using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BinarySearchTree
{
    class Program
    {

        static void Main(string[] args)
        {
            Tree<string> bt = new Tree<string>();

            Console.WriteLine("Enter a series of values to add to the tree, separated by commas: ");

            bt.moveTo(Relative.Root);

            bt.Insert("A", Relative.Root);
            bt.Insert("B", Relative.LeftChild);
            bt.Insert("C", Relative.RightChild);

            bt.moveTo(Relative.LeftChild);
            bt.Insert("D", Relative.LeftChild);
            bt.moveTo(Relative.LeftChild);

            bt.Insert("F", Relative.RightChild);

            bt.moveTo(Relative.Root);
            bt.moveTo(Relative.RightChild);
            bt.Insert("E", Relative.RightChild);
            bt.moveTo(Relative.RightChild);

            bt.Insert("G", Relative.LeftChild);
            bt.moveTo(Relative.Root);
            Console.WriteLine("Size: {0}", bt.TreeSize);

            Console.WriteLine("Preorder Traversal");
            bt.PreOrder(bt.RootNode);
            Console.WriteLine("\n");

            Console.WriteLine("Inorder Traversal");
            bt.InOrder(bt.RootNode);
            Console.WriteLine("\n");

            Console.WriteLine("Postorder Traversal");
            bt.PostOrder(bt.RootNode);
            Console.WriteLine("\n");

            bt.moveTo(Relative.Root);
            bt.moveTo(Relative.RightChild);
            Console.WriteLine("Done.");
            Environment.Exit(0);
        }
    }
}
