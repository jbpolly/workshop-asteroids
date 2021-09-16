using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int asteroidNumber = 3;

    void Start()
    {
        for (int i = 0; i < asteroidNumber; i++) {

            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-5f, 5f);
            Vector3 position = new Vector3(x, y, 0f);
            Instantiate(asteroidPrefab, position, Quaternion.identity);
        }
    }

 
}
