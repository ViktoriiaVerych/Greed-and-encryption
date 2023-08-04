namespace Huffman_coding_new_project;

/*
The TreeBuilder class is responsible for constructing a Huffman tree using a priority queue.
The Builder method takes a PriorityQueue<Node, int> named heap as input, which presumably contains nodes with their respective frequencies.
Inside a loop, the method repeatedly combines the two nodes with the lowest frequencies from the heap to build the Huffman tree.

**For each iteration:**
- It dequeues (removes) the two nodes with the lowest frequencies from the heap.
- It creates a new Node that represents the combined frequency and value of the two nodes.
- The new node's left child is the first dequeued node, and the right child is the second dequeued node.
- The new node is enqueued (added back) into the heap with a frequency equal to the sum of the frequencies of the two nodes.

This process continues until only one node remains in the heap, which represents the root of the Huffman tree.
The method returns the modified heap, which now holds the Huffman tree structure.

Overall, the TreeBuilder class takes advantage of the priority queue to iteratively build a Huffman tree by combining nodes with the lowest frequencies. This tree structure is crucial for generating Huffman codes during encoding and decoding processes.
*/
public class TreeBuilder
{
    public PriorityQueue<Node, int> Builder(PriorityQueue<Node, int> heap)
    {
        
        while (heap.Count != 1)
        {
            var first = heap.Dequeue();
            var second = heap.Dequeue();
            var toAdd = new Node(first.Value + second.Value, first.Frequency + second.Frequency, first, second);
            heap.Enqueue(toAdd, first.Frequency + second.Frequency);
        }

        return heap;
    }
}
