using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Rigidbody2D mRigidBody;
    public float acceleration = 1f;
    public float angularSpeed = 180f;
    public float maximumSpeed = 5f;

    public Rigidbody2D prefabProjectile;
    public float projectileSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            
            Rigidbody2D projectile = Instantiate(prefabProjectile, mRigidBody.position, Quaternion.identity);
            projectile.velocity = transform.up * projectileSpeed;

        }
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 direction = transform.up * acceleration;
            mRigidBody.AddForce(direction, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mRigidBody.rotation += angularSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            mRigidBody.rotation -= angularSpeed * Time.deltaTime;
        }

        if (mRigidBody.velocity.magnitude > maximumSpeed) {
            mRigidBody.velocity = Vector2.ClampMagnitude(mRigidBody.velocity, maximumSpeed);
        }

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{

        Destroy(gameObject);

  //      
		//{
  //          Destroy(gameObject);
  //      }
	}


}
