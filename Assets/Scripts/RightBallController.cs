using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class RightBallController : HandObjectsBasicHandler
{
    public override void DoWhatever()
    {
        if (CheckConditionToDo())
        {
            Instantiate(collisioningObject.GetComponent<ObjectToCreate>().objectToCreate, 
                new Vector3(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y, gameObject.transform.parent.position.z), 
                new Quaternion());
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
