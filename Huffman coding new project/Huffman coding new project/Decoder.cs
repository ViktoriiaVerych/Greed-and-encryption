namespace Huffman_coding_new_project;

/*
1. The `Decoder` class has a method called `DecodeFile` which takes two inputs: a `Node` representing the root of a Huffman tree, and a list of strings named `codedText` which contains the encoded text.

2. Inside the `DecodeFile` method:
   - It initializes a variable `decodedFile` to store the decoded text.
   - It starts at the root of the Huffman tree (`current = root`).
   - It combines all the strings in the `codedText` list to create a continuous string named `symbol`.
   - It then iterates through each character (bit) in the `symbol` string.
   - For each bit:
     - If the bit is '0', it moves `current` to its left child in the Huffman tree.
     - If the bit is '1', it moves `current` to its right child.
     - If `current` becomes a leaf node (no left or right children), it appends the corresponding symbol to the `decodedFile` and resets `current` to the root.
   - This process continues until all bits have been processed.

3. Once the loop completes, the method returns the `decodedFile`, which now contains the decoded text extracted from the input coded text using the provided Huffman tree structure.

In essence, the code simulates traversing a Huffman tree based on the encoded bits, and at each leaf node, it collects the corresponding symbols to reconstruct the original text.
*/
public class Decoder
{
    public string DecodeFile(Node root, List<string>codedText)
    {
        string decodedFile = null;
        var current = root;
        var symbol = string.Join("", codedText);
        
        
        foreach (var bit in symbol)
        {
        
            if (bit == '0')
            {
                current = current.Left;
            }
        
            else if (bit == '1')
            {
                current = current.Right;
            }
            
            if (current.Right == null && current.Left == null)
            {
                decodedFile += current.Value;
                current = root;
            }
        }

        return decodedFile;
    }
}
