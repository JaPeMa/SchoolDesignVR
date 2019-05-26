using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;


public class RightRayController : HandObjectsBasicHandler
{

    public GameObject teleportingObject;
    public GameObject player;

    public override void DoWhatever()
    {
        if (CheckConditionToDo())
        {
            
            if(collisioningObject.GetComponent<MoveToScript>() != null)
            {
                player.transform.position = collisioningObject.GetComponent<MoveToScript>().whereToGo;
            }
            else if (collisioningObject.GetComponent<PuertaReturn>() != null)
            {
                collisioningObject.GetComponent<PuertaReturn>().openDoor(teleportingObject);
            }
            else
            {
                Destroy(teleportingObject);
                SceneManager.LoadScene(collisioningObject.GetComponent<ItemToNavigate>().goTo);
            }
        }
    }

    public bool CheckConditionToDo()
    {
        return SteamVR_Actions.default_InteractUI.state && visible && gameObject.transform.parent.GetComponent<Hand>().currentAttachedObject == null;
    }

}
