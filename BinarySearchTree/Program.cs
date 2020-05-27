using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BinarySearchTree
{
    class Program
    {

        static void Main(string[] args)
        {
            Tree<string> myTree = new Tree<string>();


            Console.WriteLine("Enter a series of values to add to the tree, separated by commas: ");
            string[] input = Regex.Split(Console.ReadLine(), ",");
            Node<string> rootNode = null;
            foreach (string aLetter in input)
            {
                myTree.Insert(rootNode, Relative.Root);
            }
            myTree.InOrder(rootNode);
            myTree.PreOrder(rootNode);
            myTree.PostOrder(rootNode);
        }
    }
}
