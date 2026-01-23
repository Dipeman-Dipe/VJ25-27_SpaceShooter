using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] Transform cam;

    [SerializeField] int damage = 1;

    [SerializeField] GameObject bulletHoleDecal;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            LayerMask ignorePlayerMask = ~(1<<6);
            
            if(Physics.Raycast(cam.position,cam.forward, out RaycastHit hit,Mathf.Infinity,ignorePlayerMask))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();

                if(enemy != null)
                {
                    enemy.TakeDamage(damage);  
                }

                GameObject decal = Instantiate(bulletHoleDecal,hit.point,Quaternion.identity,hit.transform);
            }  
        }
    }
}

