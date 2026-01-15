using UnityEngine;

public class ArrayExemplo : MonoBehaviour
{
    GameObject [] balas = new GameObject[5];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        balas = new GameObject[10];

        balas[0].SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
