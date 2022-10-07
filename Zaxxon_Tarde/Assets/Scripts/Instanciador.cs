using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    [SerializeField] GameObject obstacle;

    [SerializeField] PlayerManager playerManager;

    float intervalo;
    float speed;



    //Variables para las columna iniciales
    float distanciaEntreColumnas;
    float posIniInt;
    float nObstInter;

    // Start is called before the first frame update
    void Start()
    {
        //playerManager = GameObject.Find("NavePrefab").GetComponent<PlayerManager>();
        //Damnos valores para los obstaculos intermediosa
        distanciaEntreColumnas = 20f;
        posIniInt = 40f;
        CrearObstIntermedios();

        StartCoroutine("Corrutina");

        

        intervalo = distanciaEntreColumnas / playerManager.speed;
    }

    void CrearObstIntermedios()
    {
        float distanciaTotal = transform.position.z - posIniInt;
        float nObstInt = Mathf.Floor( distanciaTotal / distanciaEntreColumnas);
        print(nObstInt);
        float posZ = posIniInt  ;
        for(int n = 0; n < nObstInt; n++)
        {
            //print(n);

            CrearColumna(posZ);
            posZ += distanciaEntreColumnas;

        }

    }





    // Update is called once per frame
    void Update()
    {
        
    }


    void CrearColumna(float posZ)
    {
        float randomX = Random.Range(-40f, 40f);
        Vector3 instPos = new Vector3(randomX, 0f, posZ);
        Instantiate(obstacle, instPos, Quaternion.identity);

    }

    IEnumerator Corrutina()
    {
        while(true)
        {
            
            
            CrearColumna(transform.position.z);
            
            if(playerManager.speed > 0)
                intervalo = distanciaEntreColumnas / playerManager.speed;

            yield return new WaitForSeconds(intervalo);

        }

    }

}
