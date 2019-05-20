using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;


public class RightRayController : HandObjectsBasicHandler
{

    public GameObject teleportingObject;

    public override void DoWhatever()
    {
        if (CheckConditionToDo())
        {
            Destroy(teleportingObject);
            SceneManager.LoadScene(collisioningObject.GetComponent<ItemToNavigate>().goTo);
        }
    }

    public bool CheckConditionToDo()
    {
        return SteamVR_Actions.default_InteractUI.state && visible && gameObject.transform.parent.GetComponent<Hand>().currentAttachedObject == null;
    }

}
