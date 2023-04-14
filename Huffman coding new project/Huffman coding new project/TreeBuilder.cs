namespace Huffman_coding_new_project;

public class TreeBuilder
{
    public PriorityQueue<Node, int> Builder(PriorityQueue<Node, int> heap)
    {
        // будуємо дерево з комбінуванням двох низько-частотних нод
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