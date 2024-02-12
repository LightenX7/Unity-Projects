using UnityEngine;

public class HpDropScript : MonoBehaviour
{


    [SerializeField]
    private int health = 3;


    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Gain(health);
        }
        Destroy(this.gameObject);
    }



}
