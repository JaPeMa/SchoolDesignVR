using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PuertaReturn : MonoBehaviour
{
    public Animator animat;
    private GameObject teleportingObject;
    public void openDoor(GameObject _teleportingObject)
    {
        animat.SetBool("returnLobby", true);
        teleportingObject = _teleportingObject;
    }

    public void goLobby()
    {
        Destroy(teleportingObject);
        SceneManager.LoadScene(gameObject.GetComponent<ItemToNavigate>().goTo);
    }
}
