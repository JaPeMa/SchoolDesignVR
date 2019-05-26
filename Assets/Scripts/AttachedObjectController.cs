using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class AttachedObjectController : MonoBehaviour
{
    public void tryToBeInTheFloor(GameObject objectDeattached)
    {
        Vector3 position = objectDeattached.transform.position;
        position.y = 0f;
        objectDeattached.transform.position = position;

        Quaternion rotation = objectDeattached.transform.rotation;
        rotation.x = 0f;
        rotation.z = 0f;
        objectDeattached.transform.rotation = rotation;
    }
}
