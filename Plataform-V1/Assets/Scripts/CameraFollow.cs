using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 Offset;
    void Update()
    {
        transform.position = player.position + Offset;        
    }
}
