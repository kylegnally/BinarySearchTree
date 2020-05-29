using System;

namespace BinarySearchTree
{
    class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Tree<string> bt = new Tree<string>();

            //Console.WriteLine("Enter a series of values to add to the tree, separated by commas: ");

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
            Console.WriteLine("Size: {0}", bt.Size);
            bt.moveTo(Relative.Root);
            //Console.WriteLine("Current Element: {0}", Relative.Root.ToString());
            
            Console.WriteLine("Preorder Traversal");
            bt.PreOrder(bt.Root);
            Console.WriteLine("\n");

            Console.WriteLine("Inorder Traversal");
            bt.InOrder(bt.Root);
            Console.WriteLine("\n");

            Console.WriteLine("Postorder Traversal");
            bt.PostOrder(bt.Root);
            Console.WriteLine("\n");

            bt.moveTo(Relative.Root);
            bt.moveTo(Relative.RightChild);
            Console.WriteLine("Done.");

            Console.WriteLine(bt.Current);
            bt.moveTo(Relative.LeftChild);
            bt.moveTo(Relative.LeftChild);
            Console.WriteLine(bt.Current);

            Environment.Exit(0);
        }
    }
}
