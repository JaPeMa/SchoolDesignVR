using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectHandler : MonoBehaviour
{

    private GameObject objectColliding;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void assign(GameObject objectToAssign)
    {
        objectColliding = objectToAssign;
    }
}
