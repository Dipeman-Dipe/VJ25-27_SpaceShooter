using System.Collections;
using UnityEngine;

public class Tree : MonoBehaviour
{

    bool powerUpOn;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();
        if(player!=null)
        {
            StartCoroutine(Delay());
        } 
    }

    IEnumerator Delay()
    {
        print("Start power up timer");
        powerUpOn = true;
        yield return new WaitForSeconds(1);
        powerUpOn = false;
        print("Finish power up timer");
    }


}
