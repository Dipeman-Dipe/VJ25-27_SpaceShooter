using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject[] vidasUi;

    static UiManager instance;
    [SerializeField] TextMeshProUGUI moedaText;

    public static UiManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject); 
    }

    public void ChangeLifeUI(int vidas)
    {
        for(int i = 0;i<vidasUi.Length;i++)
        {
            if(i<vidas)
                vidasUi[i].SetActive(true);
            else
                vidasUi[i].SetActive(false);

        }
    }

}
