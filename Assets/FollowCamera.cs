using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform thingToFollow;
    [SerializeField] private Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);

    void Update()
    {
        transform.position = thingToFollow.position + offset;
    }
}
