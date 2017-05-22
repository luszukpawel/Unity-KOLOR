using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    //  public Text EnemyHitText;
    public Text EnemyHitText;
    public int EnemyHitCounter;
    public GameObject MuzzleFlash;

    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            StartCoroutine(MuzzleFlashEnumerator());
            if (Physics.Raycast(transform.position, transform.right, out hit))
            {
                // Debug.Log("piew piew");
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    EnemyHitCounter++;
                    EnemyHitText.text = "ENEMIES HITS : " + EnemyHitCounter;
                    hit.transform.gameObject.GetComponent<EnemyHp>().TakeHealth(50);
                }
            }

        }
    }

    public IEnumerator MuzzleFlashEnumerator()
    {
        MuzzleFlash.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.transform.gameObject.SetActive(false);
    }

}
