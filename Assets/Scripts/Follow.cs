using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _chased;
    [SerializeField] private Vector3 _offset;

    void Update()
    {
        transform.position = _chased.transform.position + _offset;
    }
}
