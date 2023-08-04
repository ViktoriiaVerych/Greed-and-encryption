
/*

1. **Reading and Calculating Frequencies**:
   - The program first imports necessary classes from the `Huffman_coding_new_project` namespace.
   - It initializes a `FreqReader` to read a text file and calculate the frequency of each character in the text.
   - The `Read` method of `FreqReader` is called to populate `elementsFreq`, which is a dictionary containing character frequencies.

2. **Building Priority Queue**:
   - A priority queue (`PriorityQueue<Node, int>`) is initialized to hold nodes with their frequencies.
   - The `ToQueue` method enqueues each character-frequency pair from `elementsFreq` into the priority queue as `Node` instances.

3. **Building Huffman Tree**:
   - A `TextReader` instance is created to read the text from the file.
   - The text is read using the `Read` method of `TextReader`.
   - A `TreeBuilder` instance is created to build the Huffman tree using the priority queue.
   - The `Builder` method of `TreeBuilder` is called, modifying the `freqQueue`.

4. **Encoding and Printing Huffman Codes**:
   - A dictionary `huffmanTable` is created to store characters and their Huffman codes.
   - An `Encoder` instance is created to encode characters using Huffman codes.
   - The `Encode` method of `Encoder` is called to populate the `huffmanTable` with codes.
   - The `PrintCodedElements` method of `Encoder` is called to print the generated Huffman codes.

5. **Converting to Huffman Code**:
   - The program initializes a list `codedFile` to store the Huffman codes for the entire text.
   - The `ConvertToHuffmanCode` method is called to convert each character in the text to its corresponding Huffman code and add it to `codedFile`.

6. **Decoding and Output**:
   - A `Decoder` instance is created to decode the Huffman-encoded data.
   - The `DecodeFile` method of `Decoder` is called to decode `codedFile` and retrieve the original text.
   - The decoded text is stored in the variable `file`.

7. **Printing and Writing Huffman Codes**:
   - The program prints the Huffman-coded content of `codedFile` using the `PrintHuffmanCodedFile` method.
   - The `WriteHuffmanCodedFile` method is called to write the Huffman-coded content to a file named "CodedFile.txt".

8. **Final Output**:
   - The decoded text (`file`) is printed to the console using `Console.WriteLine`.

This program performs encoding (compression) of text data using Huffman coding, then decodes (decompresses) the encoded data and provides both the original and decoded text. It also generates a file containing the Huffman-coded data.
*/



using Huffman_coding_new_project;
using TextReader = Huffman_coding_new_project.TextReader;
var freqReader = new FreqReader();
var elementsFreq = freqReader.Read(new Dictionary<char, int>(), @"C:\Users\Admin\RiderProjects\SAMPLE 4\SAMPLE 4\text.txt");

var freqQueue = new PriorityQueue<Node, int>();
ToQueue();
var textReader = new TextReader();


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

    using StreamWriter writer = new StreamWriter(@"C:\Users\Admin\RiderProjects\Huffman coding new project\Huffman-coding-new-project-repository\Huffman coding new project\Huffman coding new project\CodedFile.txt");
    foreach (var element in codedFile)
    {
        writer.Write(element);
    }
}    
