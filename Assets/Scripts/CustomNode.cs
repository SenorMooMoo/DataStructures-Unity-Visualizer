
public class CustomNode<T>
{
    private T _data;
    private CustomNode<T> _next;

    public CustomNode()
    {
        _data = default;
        _next = default;
    }

    public CustomNode(T data)
    {
        _data = data;
        _next = default;
    }

    public CustomNode(T data, CustomNode<T> next)
    {
        _data = data;
        _next = next;
    }

    public T Data
    {
        get => _data;
        set => _data = value;
    }

    public CustomNode<T> Next
    {
        get => _next;
        set => _next = value;
    }
}
