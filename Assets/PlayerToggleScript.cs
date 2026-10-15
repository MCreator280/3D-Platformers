using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerToggleScript : MonoBehaviour
{
    public PlayerControlsScript Player1Script;
    public Player2ControllerScript Player2Script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            //Debug.Log("Mouse was pressed, so my script should change, when I add that feature");
            Player1Script.enabled = !Player1Script.enabled;
            Player2Script.enabled = !Player2Script.enabled;

        }
    }
}
