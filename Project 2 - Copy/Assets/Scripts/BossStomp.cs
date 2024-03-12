using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStomp : MonoBehaviour
{
    public BossHealth bosshealth;
    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Weak Point")
        {
            collision.gameObject.GetComponent<BossHealth>().TakeDamage(damage);
        }
    }




}
