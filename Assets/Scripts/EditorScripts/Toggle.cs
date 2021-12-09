using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject Target;
    public void onclick()
    {
        Target.SetActive(!Target.activeSelf);
    }


}
