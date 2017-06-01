using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject Player;
    public float Speed = 5f;
    public float AttackRange = 15f;
    public float lookAtDistance = 25f;
    public float RotateDamping = 6f;
    public float HitDistance = 1f;
    private float Distance;
    public GameObject Trigger;
    public Animator EnemyAnimator;
    private bool isWalking = false;


    void Update()
    {
    
        Distance = Vector3.Distance(Player.transform.position, transform.position);
        StandBy();
    }

    void StandBy()
    {
        if (Distance < lookAtDistance)
        {
            LookAt();
     //       isWalking = false;
            Trigger.transform.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        }
        if (Distance > lookAtDistance)
        {
            isWalking = false;
            if (isWalking)
            {
                EnemyAnimator.CrossFade("Idle", 0.3f);
            }
            Trigger.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if (Distance < AttackRange)
        {
            Attack();
            LookAt();
           
            Trigger.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;

        }
    }

    void Attack()
    {
       
        if(!isWalking)
        {
            EnemyAnimator.CrossFade("Walk_Cycle", 0.3f);
        }
        isWalking = true;



        this.transform.GetComponent<NavMeshAgent>().destination = Player.transform.position;

    }

    void LookAt()
    {
        var rotation = Quaternion.LookRotation(Player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotateDamping);

    }
}
