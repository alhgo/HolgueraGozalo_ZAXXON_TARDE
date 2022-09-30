using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    [SerializeField] GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {

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

            print("Hola");

            yield return new WaitForSeconds(1f);

        }


    }

}
