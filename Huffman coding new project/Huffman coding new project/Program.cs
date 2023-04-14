
using Huffman_coding_new_project;
using TextReader = Huffman_coding_new_project.TextReader;
var freqReader = new FreqReader();
var elementsFreq = freqReader.Read(new Dictionary<char, int>(), @"C:\Users\Admin\RiderProjects\SAMPLE 4\SAMPLE 4\text.txt");

var freqQueue = new PriorityQueue<Node, int>();
ToQueue();
var textReader = new TextReader();

// ---------ЗМІНИ (абсолютний) ШЛЯХ ФАЙЛУ----------
var text = textReader.Read("", @"C:\Users\Admin\RiderProjects\SAMPLE 4\SAMPLE 4\text.txt");
var treeBuilder = new TreeBuilder();
freqQueue = treeBuilder.Builder(freqQueue);
var huffmanTable = new Dictionary<string, string>();
var encoder = new Encoder();
encoder.Encode(freqQueue.Peek(), "", huffmanTable);
encoder.PrintCodedElements(huffmanTable);

var codedFile = new List<string>();

ConvertToHuffmanCode(text);

var decoder = new Decoder();
var file = decoder.DecodeFile(freqQueue.Peek(), codedFile);

PrintHuffmanCodedFile();

WriteHuffmanCodedFile();

Console.WriteLine(file);

void ToQueue()
{
    foreach (var j in elementsFreq)
    {
        freqQueue.Enqueue(new Node(j.Key.ToString(), j.Value, null, null), j.Value);
    }
}

void ConvertToHuffmanCode(string words)
{
    foreach (var letter in words)
    {
        codedFile.Add(huffmanTable[letter.ToString()]);
    }
}

void PrintHuffmanCodedFile()
{
    foreach (var element in codedFile)
    {
        Console.Write(element);
    }
}

void WriteHuffmanCodedFile()
{
    // ---------ЗМІНИ (абсолютний) ШЛЯХ ФАЙЛУ----------
    using StreamWriter writer = new StreamWriter(@"C:\Users\Admin\RiderProjects\Huffman coding new project\Huffman-coding-new-project-repository\Huffman coding new project\Huffman coding new project\CodedFile.txt");
    foreach (var element in codedFile)
    {
        writer.Write(element);
    }
}    