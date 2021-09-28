using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float attackCooldown;
    float nextAttack;
    public int hp;

    public float bulletSpeed;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttack) {
            pattern1();
            nextAttack = Time.time + attackCooldown;
        }
    }

    void pattern1() {
        for (int i = 0; i < 36; i++) {
            GameObject b = Instantiate(bullet, this.transform.position, Quaternion.AngleAxis(i*10, Vector3.forward));
            b.tag = "Enemy";
            b.GetComponent<Bullet>().vector = b.transform.rotation * Vector2.right * bulletSpeed;
            // b.GetComponent<Bullet>().vector = Vector2.left * bulletSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            hp -= 1;
        }
        if (hp <= 0) {
            this.gameObject.SetActive(false);
        }
    }
}
