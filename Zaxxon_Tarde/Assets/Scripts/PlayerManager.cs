using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;

    //Booleana que me dice si estoy vivo
    bool alive = true;


    //Posición de la nave al inicio
    Vector3 navePos = Vector3.zero;
    
    //Velocidad de desplazamientio
    [SerializeField] float desplSpeed;

    //Variables de Input
    float moveY;
    float moveX;

    float rightStickH;

    Vector2 move;

    InputActions inputActions;

    //Restricción de movimiento
    float posY;
    float posX;
    float limiteVertUp = 35f;
    float limiteVertDown = 0f;
    float limiteHorRight = 40f;
    float limiteHorLeft = -40f;

    bool inLimitV = true;
    bool inLimitH = true;

    //Varialbes para suavizado
    Vector3 currentRot;
    public float smoothTime = 0.2F;
    private Vector3 velocity = Vector3.zero;

    //El Avion para desactivarlo al chocar
    [SerializeField] GameObject avionMalla;

    //Componente HudUpdate que contiene los métodos para actualizar la UI
    [SerializeField] HudUpdate hudUpdate;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.Disparo.started += _ => Disparar();

        inputActions.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += _ => move = Vector2.zero;

        //inputActions.Player.MoveH.performed += ctx => moveX = ctx.ReadValue<float>();
        //inputActions.Player.MoveH.canceled += _ => moveX = 0f;

        //inputActions.Player.MoveV.performed += ctx => moveY = ctx.ReadValue<float>();
        //inputActions.Player.MoveV.canceled += _ => moveY = 0f;

        //GameManager.alive = true;
    }

    void Disparar()
    {
        print("BOOM");
    }


    // Start is called before the first frame update
    void Start()
    {
        
        
        desplSpeed = 24f;


        //Inicio en 9 de posición y de rotación
        //transform.position = navePos;
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

        //print(move);
        //print(GameManager.alive);

        if (GameManager.alive)
        {
            MoverNave();
            CheckLimits();
        }
           

    }

    void MoverNave()
    {


        //print(moveX);
        //Obtengo mi posición en X y en Y
        posY = transform.position.y;
        posX = transform.position.x;

        //Obtengo los valores del Gamepad
        moveY = move.y;
        moveX = move.x;
        //Rotación 
        //rightStickH = Input.GetAxis("HorizontalJ2");
        //print(rightStickH);

        //print(moveY);



        Vector3 movimientoVertical = Vector3.up * desplSpeed * Time.deltaTime * moveY;
        Vector3 movimientoHorizontal = Vector3.right * desplSpeed * Time.deltaTime * moveX;

        if(inLimitV)
            transform.Translate(movimientoVertical, Space.World);

        if (inLimitH)
            transform.Translate(movimientoHorizontal, Space.World);


        //transform.Rotate(Vector3.forward * Time.deltaTime * -360f * rightStickH);
        Vector3 vectorRot = new Vector3(moveY * -45f, 0, -45f * moveX);
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;
    }

    void CheckLimits()
    {

        //Compruebo límites verticales
        if(posY > limiteVertUp && moveY > 0)
        {
            inLimitV = false;
        }
        else if(posY < limiteVertDown && moveY < 0)
        {
            inLimitV = false;
        }
        else
        {
            inLimitV = true;
        }

        //Compruebo límites horizontales
        if (posX > limiteHorRight && moveX > 0)
        {
            inLimitH = false;
        }
        else if (posX < limiteHorLeft && moveX < 0)
        {
            inLimitH = false;
        }
        else
        {
            inLimitH = true;
        }


    }


    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstaculo")
        {
                  
            hudUpdate.UpdateLifes();

            if(GameManager.lifes == 0)
            {
                GameManager.alive = false;
                avionMalla.SetActive(false);
                //print(other.gameObject.name);
                speed = 0f;
            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }
        
    }



}
