using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Booleana que dice si estoy vivo
    public static bool alive;

    //N�mero de vidas que me quedan
    public static int lifes;



    public void StartGame()
    {
        alive = true;
        lifes = 3;
        
    }
}
