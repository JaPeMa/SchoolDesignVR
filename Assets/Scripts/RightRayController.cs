using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class RightRayController : MonoBehaviour
{
    private string menuItemTag = "INTERACTABLE";
    public Material visibleTexture;
    public Material invisibleTexture;
    private bool visible = false;
    public GameObject teleportingObject;

    private void OnTriggerEnter(Collider other)
    {
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
        if (SteamVR_Actions.default_GrabPinch.state && visible) {
            Destroy(teleportingObject);
            SceneManager.LoadScene("Instituto");
        }
    }
}
