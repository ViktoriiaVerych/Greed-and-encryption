namespace Huffman_coding_new_project;

public class FreqReader
{
    //зчитувач частот, створює таблицю для відстежування кожного символу
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