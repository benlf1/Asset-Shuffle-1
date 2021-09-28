using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    public Vector3 bulletOffset;
    public float attackCooldown;
    float nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Determines the direction the player wants to move
        //  from input commands. 
        // Note: The default input commands are WASD and the 
        //  arrow keys. You can change these in the Input Manager.
        // For more information:
        //  https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
        
        // Build the 2D velocity vector to move the player
        float xVelocity = x * moveSpeed * Time.deltaTime;
        float yVelocity = y * moveSpeed * Time.deltaTime;
        Vector2 velocity = new Vector2(xVelocity, yVelocity);

        // Add the velocity vector to the current position
        //  to move the player
        transform.position += (Vector3)velocity;

        if (Input.GetButton("Fire1")) {
            if (Time.time >= nextAttackTime) {
                GameObject b = Instantiate(bullet, this.gameObject.transform.position + bulletOffset, Quaternion.identity);
                b.tag = "Player";
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player") {
            this.gameObject.SetActive(false);
        }
    }
}
