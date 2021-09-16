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

    public AudioSource shotAudioSource;
    public AudioClip destroyClip;

    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;

    float buffer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        float distanceZ = Mathf.Abs(Camera.main.transform.position.z + transform.position.z);
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            
            Rigidbody2D projectile = Instantiate(prefabProjectile, mRigidBody.position, Quaternion.identity);
            projectile.velocity = transform.up * projectileSpeed;
            shotAudioSource.Play();

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

		if (transform.position.x < leftConstraint - buffer)
		{
			transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
		}
		if (transform.position.x > rightConstraint + buffer)
		{
			transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
		}


		if (transform.position.y < bottomConstraint - buffer)
        {
            transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
        }
        if (transform.position.y > topConstraint + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
        }

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        AudioSource.PlayClipAtPoint(destroyClip, transform.position);
        Destroy(gameObject);
	}


}
