
using Huffman_coding_new_project;
// string path = "C:/Users/1/RiderProjects/Huffman-coding-new-project-repository/Huffman coding new project/Huffman coding new project/sherlock.txt";
// Encoding encoding = Encoding.UTF8; // кодуємо файл
//
// Dictionary<char, int> charFrequency = null; // ініціалізуємо як null
//
// using (StreamReader reader = new StreamReader(path, encoding))
// {
//     string text = reader.ReadToEnd();
//
//     charFrequency = new Dictionary<char, int>(); // словник, якщо не є null
//
//     foreach (char c in text)
//     {
//         if (charFrequency.ContainsKey(c))
//         {
//             charFrequency[c]++;
//         }
//         else
//         {
//             charFrequency[c] = 1;
//         }
//     }
// }
//
// if (charFrequency != null) // перевірка, що змінна не є null
// {
//     foreach (KeyValuePair<char, int> pair in charFrequency)
//     {
//         Console.WriteLine("Symbol '{0}' occurs {1} times", pair.Key, pair.Value);
//     }
// }
//

//-------------------------------------------------

var elementsFreq = new Dictionary<char, int>();
var elementsCode = new Dictionary<string, string>();
var heap = new Heap();
var codedFile = new List<string>();
var decodedFile = "";
var text = "";

FreqReader(elementsFreq, @"C:\Users\Admin\RiderProjects\Huffman coding new project\Huffman-coding-new-project-repository\Huffman coding new project\Huffman coding new project\text.txt");
TextReader(@"C:\Users\Admin\RiderProjects\Huffman coding new project\Huffman-coding-new-project-repository\Huffman coding new project\Huffman coding new project\text.txt");

TreeBuilder();
var rootNode = heap.GetMin();
Encode(rootNode, "", elementsCode);

CodedElementsPrinter(elementsCode);

ConvertToHuffmanCode(text);

HuffmanCodedFilePrinter();

HuffmanCodedFileWriter();

DecodeFile(rootNode, codedFile);

Console.WriteLine();
Console.WriteLine(decodedFile);

void TreeBuilder()
{
    foreach (var keyValue in elementsFreq)
    {
        //створює нову ноду для пари 
        heap.Add(new Node(keyValue.Key.ToString(), keyValue.Value, null, null));
    }
    // будуємо дерево з комбінуванням двох низько-частотних нод
    while (heap.Count() != 1)
    {
        var first = heap.TopItem();
        var second = heap.TopItem();
        var toAdd = new Node(first.Value + second.Value, first.Frequency + second.Frequency, first, second);
        heap.Add(toAdd);
        
    }
}
//зчитувач частот, створює таблицю для відстежування кожного символу
void FreqReader(Dictionary<char, int> storeElements,  string path)
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
}

void TextReader(string path)
{
    foreach (var line in File.ReadLines(path))
    {
        text += line;
    }    
}


void Encode(Node root, string str, Dictionary<string, string> huffmanCode)
{
    if (root == null)
    {
        return;
        
    }
    if (IsLeaf(root))
    {
        huffmanCode.Add(root.Value, str);
    }
    //рекурсивний виклик, left child = 0, right child = 1
    Encode(root.Left, str + "0", huffmanCode);
    Encode(root.Right, str + "1", huffmanCode);
}

bool IsLeaf(Node node)
{
    if (node.Left == null && node.Right == null)
    {
        return true;
    }

    return false;
}

void CodedElementsPrinter(Dictionary<string, string> elements)
{
    foreach (var element in elements)
    {
        
        Console.Write(element.Key);
        Console.Write(" || ");
        Console.WriteLine(element.Value);
    }
}


void ConvertToHuffmanCode(string words)
{
    foreach (var letter in words)
    {
        codedFile.Add(elementsCode[letter.ToString()]);
    }
}

void HuffmanCodedFilePrinter()
{
    foreach (var element in codedFile)
    {
        Console.Write(element);
    }
}


void HuffmanCodedFileWriter()
{
    using StreamWriter writer = new StreamWriter(@"C:\Users\Admin\RiderProjects\Huffman coding new project\Huffman-coding-new-project-repository\Huffman coding new project\Huffman coding new project\CodedFile.txt");
    foreach (var element in codedFile)
    {
        writer.Write(element);
    }
}

void DecodeFile(Node root, List<string> codedText)
{
    string decodedFile = null;
    var current = root;
    var word = string.Join("", codedText);
    //Траверс на основі бітів в закодованому тексті
    foreach (var bit in word)
    {
        if (bit == '0')
        {
            current = current.Left;
        }
        else
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

}    