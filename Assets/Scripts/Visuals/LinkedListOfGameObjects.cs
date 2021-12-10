using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LinkedListOfGameObjects : MonoBehaviour
{
    private CustomLinkedList<GameObject> _linkedList;
    private Queue<Actions> _pointerPositions;
    public GameObject prefab;
    public GameObject pointer;
    private GameObject head;
    private Vector3 spawnPos;
    public Text textBox;
    private float offset = 1.5f;
    
    private GameObject nullNode;
    
    // Start is called before the first frame update
    void Start()
    {
        nullNode = Instantiate(prefab);
        nullNode.name = "nullNode";
        GetNodeText(nullNode).text = "null";
        
        head = Instantiate(prefab);
        head.name = "headNode";
        GetNodeText(head).text = "head";
        head.transform.position = spawnPos + Vector3.up;
        spawnPos = Vector3.zero;
        _linkedList = new CustomLinkedList<GameObject>();
        AddNumOfNodes(5);
        _pointerPositions = _linkedList.ShowAddNode();
        UpdateLines();
        DequeueAddNode();
    }

    public void DequeueAddNode()
    {
        var pos = _pointerPositions.Dequeue();
        switch (pos)
        {
                case Actions.Head:
                {
                    GetNodeText(head).color = Color.green;
                    if (_linkedList.Head == null)
                    {
                        nullNode.transform.position = spawnPos;
                        PointToNode(nullNode);
                        break;
                    }
                    PointToNode(_linkedList.Head.Data);
                    _linkedList.Current = _linkedList.Head;
                    break;
                }
                case Actions.Next:
                    GetNodeLine(_linkedList.Current.Data).colorGradient = GetSolidGradient(Color.white);
                    _linkedList.Current = _linkedList.Current.Next;
                    PointToNode(_linkedList.Current.Data);
                    break;
                case Actions.Add:
                    _linkedList.AddNode(CreateNewNode(_linkedList.Length + 1));
                    UpdateLines();
                    break;
                case Actions.CheckNextNull:
                    GetNodeLine(_linkedList.Current.Data).colorGradient = GetSolidGradient(Color.white);
                    var next = _linkedList.Current;
                    if(next != null) GetNodeLine(next.Data).colorGradient = GetSolidGradient(Color.yellow);
                    else
                    {
                       GetNodeLine(nullNode).colorGradient = GetSolidGradient(Color.yellow);
                    }
                    break;
                case Actions.WasNull:
                    GetNodeLine(_linkedList.Current.Data).colorGradient = GetSolidGradient(Color.red);
                    PointToNode(nullNode);
                    break;
                case Actions.WasNotNull:
                    GetNodeLine(_linkedList.Current.Data).colorGradient = GetSolidGradient(Color.green);
                    break;
                case Actions.CheckNull:
                    break;
        }
        textBox.text = pos.ToString();
    }

    private void AddNumOfNodes(int num)
    {
        for (int i = 0; i < num; i++)
        {
            var temp = CreateNewNode(i);
            _linkedList.AddNode(temp);
        }
    }

    private CustomNode<GameObject> CreateNewNode(int num)
    {
        var temp = Instantiate(prefab, spawnPos = Vector3.right * num * offset, Quaternion.identity);
        GetNodeText(temp).text = num.ToString();
        nullNode.transform.position = temp.transform.position + Vector3.right * offset;
        return new CustomNode<GameObject>(temp);
    }
    
    private Gradient GetSolidGradient(Color color)
    {
        var alpha = 1f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new [] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
            new [] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        return gradient;
    }

    private void PointToNode(GameObject node)
    {
        pointer.transform.position = node.transform.position + Vector3.down;
    }

    private TMP_Text GetNodeText(GameObject node)
    {
        return node.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
    }

    private LineRenderer GetNodeLine(GameObject node)
    {
        return node.transform.GetChild(1).GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLines();
    }
    
    private void UpdateLines()
    {
        if (_linkedList.Head == null) return;
        var TempCurrent = _linkedList.Head;
        for (int i = 0; i < _linkedList.Length; i++)
        {
            GetNodeLine(TempCurrent.Data).SetPosition(0,TempCurrent.Data.transform.position);
            GetNodeLine(TempCurrent.Data).SetPosition(1,TempCurrent.Next.Data.transform.position);
            TempCurrent = TempCurrent.Next;
        }
        GetNodeLine(TempCurrent.Data).SetPosition(0,TempCurrent.Data.transform.position);
        GetNodeLine(TempCurrent.Data).SetPosition(1,nullNode.transform.position);
    }

}
