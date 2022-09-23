using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Posición de la nave al inicio
    Vector3 navePos = Vector3.zero;
    
    //Velocidad de desplazamientio
    [SerializeField] float desplSpeed;

    //Variables de Input
    float moveY;
    float moveX;

    float rightStickH;

    //Restricción de movimiento
    float posY;
    float posX;
    float limiteVertUp = 10f;
    float limiteVertDown = 0f;
    float limiteHorRight = 10f;
    float limiteHorLeft = -10f;

    //bool inLimitY = true;


    // Start is called before the first frame update
    void Start()
    {
        desplSpeed = 4f;


        //Inicio en 9 de posición y de rotación
        transform.position = navePos;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    /*
    private void FixedUpdate()
    {
        navePos += despl;
        transform.position = navePos * desplSpeed * Time.deltaTime;
    }
    */

    // Update is called once per frame
    void Update()
    {

        MoverNave();

    }

    void MoverNave()
    {

        //Obtengo mi posición en X y en Y
        posY = transform.position.y;
        posX = transform.position.x;

        //Obtengo los valores del Gamepad
        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        //Rotación 
        rightStickH = Input.GetAxis("HorizontalJ2");
        //print(rightStickH);

        //print(moveY);



        Vector3 movimientoVertical = Vector3.up * desplSpeed * Time.deltaTime * moveY;
        Vector3 movimientoHorizontal = Vector3.right * desplSpeed * Time.deltaTime * moveX;


        if ((posY <= limiteVertUp || moveY < 0) && (posY >= limiteVertDown || moveY > 0))
        {
            transform.Translate(movimientoVertical, Space.World);
        }



        if ((posX <= limiteHorRight || moveX < 0) && (posX >= limiteHorLeft || moveX > 0))
        {
            transform.Translate(movimientoHorizontal, Space.World);
        }



        transform.Rotate(Vector3.forward * Time.deltaTime * -360f * rightStickH);

        //transform.eulerAngles = new Vector3(0f, 0f, moveX * -60f);



    }
}
