using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsScript : MonoBehaviour
{
    public Camera Eyes;

    public Rigidbody RB;

    public Bulletscript BulletPrefab;

    public Renderer PlayerLook;

    public List<GameObject> Floors;



    public float MouseSensitivity = 3;

    public float PlayerSpeed = 5;
    public float WalkSpeed = 10;
    public float JumpPower = 7;

    public float TopSpeed = 20;
    public float CountDownTS = 5;
    public float EnemyBouncePower = 7;

    
    public Transform PlayerOrientation;
    public bool DoubleJump = false;
    public float DoubleJumpPower = 14;
    public float BounceJumpCountdown = 0.2f;


    public bool TopSpeedState = false;
    public bool JumpAttack = false;
    public bool OnGround = true;
    public bool BounceJump = false;

    public JumpHitboxScript JHS;
    public Vector3 Jump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerSpeed = WalkSpeed;
        //Debug.Log($"I should be this fast {PlayerSpeed}");

    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        
       //Apparently this makes it so everytime I walk, its only in the direction I'm looking, with it being tied to the InputCode
        Vector3 Movement = PlayerOrientation.forward * VerticalInput + PlayerOrientation.right* HorizontalInput;
        Jump = Vector3.zero;


        Color32 Bluecolor = new Color32(119,162,255,255);

        PlayerLook.material.color = Bluecolor;


         if(TopSpeedState == true)
        {
            PlayerSpeed = TopSpeed;
            PlayerLook.material.color = Color.green;
            CountDownTS -= Time.deltaTime;
        }
        else
        {
            PlayerSpeed = WalkSpeed;
            //PlayerLook.material.color = Bluecolor;
        }

        if(CountDownTS <= 0)
        {
            TopSpeedState = false;
            CountDownTS = 5;
        }


        //OnGround() means true
        if(Keyboard.current.spaceKey.wasPressedThisFrame && OnGround)
        {
            //Debug.Log("I should be Jumping");
            Jump.y = JumpPower;
        }
        else if (BounceJump == true)
        {
            Jump.y = EnemyBouncePower;
            BounceJumpCountdown -= Time.deltaTime;
        }
        else
        {
            Jump.y = RB.linearVelocity.y;
        }


        if(BounceJumpCountdown <= 0)
        {
            BounceJump = false;
        }

        
        
        //Raycast 
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



        if(OnGround == false)
        {
            DoubleJump = true;
            JumpAttack = true;
        }
        else
        {
            DoubleJump = false;
            JumpAttack = false;
        }

        if(JumpAttack == true)
        {
            PlayerLook.material.color = Color.green;
            JHS.JHSTransform.position =  PlayerOrientation.position;
        }
        else
        {
            PlayerLook.material.color = Bluecolor;
            JHS.JHSTransform.position = new Vector3 (1, 57, -93);
        }

    

        RB.linearVelocity = new Vector3 (Movement.x * PlayerSpeed, Jump.y , Movement.z * PlayerSpeed);

        
    }


    // public bool OnGround()
    // {
    //     return Floors.Count > 0;
    // }

    // private void OnCollisionEnter(Collision other)
    // {
    //     //If I touch something and it's not already in my list of things I'm touching. . .
    //         //Add it to the list
    //     if (!Floors.Contains(other.gameObject))
    //         Floors.Add(other.gameObject);
    // }

    // private void OnCollisionExit(Collision other)
    // {
    //     //When I stop touching something, remove it from the list of things I'm touching
    //     Floors.Remove(other.gameObject);
    // }

}
