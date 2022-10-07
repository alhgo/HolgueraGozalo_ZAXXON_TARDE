using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    [SerializeField] GameObject obstacle;

    PlayerManager playerManager;

    float intervalo;
    float speed;
    float distanciaEntreColumnas;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("NavePrefab").GetComponent<PlayerManager>();

        distanciaEntreColumnas = 20f;
        StartCoroutine("Corrutina");

        CrearObstIntermedios();

    }

    void CrearObstIntermedios()
    {

        float nObstInt = Mathf.Floor( 200 / distanciaEntreColumnas);
        print(nObstInt);
        float iniPosInt = 20f;
        for(int n = 0; n < nObstInt; n++)
        {
            //print(n);

            CrearColumna(iniPosInt);
            iniPosInt += distanciaEntreColumnas;

        }

    }





    // Update is called once per frame
    void Update()
    {
        intervalo = distanciaEntreColumnas / playerManager.speed;
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


            yield return new WaitForSeconds(intervalo);

        }

    }

}
