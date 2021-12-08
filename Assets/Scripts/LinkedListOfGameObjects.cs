using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LinkedListOfGameObjects : MonoBehaviour
{
    private CustomLinkedList<GameObject> _linkedList;
    private Queue<int> _pointerPositions;
    public GameObject prefab;
    public GameObject pointer;
    private Vector3 spawnPos;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = Vector3.zero;
        
        _linkedList = new CustomLinkedList<GameObject>();
        addNumOfNodes(prefab, 10);

         DequeueAddNode();
    }

    public void DequeueAddNode()
    {
        var pos = _pointerPositions.Dequeue();
        textBox.text = pos.ToString();
        pointer.transform.position = Vector3.right * pos;
        pointer.transform.position += Vector3.down;
    }

    private void addNumOfNodes(GameObject _prefab, int num)
    {
        for (int i = 0; i < num; i++)
        {
            var temp = Instantiate(_prefab, spawnPos += Vector3.right, Quaternion.identity);
            temp.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = i.ToString();
            _linkedList.AddNode(new CustomNode<GameObject>(temp));
        }
        var final = Instantiate(_prefab, spawnPos += Vector3.right, Quaternion.identity);
        final.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = num.ToString();
        _pointerPositions = _linkedList.ShowAddNode(new CustomNode<GameObject>(Instantiate(prefab, spawnPos += Vector3.right, Quaternion.identity)));
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
