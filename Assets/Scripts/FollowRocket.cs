using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRocket : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        if(target != null)
        {
            transform.position = new Vector3(transform.position.x, target.position.y + 2.6f, target.position.z);
        }
        
    }
}
