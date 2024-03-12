using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 3;

    [SerializeField]
    private int health;

    [SerializeField]
    private Text winscreen;


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
            winscreen.gameObject.SetActive(true);
            Time.timeScale = 0;

        }

    }
}
