using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
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
            Debug.Log("I win");
            SceneManager.LoadScene("Level 1 Result Screen");

        }

        Player2ControllerScript PS2 = other.gameObject.GetComponent<Player2ControllerScript>();

        if(PS2 != null)
        {
            Debug.Log("I win");
            SceneManager.LoadScene("Level 1 Result Screen");
        }
    }
}
