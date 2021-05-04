using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    int scoreInterval = 1;
    public int interval = 3;
    float nextTime = 0;
    float nextScoreTime = 0;
    public GameObject asteroid;

    float asteroidSpeed = 2;
    public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextScoreTime)
        {
            score += 1;
            scoreText.text = "Time Alive: " + score;
            nextScoreTime += scoreInterval;
            asteroidSpeed += 0.01f;
        }
        if (Time.time >= nextTime)
        {
            GameObject obj = Instantiate(asteroid, Vector3.zero, Quaternion.identity);
            obj.GetComponent<Asteroid>().moveSpeed = asteroidSpeed;
            nextTime += Random.Range(0, interval);
        }
    }
}
