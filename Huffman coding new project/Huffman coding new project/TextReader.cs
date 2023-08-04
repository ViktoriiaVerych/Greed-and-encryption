namespace Huffman_coding_new_project;

/*
The TextReader class reads text data from a specified file path and appends it to an existing text string.
The Read method takes two parameters: a string named text (which presumably initially holds some text) and a string named path representing the file path to read from.
It uses a foreach loop to iterate through each line in the file, obtained using File.ReadLines(path).
It appends each line of text from the file to the text string.
After reading all lines, it returns the concatenated text string, which now holds the complete text content of the file.
Overall, the TextReader class provides a simple utility for reading text data from files and combining it into a single string.
*/
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
