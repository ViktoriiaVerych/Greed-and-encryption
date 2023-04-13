namespace Huffman_coding_new_project;

public class Heap
{
    public static int capacity = 10;
    private int heapSize;
    private Node[] elements = new Node[capacity];

    private int GetParentIndex(int childIndex)
    {
        return (childIndex - 1) / 2;
    }
    private int GetRightChildIndex(int parentIndex)
    {
        return parentIndex * 2 + 2;
    }

    private int GetLeftChildIndex(int parentIndex)
    {
        return parentIndex * 2 + 1;
    }
    private int GetParent(int childIndex)
    {
        return elements[GetParentIndex(childIndex)].Frequency;
    }
    private int GetRightChild(int parentIndex)
    {
        return elements[GetRightChildIndex(parentIndex)].Frequency;
    }

    private int GetLeftChild(int parentIndex)
    {
        return elements[GetLeftChildIndex(parentIndex)].Frequency;
    }

    private bool HasParent(int childIndex)
    {
        return GetParentIndex(childIndex) >= 0;
    }

    private bool HasRightChild(int parentIndex)
    {
        return GetRightChildIndex(parentIndex) < heapSize;
    }

    private bool HasLeftChild(int parentIndex)
    {
        return GetLeftChildIndex(parentIndex) < heapSize;
    }

    private void Change(int firstIndex, int secondIndex)
    {
        var first = elements[firstIndex];
        var second = elements[secondIndex];
        elements[firstIndex] = second;
        elements[secondIndex] = first;
    }

    private void IncreaseSize()
    {
        if (capacity == heapSize)
        {
            var newSize = capacity * 2;
            var increasedArray = new Node[newSize];
            for (int i = 0; i < elements.Length; i++)
            {
                increasedArray[i] = elements[i];
            }

            elements = increasedArray;
        }
    }

    private void HeapifyUp()
    {
        var childIndex = heapSize - 1;
        while (HasParent(childIndex) && GetParent(childIndex) > elements[childIndex].Frequency)
        {
            Change(GetParent(childIndex), childIndex);
            childIndex = GetParentIndex(childIndex);
        }
    }
    public void Add(Node item)
    {
        IncreaseSize();
        elements[heapSize] = item;
        heapSize++;
        HeapifyUp();
    }

    public Node GetMin()
    {
        if (heapSize > 0)
        {
            return elements[0];
        }

        throw new Exception("Empty Heap");
    }

    private void HeapifyDown()
    {
        var elementIndex = 0;
        while (HasLeftChild(elementIndex))
        {
            var smallChildIndex = GetLeftChildIndex(elementIndex);
            if (HasRightChild(elementIndex) && GetRightChild(elementIndex) < GetLeftChild(elementIndex))
            {
                smallChildIndex = GetRightChildIndex(elementIndex);
            }

            if (elements[elementIndex].Frequency < elements[smallChildIndex].Frequency)
            {
                break;
                
            }
            Change(elementIndex, smallChildIndex);
            elementIndex = smallChildIndex;
        }
    }

    public Node PollTopItem()
    {
        var topNode = elements[0];
        elements[0] = elements[heapSize - 1];
        heapSize--;
        HeapifyDown();
        return topNode;

    }

    public int Count()
    {
        return heapSize;
    }
}



