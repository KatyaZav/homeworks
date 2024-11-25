using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;

    void Start()
    {
        _spawner.Init();
    }
}
