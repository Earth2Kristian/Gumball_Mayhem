using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GumballBounceScript : MonoBehaviour
{
    Vector3 lastVelocity;
    public float bounceSpeed = 5f;
    
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        lastVelocity = rb.linearVelocity;
    }

    public void OnCollisionEnter(Collision collision)
    {
       Vector3 normal = collision.contacts[0].normal;
       Vector3 reflectedVelocity = Vector3.Reflect(lastVelocity.normalized, normal);
       rb.linearVelocity = reflectedVelocity * bounceSpeed;
    }
}
