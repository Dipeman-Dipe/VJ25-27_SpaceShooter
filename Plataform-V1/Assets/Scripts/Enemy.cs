using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] pontos;
    [SerializeField] float speed = 1;
    int pontosIndex = 0;


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = pontos[pontosIndex].position;

        Vector3 dir = targetPos - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;


        if(Vector3.Distance(transform.position,targetPos) <= 0.1f)
        {
            pontosIndex++;

            if(pontosIndex>=pontos.Length)
            {
                pontosIndex = 0;
            }
        }

    }
}
