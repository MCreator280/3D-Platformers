using UnityEngine;

public class JumpHitboxScript : MonoBehaviour
{
    public Transform JHSTransform;
    public PlayerControlsScript PS1;

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
        // if(other.CompareTag("Orb"))
        // {
        //     //Debug.Log("I'm touching an orb, thank you");
        //     //Destroy(other.gameObject);
        //     Orb.OrbGone = true;
        //     PS1.BounceJump = true;
        // }

        OrbScript orb = other.gameObject.GetComponent<OrbScript>();

        if(orb != null)
        {
            
            orb.OrbGone = true;
            PS1.BounceJump = true;
        }
    }
}
