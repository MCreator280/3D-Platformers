using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GMLevel1RScript : MonoBehaviour
{
    public TextMeshPro TimeResultLv1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level1");
        }
        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level Select");
        }

        TimeResultLv1.text = "Time:" + GMLevel1Script.TimerLv1;
    }
}
