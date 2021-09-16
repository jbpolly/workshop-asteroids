using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{

    public Rigidbody2D mRigidBody;
    public float maximumVelocity = 1f;

    public AudioClip destroyClip;
    
    void Start()
    {

        Vector2 direction = Random.insideUnitCircle;
        direction *= maximumVelocity;
        mRigidBody.velocity = direction;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
       
        if (collision.gameObject.transform.tag != "Boundary") {
            UIManager.score += 10;
            AudioSource.PlayClipAtPoint(destroyClip, transform.position);
            Destroy(collision.gameObject);
            if (gameObject.transform.localScale.x >= 0.6f) {
                Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
                GameObject asteroid1 = Instantiate(gameObject, position, Quaternion.identity);
                asteroid1.transform.localScale = gameObject.transform.localScale / 2;
                GameObject asteroid2 = Instantiate(gameObject, position, Quaternion.identity);
                asteroid2.transform.localScale = gameObject.transform.localScale / 2;
            }
          
        }
        Destroy(gameObject);
    }


}
