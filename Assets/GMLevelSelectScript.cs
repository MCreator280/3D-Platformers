using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GMLevelSelectScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level1");
        }
        if(Keyboard.current.yKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level 2");
        }
        if(Keyboard.current.uKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
