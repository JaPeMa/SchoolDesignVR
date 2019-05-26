using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToScript : MonoBehaviour
{

    public Vector3 whereToGo;

    void Start()
    {
        whereToGo = new Vector3(-6.45f, 10.16f, 2.741f);
    }
}
