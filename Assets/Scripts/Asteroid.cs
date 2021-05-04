using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;

    public float xPosition = 12;
    public float yPositionRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(xPosition, Random.Range(-yPositionRange, yPositionRange), 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(-moveSpeed * Time.deltaTime, 0);
        transform.position += (Vector3)velocity;

        if (transform.position.x < -xPosition)
        {
            Destroy(this.gameObject);
        }
    }
}
