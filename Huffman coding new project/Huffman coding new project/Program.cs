using System;
using System.Text;

string path = "C:/Users/1/RiderProjects/Huffman-coding-new-project-repository/Huffman coding new project/Huffman coding new project/sherlock.txt";
Encoding encoding = Encoding.UTF8; // кодуємо файл

Dictionary<char, int> charFrequency = null; // ініціалізуємо як null

using (StreamReader reader = new StreamReader(path, encoding))
{
    string text = reader.ReadToEnd();

    charFrequency = new Dictionary<char, int>(); // словник, якщо не є null

    foreach (char c in text)
    {
        if (charFrequency.ContainsKey(c))
        {
            charFrequency[c]++;
        }
        else
        {
            charFrequency[c] = 1;
        }
    }
}

if (charFrequency != null) // перевірка, що змінна не є null
{
    foreach (KeyValuePair<char, int> pair in charFrequency)
    {
        Console.WriteLine("Symbol '{0}' occurs {1} times", pair.Key, pair.Value);
    }
}