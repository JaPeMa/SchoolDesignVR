using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightBallController : HandObjectsBasicHandler
{

    public GameObject vrCamera;
    public GameObject objectPosition;
    public GameObject leftHand;

    public override void DoWhatever()
    {
        if (CheckConditionToDo())
        {

            Component objectToCreate = collisioningObject.GetComponent<ObjectToCreate>();
            Component menuToOpen = collisioningObject.GetComponent<OpenMenu>();
            if (objectToCreate != null)
            {
                GameObject objectCreated = collisioningObject.GetComponent<ObjectToCreate>().objectToCreate;
                Vector3 position = new Vector3(objectPosition.transform.position.x, 0f, objectPosition.transform.position.z);
                Quaternion rotation = new Quaternion();
                rotation.y = vrCamera.transform.parent.rotation.y - 180f;
                Instantiate(objectCreated, position, rotation);
                //scripter.GetComponent<AttachedObjectController>().tryToBeInTheFloor(objectCreated);
            }

            if (menuToOpen != null)
            {
                Destroy(leftHand.transform.Find("Menu").gameObject);
                leftHand.GetComponent<LeftHandController>().instantiateMenu(collisioningObject.GetComponent<OpenMenu>().menuToOpen);
            }
            
            objectGenerated = true;
        }
        if (objectGenerated && !SteamVR_Actions.default_GrabPinch.state)
        {
            objectGenerated = false;
        }
    }

    public bool CheckConditionToDo()
    {
        return SteamVR_Actions.default_GrabPinch.state && visible && !objectGenerated;
    }
}
