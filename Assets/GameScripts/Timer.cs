using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float startTime = 20;
    private float currentTime = 20;

    public string level;

    private float distance;
    public float liferange = 10;
    public Transform ship;
    public HealthBar healthBar;

    void Start()
    {
        currentTime = startTime;
        text = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        text.text = "" + currentTime;
        ship = GameObject.Find("spaceship").GetComponent<Transform>();

    }

    void Update()
    {
        distance = Vector3.Distance(ship.transform.position, this.transform.position);
        if (distance > liferange)
        {
            currentTime -= 1 * Time.deltaTime;
            text.text = currentTime.ToString(".00");
            if (currentTime <= 0)
            {
                SceneManager.LoadScene(level);
            }
        }
        else if (distance <= liferange)
        {
            currentTime += 2 * Time.deltaTime;
            text.text = currentTime.ToString(".00");
        }
    }
}
