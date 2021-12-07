
public class CustomLinkedList<T>
{
    //start of the linked list
    private CustomNode<T> _head;
    
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



}
