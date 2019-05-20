using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftHandController : MonoBehaviour
{

    private bool opened = false;
    public GameObject menu;

    void Start()
    {
        menu.transform.parent = gameObject.transform;
    }

    void Update()
    {
        if (checkIfMenuButtonChecked())
        {
            opened = true;
            Instantiate(menu);
        }
    }

    private bool checkIfMenuButtonChecked()
    {
        return SteamVR_Actions.default_OpenMenu.state && !opened;
        //return false;
    }
}
