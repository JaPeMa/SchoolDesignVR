using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightRayController : MonoBehaviour
{
    private string menuItemTag = "INTERACTABLE";
    public Material visibleTexture;
    public Material invisibleTexture;
    private bool visible = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == menuItemTag && !visible)
        {
            changeVisibility();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == menuItemTag && visible)
        {
            changeVisibility();
        }
    }

    private void changeVisibility()
    {
        visible = !visible;
        GetComponent<Renderer>().sharedMaterial = visible ? visibleTexture : invisibleTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
