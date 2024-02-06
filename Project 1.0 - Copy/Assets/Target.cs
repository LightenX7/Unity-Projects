using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float health;

    public void TakeDamage(float amount)
    {
        WanderingAI behavior = GetComponent<WanderingAI>();

        if (behavior != null)
        {
            behavior.setAlive(false);
        }


        health -= amount;
        if (health <= 0f )
        {
            StartCoroutine(Die());

        }
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);

    }



}
