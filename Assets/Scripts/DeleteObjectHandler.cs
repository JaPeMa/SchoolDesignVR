using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DeleteObjectHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Hand>().currentAttachedObject != null && SteamVR_Actions.default_GrabGrip.state)
        {
            Destroy(gameObject.GetComponent<Hand>().currentAttachedObject);
        }
    }
}
