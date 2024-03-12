using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    public EnemyHealth enemyhealth;
    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Weak Point")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }


}


   
