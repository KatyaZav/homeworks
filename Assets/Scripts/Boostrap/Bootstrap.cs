using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _scripts;
    private IInitable[] _initables;

    private void Start()
    {
        foreach (var e in _scripts)
        {
            var initComponent = e.GetComponent<IInitable>();

            if (initComponent != null)
            {
                initComponent.Init();
            }
            else
            {
                Debug.LogError($"Not founded IInitable in {e}");
            }
        }
    }
}
