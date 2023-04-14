namespace Huffman_coding_new_project;

public class Encoder
{
    public void Encode(Node root, string str, Dictionary<string, string> huffmanTable)
    {
        if (root == null)
        {
            return;
        }
    
        if (IsLeaf(root))
        {
            huffmanTable.Add(root.Value, str);
        }
        //рекурсивний виклик, left child = 0, right child = 1
        Encode(root.Left, str + "0", huffmanTable);
        Encode(root.Right, str + "1", huffmanTable);
    }
    public void PrintCodedElements(Dictionary<string, string> elements)
    {
        foreach (var element in elements)
        {
            Console.Write(element.Key);
            Console.Write(" || ");
            Console.WriteLine(element.Value);
        }
    }


    bool IsLeaf(Node node)
    {
        if (node.Left == null && node.Right == null)
        {
            return true;
        }
        return false;
    }
    
}