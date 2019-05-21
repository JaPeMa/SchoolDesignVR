using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftHandController : MonoBehaviour
{

    private bool opened = false;
    private bool canPress = true;
    public GameObject menu;
    GameObject menuObject;

    void Update()
    {
        if (checkIfCanOpenButton())
        {
            Debug.Log("Create");
            
            opened = true;
            canPress = false;
            menuObject = Instantiate(menu) as GameObject;
            Vector3 handPosition = gameObject.transform.position;
            Quaternion handRotation = gameObject.transform.rotation;

            gameObject.transform.position = new Vector3();
            gameObject.transform.rotation = new Quaternion();

            menuObject.transform.parent = gameObject.transform;
            menuObject.transform.position = new Vector3(gameObject.transform.position.x - 0.0031f,
                                                        gameObject.transform.position.y + 0.207f,
                                                        gameObject.transform.position.z + 0.019f);

            gameObject.transform.position = handPosition;
            gameObject.transform.rotation = handRotation;
        }
        else if (checkIfCanCloseButton())
        {
            Debug.Log("Close");
            opened = false;
            canPress = false;
            Destroy(menuObject);
        }

        isKeyReleased();
    }

    private bool checkIfCanOpenButton()
    {
        return SteamVR_Actions.default_OpenMenu.state && !opened && canPress;
    }

    private bool checkIfCanCloseButton()
    {
        return SteamVR_Actions.default_OpenMenu.state && opened && canPress;
    }

    private void isKeyReleased()
    {
        if (!SteamVR_Actions.default_OpenMenu.state && !canPress)
        {
            Debug.Log("Release");
            canPress = true;
        }
    }
}
