using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GMLevel2Script : MonoBehaviour
{
    public float Level2Timer = 0f;
    public TextMeshPro Timer2Text;

    public static string TimerLv2; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level2Timer += Time.deltaTime;

        int Minutes = Mathf.FloorToInt(Level2Timer/60);
        int Seconds = Mathf.FloorToInt(Level2Timer % 60);
        string TimerCountUpLV2 = string.Format("{0:00}:{1:00}", Minutes, Seconds);

        TimerLv2 = TimerCountUpLV2;

        Timer2Text.text = "Timer: " + TimerCountUpLV2;

        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level Select");
        }
    }
}
