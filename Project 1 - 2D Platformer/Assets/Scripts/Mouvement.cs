using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{

    public float Speed = 5f;
    public float Jump = 25f;
    public float x = 0f;
    private Rigidbody rb;
    private bool grounded;

    // metoda Start() wykonuje się raz po pojawieniiu się objektu na scenie
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // metoda Update() wykonuje się co klatkę
    void Update()
    {
        //Debug.Log("Rigidbody y" + rb.velocity.y);
        x = Input.GetAxis("Horizontal");
        rb.AddForce(Speed * x, 0, 0);

        if (!grounded && rb.velocity.y == 0)
        {
            grounded = true;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(transform.up * Jump);
            //rb.AddForce(0, Jump * x, 0);
            grounded = false;
        }

    }
}
