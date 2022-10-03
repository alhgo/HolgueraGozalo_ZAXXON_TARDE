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
        

        distanciaEntreColumnas = 20f;
        StartCoroutine("Corrutina");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CrearColumna()
    {
        float randomX = Random.Range(-40f, 40f);
        Vector3 instPos = new Vector3(randomX, 0f, transform.position.z);
        Instantiate(obstacle, instPos, Quaternion.identity);

    }

    IEnumerator Corrutina()
    {
        while(true)
        {

            CrearColumna();


            yield return new WaitForSeconds(intervalo);

        }

    }

}
