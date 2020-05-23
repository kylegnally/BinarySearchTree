using System;
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
            myTree.moveTo(Relative.Root);
            for (int i = 0; i < input.Length; i++)
            {
                myTree.Insert(input[i],Relative.Root);
            }
            Console.WriteLine("Tree size: {0}\n", myTree.Size);
            Console.WriteLine("Tree contents: {0}\n", myTree.Current.Element);
            Environment.Exit(0);
        }
    }
}
