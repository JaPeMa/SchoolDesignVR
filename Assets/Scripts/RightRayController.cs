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
    public GameObject table;
    public GameObject rightHand;
    private GameObject collisioningObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == menuItemTag && !visible)
        {
            changeVisibility();
        }
        Debug.Log(other.gameObject.tag);
        collisioningObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == menuItemTag && visible)
        {
            changeVisibility();
        }
        collisioningObject = null;
    }

    private void changeVisibility()
    {
        visible = !visible;
        GetComponent<Renderer>().sharedMaterial = visible ? visibleTexture : invisibleTexture;
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions.default_GrabPinch.state) {
            if (visible)
            {
                Destroy(teleportingObject);
                SceneManager.LoadScene("Instituto");
            }

            if (collisioningObject != null && collisioningObject.tag == "createTable")
            {                
                Instantiate(table, new Vector3(rightHand.transform.position.x, rightHand.transform.position.y, rightHand.transform.position.z), Quaternion.identity);
            }
        }
    }
}
