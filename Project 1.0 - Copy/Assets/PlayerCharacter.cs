using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;



    void Start()
    {
        health = 25;
 
    }

    public void Hurt(int damage)
    {
        health -= damage;

        Debug.Log($"Health : {health}");
        if (health <= 0f)
        {
            Time.timeScale = 0;
            Debug.Log("Player Died!");
        }
    }
    public void Gain(int health)
    {
        health += health;

        Debug.Log($"Health : {health}");
    }


}
