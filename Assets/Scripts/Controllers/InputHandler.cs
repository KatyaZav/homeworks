using UnityEngine;

public class InputHandler
{
    public float GetHorizontalInput() => Input.GetAxisRaw("Horizontal");
    public float GetVerticalInput() => Input.GetAxisRaw("Vertical");
    public bool GetShootKeyDown() =>Input.GetKeyDown(KeyCode.Space);
}
