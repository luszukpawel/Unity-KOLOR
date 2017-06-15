using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameManager gm;
    private GameObject Player;
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {
            gm.enemieskiled++;
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            gm.GameLost();
            other.gameObject.SetActive(false);
        }

        //   Destroy(other.gameObject);

    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        this.transform.GetComponent<NavMeshAgent>().destination = Player.transform.position;
    }
}
