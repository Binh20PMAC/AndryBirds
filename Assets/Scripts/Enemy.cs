using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Defend;
    public GameObject Smoke;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if(collision.relativeVelocity.magnitude > Defend) // Do lon luc cham giua 2 vat, luc va cham > defend
        {
            Destroy(gameObject, 0.3f); // Pha huy vat the trong 0.3s

            Instantiate(Smoke, transform.position, Quaternion.identity); // Ham tao ra object Smoke tai vi tri bien mat, Quaternion la quan ly goc quay

            //Smoke.SetActive(true);
  
        }
        else
        {
            Defend -= collision.relativeVelocity.magnitude; // Cham nhieu luc khac nhau thi xoa 
        }    
    }
}
