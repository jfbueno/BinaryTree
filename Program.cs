using System;
using static System.Console;

namespace BinaryTree
{
    class Program
    {
        static void InOrder(BSTNode p)
        {
            if (p != null) 
            {
                InOrder(p.Left);
                Console.WriteLine(p.Key + " ");
                InOrder(p.Right);
            }
        }
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree();

            tree.Root = new BSTNode(8);

            tree.Root.Left = new BSTNode(4);
            tree.Root.Left.Left = new BSTNode(2);
            tree.Root.Left.Right = new BSTNode(6);

            tree.Root.Right = new BSTNode(18);
            tree.Root.Right.Left = new BSTNode(12);
            tree.Root.Right.Right = new BSTNode(20);

            tree.Root.Right.Left.Left = new BSTNode(10);
            tree.Root.Right.Left.Right = new BSTNode(16);
            tree.Root.Right.Left.Right.Left = new BSTNode(14);


            //tree.ExclusaoFusao(tree.Root.Right);

            tree.ExclusaoCopia(tree.Root.Right.Left);
            InOrder(tree.Root);

            //var papito = tree.EncontrarPai(tree.Root, tree.Root.Left.Right);            
            //tree.ExclusaoCopia(ref tree.Root.Right);
        }
    }
}
