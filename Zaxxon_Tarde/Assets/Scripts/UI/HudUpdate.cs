using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudUpdate : MonoBehaviour
{
    //Vidas
    [SerializeField] Sprite[] lifesSprites;
    [SerializeField] Image lifesImage;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLifes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLifes()
    {
        
        int n = GameManager.lifes;
        print(n);
        lifesImage.sprite = lifesSprites[n];
    }
}
