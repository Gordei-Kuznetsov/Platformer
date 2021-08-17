using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    public LayerMask groundLayers;
    public float jumpForce = 2;
    private SphereCollider col;

    void Start() {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        rb.AddForce(movement * speed);

        if(isGrounded() && Input.GetAxis("Jump") != 0){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool isGrounded(){
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius, groundLayers);
    }
}
