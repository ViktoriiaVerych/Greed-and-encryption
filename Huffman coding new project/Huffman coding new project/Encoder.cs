namespace Huffman_coding_new_project;


1. The `Encoder` class has three methods: `Encode`, `PrintCodedElements`, and a helper method `IsLeaf`.

2. **Encode Method**:
   - The `Encode` method takes three parameters: a `Node` representing the root of a Huffman tree, a string `str` representing the encoding path, and a `Dictionary<string, string>` named `huffmanTable` to store the mapping of symbols to their Huffman codes.
   - It checks if the `root` is `null`, in which case it returns.
   - If the `root` is a leaf node (no children), it adds the current `str` (the encoding path) to the `huffmanTable` dictionary, associated with the value of the leaf node (`root.Value`).
   - The method then makes recursive calls to encode the left child with an appended '0' to the encoding path, and the right child with an appended '1' to the encoding path.

3. **PrintCodedElements Method**:
   - The `PrintCodedElements` method takes a `Dictionary<string, string>` named `elements` as input.
   - It iterates through the elements in the dictionary and prints each key-value pair, where the key represents the symbol and the value represents its Huffman code.

4. **IsLeaf Method**:
   - The `IsLeaf` method takes a `Node` named `node` as input.
   - It checks if the given node has no left and right children, which indicates that it's a leaf node in the Huffman tree.
   - It returns `true` if the node is a leaf, otherwise `false`.

In summary, the `Encoder` class is responsible for generating Huffman codes for symbols in a given Huffman tree. It uses a recursive approach to traverse the tree, assigning '0' for left edges and '1' for right edges in the encoding path. The `PrintCodedElements` method helps visualize the mapping between symbols and their corresponding Huffman codes. The `IsLeaf` method is a helper function to determine whether a node is a leaf in the Huffman tree.


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
