using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int maxhealth;
    private int currenthealth;


    void Start()
    {
        maxhealth = 25;
        currenthealth = maxhealth;
 
    }

    public void Hurt(int damage)
    {
        currenthealth -= damage;

        Debug.Log($"Health : {currenthealth}");
        if (currenthealth <= 0f)
        {
            Time.timeScale = 0;
            Debug.Log("Player Died!");
        }
    }
    public void Gain(int health)
    {
        currenthealth += health;
        Debug.Log($"Health : {currenthealth}");
        if (currenthealth > maxhealth) 
        {
            currenthealth = maxhealth;
        }
        
    }


}
