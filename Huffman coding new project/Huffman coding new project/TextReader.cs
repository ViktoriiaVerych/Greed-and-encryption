namespace Huffman_coding_new_project;

public class TextReader
{
    public string Read(string text, string path)
    {
        foreach (var line in File.ReadLines(path))
        {
            text += line;
        }
        return text;
    }
}