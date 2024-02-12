using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject HpDrop;


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
        if (health <= 0f)
        {
            StartCoroutine(Die());
            StartCoroutine(DropHp());

        }
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);

    }

    private IEnumerator DropHp()
    {
        Vector3 position = transform.position;
        GameObject BallofHealth = Instantiate(HpDrop, position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        BallofHealth.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(BallofHealth.gameObject);
    }


}
