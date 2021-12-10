using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GraphNode : MonoBehaviour
{
    public static string lastvalue = "A";
    public string value;
    public List<Edge> edges = new List<Edge>();
    public TextMeshProUGUI valueLable;
    public GameObject Highlight;

    bool selected,held = false;

    void Start()
    {
        value= lastvalue + 1;
        lastvalue = value;
    }

    // Update is called once per frame
    void Update()
    {
        valueLable.text = value;

        //what if they drag to close to anouther node?
        if(held){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            gameObject.transform.position = mousePos;
        }
    }


    private void OnMouseOver()
    {
       // Debug.Log("Mouse is over " + gameObject.name);
        if (!Controller.placingNode)
        {
            Highlight.SetActive(true);
        }
    }
    
    private void OnMouseExit()
    {
        Debug.Log("Mouse is no longer over " + gameObject.name);
        if (!Controller.placingNode && !selected)
        {
            Highlight.SetActive(false);
        }

    }

    //move mosue up
    private void OnMouseUp()
    {
       held =false;
    }

    private void OnMouseDown()
    {
        Debug.Log("CLICK  " + gameObject.name);
        if (!Controller.placingNode)
        {
            selected = !selected;
            if(selected){    
                Controller.CurrentNode.Remove(gameObject);
            }else{
                held = true;
                Controller.CurrentNode.Add(gameObject);
            }
            Highlight.SetActive(!Highlight.activeSelf);
        }
    }


}
