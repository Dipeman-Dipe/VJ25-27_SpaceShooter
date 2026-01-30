using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] public int checkpointIndex;

    public bool isLastCheckpoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.currentCheckpoint = checkpointIndex;

            if (isLastCheckpoint) 
            { 
                GameManager.Instance.WinGame(); 
            }
        }
    }
}

