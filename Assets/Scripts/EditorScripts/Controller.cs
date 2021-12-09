using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Node;
    public static List<GameObject> CurrentNode = new List<GameObject>(); 
    public static List<GameObject> Nodes = new List<GameObject>(); 
    public static bool placingNode = false;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
       sr = Node.GetComponent<SpriteRenderer>();
       
    }
 

    // clear all nodes
    public void ClearNodes()
    {
       
        foreach (GameObject node in Nodes)
        {
            Destroy(node);
        }
       
        // add all the current items this way they are not left over and you can select when you want to protect from clear
        foreach (GameObject node in CurrentNode)
        {
            Nodes.Add(node);
        }
        Nodes.Clear();
        
    }

    public void Trash(){
        //remove selected nodes
        foreach (GameObject node in CurrentNode)
        {
            Nodes.Remove(node);
            CurrentNode.Remove(node);
            Destroy(node);
        }
        
    }

    public void AddNode(){
        placingNode = !placingNode;
    }

    // Update is called once per frame
    void Update()
    {
        // if unity mouse over UI   

        
        //if space is pressed set plaicing node to it's inverse 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("space pressed");
            placingNode = !placingNode;
        }

        if(placingNode){
        
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // sprite render of the node to show where it would be placed with alpha 0.5
            //SpriteRenderer sr = Node.GetComponent<SpriteRenderer>();
            sr.color = new Color(1,1,1,0.3f);
            sr.sortingOrder = 4;
            sr.transform.position = mousePos;
            
            // on click add a node to the mouse position
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked");
                // make sure the nearest node is les than 3f away from the mouse position 
                GameObject nearestNode = null;
                float distance = Mathf.Infinity;
                //Vector3.Distance(Nodes.IndexOf(0).transform.position, mousePos);
                foreach (GameObject node in Nodes)
                {
                    Debug.Log("Item");
                    float dist = Vector3.Distance(node.transform.position, mousePos);
                    if (dist < distance)
                    {
                        nearestNode = node;
                        distance = dist;
                        Debug.Log("Nearest node is " + nearestNode.name + " at " + distance);
                    }
                }
                //distance = Vector3.Distance(nearestNode.transform.position, mousePos);
                if(distance > 4f){
                    Debug.Log("Allowed");
                    GameObject newNode = Instantiate(Node, mousePos, Quaternion.identity);
                    sr.enabled = false;
                    Nodes.Add(newNode);
                }
            }
        }
        
    }


}
