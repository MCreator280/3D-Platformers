using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    public float Speed = 30;

    public Rigidbody RB;

    public float Knockback = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB.linearVelocity = transform.forward * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        Renderer R = other.gameObject.GetComponent<Renderer>();

        if(rb != null)
        {
            rb.AddForce(RB.linearVelocity.normalized * Knockback,ForceMode.Impulse);
        }

        if(R != null)
        {
            R.material.color = Color.yellow;
        }

        Destroy(gameObject);
    }
}

