using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMouvement : MonoBehaviour
{

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - gunPos.x;
        mousePos.y = mousePos.y - gunPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        // if mouse is on the left from player rotate gun
        if (mousePos.x < this.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(180, 0, -angle));
        }
        if (mousePos.x > this.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }






    }
}
