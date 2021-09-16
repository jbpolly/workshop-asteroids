using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{

    public Rigidbody2D mRigidBody;
    public float maximumVelocity = 1f;

    void Start()
    {

        Vector2 direction = Random.insideUnitCircle;
        direction *= maximumVelocity;
        mRigidBody.velocity = direction;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
       
            Destroy(gameObject);
            Destroy(collision.gameObject);
        
          
    }


}
