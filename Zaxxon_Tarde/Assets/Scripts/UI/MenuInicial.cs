using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarGameManager()
    {
        GameManager.alive = true;
        GameManager.lifes = 3;
    }

    public void CargarEscena(int escena)
    {
        
        SceneManager.LoadScene(escena);
    
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

  

}

