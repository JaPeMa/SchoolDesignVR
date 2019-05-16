using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandObjectsBasicHandler : MonoBehaviour
{
    public string tagRequired;
    public Material visibleTexture;
    public Material invisibleTexture;
    protected GameObject collisioningObject;
    private bool visible = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagRequired && !visible)
        {
            changeVisibility();
            collisioningObject = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == tagRequired && visible)
        {
            changeVisibility();
            collisioningObject = null;
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
        DoWhatever();
    }

    public abstract void DoWhatever();

}
