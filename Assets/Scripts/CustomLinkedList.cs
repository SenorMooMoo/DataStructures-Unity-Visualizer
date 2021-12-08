
using System.Collections.Generic;

public class CustomLinkedList<T>
{
    //start of the linked list
    private CustomNode<T> _head;

    
    //for showcasing the linked list 
    public CustomNode<T> _Current;
    
    public CustomLinkedList()
    {
        _head = default;
    }

    public CustomNode<T> Head
    {
        get => _head;
        private set => _head = value;
    }

    //Add a node at the end of the list
    public void AddNode(CustomNode<T> node)
    {
        if (_head == default)
        {
            _head = node;
            return;
        }

        CustomNode<T> currentNode = _head;
        while (currentNode.Next != default)
        {
            currentNode = currentNode.Next;
        }

        currentNode.Next = node;
    }

    public CustomNode<T> At(int index)
    {
        if (_head == default) return default;
        var currentNode = _head;

        for (int i = 0; i < index; i++)
        {
            if (currentNode.Next == null) return default;
            currentNode = currentNode.Next;
        }

        return currentNode;

    }

    public Queue<int> ShowAddNode(CustomNode<T> node)
    {
        var pointerPositions = new Queue<int>();
        pointerPositions.Enqueue(0);
        if (_head == default)
        {
            _head = node;
            return pointerPositions;
        }

        int index = 1;
        CustomNode<T> currentNode = _head;
        while (currentNode.Next != default)
        {
            pointerPositions.Enqueue(index++);
            currentNode = currentNode.Next;
        }

        currentNode.Next = node;
        return pointerPositions;
    }

}
