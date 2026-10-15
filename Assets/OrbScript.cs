using UnityEngine;

public class OrbScript : MonoBehaviour
{
    public bool OrbGone = false;
    public Transform OrbTransform;
    public Transform SpawnPointOr;
    public float OrbGoneTimer = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OrbGone == true)
        {
            OrbGoneTimer -= Time.deltaTime;
            OrbTransform.position = new Vector3(999,0,0);
        }

        if(OrbGoneTimer <= 0)
        {
            OrbGone = false;
        }

        if(OrbGone == false)
        {
            OrbGoneTimer = 5f;
            OrbTransform.position = SpawnPointOr.position;
        }
    }
}
