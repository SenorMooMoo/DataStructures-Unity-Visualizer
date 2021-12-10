
using System.Collections.Generic;

public class CustomLinkedList<T>
{
    //start of the linked list
    private CustomNode<T> _head;

    private int _length;
    
    //for showcasing the linked list 
    public CustomNode<T> Current;
    
    public CustomLinkedList()
    {
        _head = default;
        _length = 0;
    }

    public CustomNode<T> Head
    {
        get => _head;
        private set => _head = value;
    }

    public int Length
    {
        get => _length;
        private set => _length = value;
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
        _length++;
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

    public Queue<Actions> ShowAddNode()
    {
        var actions = new Queue<Actions>();
        actions.Enqueue(Actions.Head);
        actions.Enqueue(Actions.CheckNull);
        if (_head == default)
        {
            actions.Enqueue(Actions.WasNull);
            actions.Enqueue(Actions.Add);
            return actions;
        }
        actions.Enqueue(Actions.WasNotNull);
        CustomNode<T> currentNode = _head;
        actions.Enqueue(Actions.CheckNextNull);
        while (currentNode.Next != default)
        {
            actions.Enqueue(Actions.WasNotNull);
            actions.Enqueue(Actions.Next);
            currentNode = currentNode.Next;
            actions.Enqueue(Actions.CheckNextNull);
        }
        actions.Enqueue(Actions.WasNull);
        actions.Enqueue(Actions.Add);
        return actions;
    }

}
