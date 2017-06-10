using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private int Damage = 50;
    private float SwordRange = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire");
   
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
              //  Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "Enemy" && hit.distance <= SwordRange)
                {
                    Debug.Log("Hit");
                    hit.transform.gameObject.GetComponent<UnitHealth>().TakeHealth(Damage);
                }
            }
        }
    }
}


