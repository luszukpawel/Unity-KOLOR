using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
     //   Destroy(other.gameObject);

    }
}
