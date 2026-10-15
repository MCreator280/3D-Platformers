using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;


public class GMLevel2RScript : MonoBehaviour
{
    public TextMeshPro TimeResultLv2Timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level 2");
        }
        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level Select");
        }

        TimeResultLv2Timer.text = "Time:" + GMLevel2Script.TimerLv2;
    }
}
