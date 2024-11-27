using UnityEngine;

public class InputHandler
{
    private const KeyCode AddKey = KeyCode.RightArrow;
    private const KeyCode RemoveKey = KeyCode.LeftArrow;
    private const KeyCode ChoseNextKey = KeyCode.UpArrow;
    private const KeyCode ChosePreviousKey = KeyCode.DownArrow;

    private const KeyCode StartTimerKey = KeyCode.RightShift;
    private const KeyCode StopTimerKey = KeyCode.Backspace;
    private const KeyCode PauseTimerKey = KeyCode.Space;
    
    public bool GetAddKeyDown => Input.GetKeyDown(AddKey);
    public bool GetRemoveKeyDown => Input.GetKeyDown(RemoveKey);
    public bool GetNextKeyDown => Input.GetKeyDown(ChoseNextKey);
    public bool GetPreviousKeyDown => Input.GetKeyDown(ChosePreviousKey);

    public bool GetStartTimerKeyDown => Input.GetKeyDown(StartTimerKey);
    public bool GetStopTimerKeyDown => Input.GetKeyDown(StopTimerKey);
    public bool GetPauseTimerKeyDown => Input.GetKeyDown(PauseTimerKey);
}
