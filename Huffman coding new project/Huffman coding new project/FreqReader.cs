namespace Huffman_coding_new_project;

/*

1. The `FreqReader` class has a method named `Read` that takes two parameters: a `Dictionary<char, int>` named `storeElements` to store character frequencies, and a string `path` representing the path to the text file to be processed.

2. **Read Method**:
   - The `Read` method is responsible for reading the text file at the specified `path` and calculating the frequency of each character.
   - It uses a `foreach` loop to iterate through each line in the text file (obtained using `File.ReadAllLines(path)`).
   - For each line, it converts the line into an array of characters using `line.ToCharArray()`.
   - Then, for each character (`variable`) in the array:
     - It checks if the character is already a key in the `storeElements` dictionary.
     - If the character is present, it increments its corresponding frequency value by 1.
     - If the character is not present, it adds the character to the dictionary with a frequency of 1.
   - The method repeats this process for all lines in the text file, resulting in an updated `storeElements` dictionary with character frequencies.
   
3. The method returns the `storeElements` dictionary, which now contains the frequencies of characters from the text file.

In summary, the `FreqReader` class provides functionality to read a text file, analyze its content, and calculate the frequency of characters present in the file. This can be useful for various applications, including building Huffman trees for compression algorithms.

*/

public class FreqReader
{
    public Dictionary<char, int> Read(Dictionary<char, int> storeElements,  string path)
    {
        foreach (var line in File.ReadAllLines(path))
        {
            var elements = line.ToCharArray();
            foreach (var variable in elements)
            {
                if (storeElements.ContainsKey(variable))
                {
                    storeElements[variable] += 1;
                }
                else
                {
                    storeElements.Add(variable, 1);
                }
            }
        }
        
        return storeElements;
    } 
}
