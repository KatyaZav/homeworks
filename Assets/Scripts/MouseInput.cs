using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private const int _leftMouse = 0;
    private const int _rightMouse = 1;

    [SerializeField] Explosion _exlode;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouse))
        {

        }

        if (Input.GetMouseButtonDown(_rightMouse))
        {
            Plane dragPlane = new Plane(Camera.main.transform.forward, transform.position);
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out var hit))
            { 
                Vector3 fingerPosition = hit.point;
                _exlode.Explode(fingerPosition);
            }
        }
    }
}
