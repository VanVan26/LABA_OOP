
using System;
using System.ComponentModel;
namespace Laba1_3 { 
class Program
{
    public static void Main()
    {
        var head = new TreeNode("Head");
        var a = new TreeNode("a");
        var b = new TreeNode("b");
        var c = new TreeNode("c");
        var a1 = new TreeNode("a1");
        var a11 = new TreeNode("a11");
        a1.AddChildren(a11);
        a1.AddChildren(new TreeNode("a12"));
        a.AddChildren(a1);
        a.AddChildren(new TreeNode("a2"));
        b.AddChildren(new TreeNode("b1"));
        c.AddChildren(new TreeNode("c1"));
        c.AddChildren(new TreeNode("c2"));
        c.AddChildren(new TreeNode("c3"));
        a11.AddChildren(new TreeNode("a111"));
        head.AddChildren(a);
        head.AddChildren(b);
        head.AddChildren(c);
        Console.WriteLine(head.ToString());
    }
}
}