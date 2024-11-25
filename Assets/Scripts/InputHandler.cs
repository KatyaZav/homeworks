using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float GetHorizontalInput() => Input.GetAxisRaw("Horizontal");
    public float GetVerticalInput() => Input.GetAxisRaw("Vertical");
}
