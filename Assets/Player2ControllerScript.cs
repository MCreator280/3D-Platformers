using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2ControllerScript : MonoBehaviour
{

    public Rigidbody RB;
    public Renderer PlayerLook;

    public float PlayerSpeed = 5;
    public float TopSpeed = 34;
    public float WalkSpeed = 20;
    public float JumpPower = 7;
    public float CountDownTS = 5;

    public Transform PlayerOrientation;
    public float Dash = 0;
    public float DashCoolDown = 0;

    public bool DashState = false;
    public bool TopSpeedState = false;
    public bool OnGround = true;


    public List<GameObject> Floors;
    public DashHitBoxScript DHS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerSpeed = WalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if(TopSpeedState == true)
        {
            PlayerSpeed = TopSpeed;
            CountDownTS -= Time.deltaTime;
        }
        else
        {
            PlayerSpeed = WalkSpeed;
        }

        if(CountDownTS <= 0)
        {
            TopSpeedState = false;
            CountDownTS = 5;
        }


        //Use playerOrientation.forward, thats now linked with the camera for the dash
        //Movement now resets everytime you turn the camera since thats the new forward and right
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
       

        Vector3 Movement = PlayerOrientation.forward * VerticalInput + PlayerOrientation.right* HorizontalInput;
        Vector3 Jump = Vector3.zero;
        Vector3 DashPW = PlayerOrientation.forward * 3;  


        Color32 Greencolor = new Color32(215,255,115,255);
        PlayerLook.material.color = Greencolor;
        
        if(Keyboard.current.spaceKey.wasPressedThisFrame && OnGround)
        {
            //Debug.Log("I should be Jumping");
            Jump.y = JumpPower;
        }
        else
        {
            Jump.y = RB.linearVelocity.y;
        }

        if(Physics.Raycast(PlayerOrientation.position,
                                Vector3.down,
                                out RaycastHit hit, 2))
        {
            if(hit.collider.CompareTag("Floor"))
            {
                 //Debug.Log("I'm on the ground");
                 OnGround = true;
            }
        }
        else
        {
            //Debug.Log("I'm not on the ground");
            OnGround = false;
        }


        if(Mouse.current.leftButton.wasPressedThisFrame && DashCoolDown <= 0)
        {
            Debug.Log("Boost or dash");
            Dash = 0.2f;
            DashCoolDown = 4f;
             
        }

        if(DashCoolDown >= 0)
        {
            DashCoolDown -= Time.deltaTime;
            PlayerLook.material.color = Color.red;

            if(Dash > 0)
            {
                Dash -= Time.deltaTime;
                Movement = DashPW;
                DashState = true;
                RB.linearVelocity = Movement;
            }
            else
            {
                DashState = false;
            }
        }
        else
        {
            PlayerLook.material.color = Greencolor;
        }

        if(DashState == true)
        {
            PlayerLook.material.color = Color.yellow;
            DHS.Transform.position = PlayerOrientation.position;
        }
        else
        {
            PlayerLook.material.color = Greencolor;
            DHS.Transform.position = new Vector3(2,90,-100);
        }

        RB.linearVelocity = new Vector3 (Movement.x * PlayerSpeed, Jump.y, Movement.z * PlayerSpeed);

    }

    
}
