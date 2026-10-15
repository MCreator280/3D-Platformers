using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Player;
    //public Rigidbody RB;
    public float RotationSpeed; 

    public Transform PlayerOrientation; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This was done in a tutorial
        //This code overall lets the distance of the camera and player change to become the new forward for them when it rotates
        //Distance between Camera and Player
        //Lines 24-30 are the code for how the camera becomes the forward for the player
        Vector3 CamDirection = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);

        //Makes the Distance with Cam and Player, into a forward
        PlayerOrientation.forward = CamDirection.normalized;

        //Visually show the Distance with camera and player
        // Debug.Log($"Distance between camera and player {CamDirection}");
        // Debug.Log($"PlayerOrientation {PlayerOrientation.forward}");

       
        //Rotate the player well the front of them, tracks what direction was being pressed down
        //This is how it tracks the keybutton input
        // float HorizontalInput = Input.GetAxis("Horizontal");
        // float VerticalInput = Input.GetAxis("Vertical");
        // //This causes the forward to be together with the keycodes that are vertical which are WS, right is now together with the keycode for Horizontal which are AD
        // Vector3 InputDir = PlayerOrientation.forward * VerticalInput + PlayerOrientation.right * HorizontalInput;

        

        // //It happens when the direction of the player, isn't equal to 0,0,0, this causes the player to rotate to the direction they are facing which will be the forward. Causing their face to slowly rotate there
        // //It uses the player previous forward. then the current direction that was pressed as two points. which causes the face to move toward the current input direction. Player is the capsule
        // if(InputDir != Vector3.zero)
        // {
        //     Player.forward = Vector3.Slerp(Player.forward, InputDir.normalized, Time.deltaTime * RotationSpeed);
        // }

    }
}
