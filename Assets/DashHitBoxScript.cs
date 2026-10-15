using UnityEngine;

public class DashHitBoxScript : MonoBehaviour
{
    public Transform Transform;
    public Player2ControllerScript PS2;
   

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
        //     PS2.TopSpeedState = true;
        // }

        OrbScript orb = other.gameObject.GetComponent<OrbScript>();

        if(orb != null)
        {
            
            orb.OrbGone = true;
            PS2.TopSpeedState = true;
        }
    }

}
