using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 _offset;
    private float smoothTime = 0.9F;
    [SerializeField] private GameObject _followMe;


    void Start()
    {
       _offset = transform.position - _followMe.transform.position;

    }

    void LateUpdate()
    {
        transform.position = _followMe.transform.position + _offset;
    }
}
