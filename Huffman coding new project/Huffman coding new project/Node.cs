using System.Collections.Generic;

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
        
            // Leaf
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
