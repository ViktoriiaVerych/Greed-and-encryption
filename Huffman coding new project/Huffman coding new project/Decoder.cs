namespace Huffman_coding_new_project;

public class Decoder
{
    public string DecodeFile(Node root, List<string>codedText)
    {
        string decodedFile = null;
        var current = root;
        var symbol = string.Join("", codedText);
        
        //Траверс на основі бітів в закодованому тексті
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
            //досягли кінця, додаємо відповідний символ і повертаємось до root
            if (current.Right == null && current.Left == null)
            {
                decodedFile += current.Value;
                current = root;
            }
        }

        return decodedFile;
    }
}