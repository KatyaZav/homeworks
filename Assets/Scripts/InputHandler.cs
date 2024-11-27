using UnityEngine;

public class InputHandler
{
    private const KeyCode AddKey = KeyCode.RightArrow;
    private const KeyCode RemoveKey = KeyCode.LeftArrow;
    private const KeyCode ChoseNextKey = KeyCode.UpArrow;
    private const KeyCode ChosePreviousKey = KeyCode.DownArrow;

    public bool GetAddKeyDown => Input.GetKeyDown(AddKey);
    public bool GetRemoveKeyDown => Input.GetKeyDown(RemoveKey);
    public bool GetNextKeyDown => Input.GetKeyDown(ChoseNextKey);
    public bool GetPreviousKeyDown => Input.GetKeyDown(ChosePreviousKey);
}
