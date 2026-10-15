using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GMLevel1Script : MonoBehaviour
{
    public float Level1Timer = 0f;
    public TextMeshPro Timer1Text;

    public static string TimerLv1; 
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level1Timer += Time.deltaTime;

        int Minutes = Mathf.FloorToInt(Level1Timer/60);
        int Seconds = Mathf.FloorToInt(Level1Timer % 60);
        string TimerCountUp = string.Format("{0:00}:{1:00}", Minutes, Seconds);

        TimerLv1 = TimerCountUp;

        Timer1Text.text = "Timer: " + TimerCountUp;
        
        Debug.Log($"{TimerLv1}");

        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level Select");
        }
        

        // if(Minutes <= 1)
        // {
        //     Debug.Log("I have an S rank");
        // }       
        // else if(Minutes >= 1)
        // {
        //     Debug.Log("I have an A rank");
        // }
    }
}
