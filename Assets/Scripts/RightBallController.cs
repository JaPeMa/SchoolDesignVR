using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightBallController : HandObjectsBasicHandler
{

    public GameObject leftHand;

    public override void DoWhatever()
    {
        if (CheckConditionToDo())
        {

            Component objectToCreate = collisioningObject.GetComponent<ObjectToCreate>();
            Component menuToOpen = collisioningObject.GetComponent<OpenMenu>();
            if (objectToCreate != null)
            {
                GameObject objectCreated = Instantiate(collisioningObject.GetComponent<ObjectToCreate>().objectToCreate, 
                            new Vector3(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y, gameObject.transform.parent.position.z), 
                            new Quaternion()) as GameObject;
                GetComponent<AttachedObjectController>().tryToBeInTheFloor(objectCreated);
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
