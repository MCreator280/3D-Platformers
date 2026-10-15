using UnityEngine;

public class DashGateScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerControlsScript PS1 = other.gameObject.GetComponent<PlayerControlsScript>();

        if(PS1 != null)
        {
            Debug.Log("I'm touching it so give me a boost");
            PS1.TopSpeedState = true;
            PS1.CountDownTS = 5;
        }

        Player2ControllerScript PS2 = other.gameObject.GetComponent<Player2ControllerScript>();

        if(PS2 != null)
        {
            Debug.Log("I'm touching it so give me a boost");
            PS2.TopSpeedState = true;
            PS2.CountDownTS = 5;
        }
    }
}
