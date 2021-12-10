using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    bool selected,held = false;
    
    void Update()
    {

        //what if they drag to close to another node?
        if(held){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            gameObject.transform.position = mousePos;
        }
    }

    //move mouse up
    private void OnMouseUp()
    {
        held =false;
    }

    public void OnClick()
    {
        selected = !selected;
        held = !held;
    }
}
