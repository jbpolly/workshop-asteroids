using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaQuadrado : MonoBehaviour
{

    public GameObject prefabQuadrado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return)) {

            GameObject instanciaQuadrado = Instantiate(prefabQuadrado, Vector3.zero, Quaternion.identity);

            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            instanciaQuadrado.transform.position = new Vector3(x, y, 0f);
        
        }


    }
}
