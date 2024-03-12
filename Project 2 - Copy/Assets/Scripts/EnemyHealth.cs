using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 1;

    [SerializeField]
    private int health;


    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }
}