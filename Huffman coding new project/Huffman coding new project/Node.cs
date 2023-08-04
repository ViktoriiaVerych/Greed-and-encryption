using System.Collections.Generic;

/*
The Node class represents nodes in a tree structure, commonly used for Huffman coding.
It has properties for the Symbol (character), Frequency, references to the Right and Left child nodes, and a Value which could represent a combined value in the case of Huffman coding.
The Traverse method is used to traverse the tree and find a path to a specified symbol (character). It returns a list of booleans representing the path taken to reach the desired symbol.
The constructor initializes the node with a Value, Frequency, and references to its children (Left and Right).
*/
namespace Huffman_coding_new_project
{
    public class Node
    {
        public char Symbol { get; set; }
        public int Frequency { get;  }
        public Node Right { get;  }
        public Node Left { get;  }
        
        public string Value { get; }

        public List<bool> Traverse(char symbol, List<bool> data = null)
        {
            if (data == null)
                data = new List<bool>();
        
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.Symbol))
                    return data;
                else
                    return null;
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;
        
                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);
                    left = Left.Traverse(symbol, leftPath);
                }
        
                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.Traverse(symbol, rightPath);
                }
        
                if (left != null)
                    return left;
                else
                    return right;
            }
        }
        public Node(string value, int frequency, Node left, Node right)
        {
            Frequency = frequency;
            Right = right;
            Left = left;
            Value = value;
        }
    }
}
