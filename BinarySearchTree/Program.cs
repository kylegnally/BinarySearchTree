using System;
using System.Globalization;

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
            // these are used to decide whether to see 
            // parts of the assignment that were required
            // on the handout.
            bool userChoice;
            string choice;

            Tree<string> bt = new Tree<string>();

            // I tried to use an array to store the characters and then 
            // iterate through these. I feel like the list of tree elements
            // could be entered by the user in a line, like:
            //          a,b,s,d,f,e,g
            // and read from that array, but I couldn't get it to work in a
            // way that would make writing that code worth the effort.
            //Console.WriteLine("Enter a series of values to add to the tree,
            //separated by commas: ");

            bt.moveTo(Relative.Root);

            // This could be done differently, I think
            // examples that use Add to add to a tree
            bt.Add("A", Relative.Root);
            bt.Add("B", Relative.LeftChild);
            bt.Add("C", Relative.RightChild);

            bt.moveTo(Relative.LeftChild);
            bt.Add("D", Relative.LeftChild);
            bt.moveTo(Relative.LeftChild);

            bt.Add("F", Relative.RightChild);

            bt.moveTo(Relative.Root);
            bt.moveTo(Relative.RightChild);
            bt.Add("E", Relative.RightChild);
            bt.moveTo(Relative.RightChild);

            bt.Add("G", Relative.LeftChild);

            // let's go to the top of the tree and demonstrate 
            // the other functions we wrote for the assignment!
            bt.moveTo(Relative.Root);

            Console.WriteLine("Demonstration of Size method: ");
            Console.WriteLine(bt.GetTreeSize(bt));

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
            
            // I could not make this work!
            //Console.WriteLine("Demonstration of Add requirement. Please enter a key...\n");
            //string str = Console.ReadLine();
            //bt.Add(str, Relative.Root);
            
            Environment.Exit(0);

        }
    }
}
