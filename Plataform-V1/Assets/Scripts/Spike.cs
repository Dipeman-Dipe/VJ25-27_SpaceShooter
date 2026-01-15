using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();

        if(player != null)
        {
            player.TakeDamage(1);
        }
    }
}
