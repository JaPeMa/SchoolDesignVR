using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftHandController : MonoBehaviour
{
    void Update()
    {
        if (checkIfMenuButtonChecked())
        {

        }
    }

    private bool checkIfMenuButtonChecked()
    {
        //return SteamVR_Actions.---boton_menu---.state;
        return false;
    }
}
