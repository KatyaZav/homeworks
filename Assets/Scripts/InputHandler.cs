using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float GetHorizontalInput() => Input.GetAxis("Horizontal");
    public float GetVerticalInput() => Input.GetAxis("Vertical");
}
