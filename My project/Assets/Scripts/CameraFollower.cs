using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject _toFollow;

    // Update is called once per frame
    void Update()
    {
        Vector3 followPosition = _toFollow.transform.position;
        followPosition.z = transform.position.z;
        transform.position = followPosition;
    }
}
