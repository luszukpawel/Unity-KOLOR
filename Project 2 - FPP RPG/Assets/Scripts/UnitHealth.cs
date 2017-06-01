using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public int HealthPoints = 100;
    public void TakeHealth(int hp)
    {
        HealthPoints -= hp;

        if (HealthPoints <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }
}
