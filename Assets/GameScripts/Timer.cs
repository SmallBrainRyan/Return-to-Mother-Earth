using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float startTime;
    private float currentTime;

    public Transform respawnpoint;
    public Transform player;
    
  

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Astronaut").GetComponent<Transform>();
        respawnpoint = GameObject.Find("Respawn").GetComponent<Transform>();

        currentTime = startTime;
        text = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        text.text = "" + currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        text.text = currentTime.ToString(".00");
        if(currentTime == 0)
        {
            player.transform.position = respawnpoint.transform.position;
            Physics.SyncTransforms();
            currentTime = startTime;
        }
    }
}
