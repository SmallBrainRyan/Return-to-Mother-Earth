using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int zPos;
    private int enemycount;
    public GameObject trash;
    public Transform player;

    public float time = 5;
    public float timeleft = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Astronaut").GetComponent<Transform>();
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft<0 && trash.transform.childCount < 10)
        {
            Spawn();
            timeleft = time;
        }
    }

    private void Spawn()
    {       
            xPos = (int)Random.Range(player.transform.position.x + 1f, player.transform.position.x + 50f);
            zPos = (int)Random.Range(player.transform.position.x + 1, player.transform.position.x + 50);
            var group = Instantiate(enemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

            group.transform.SetParent(trash.transform);
       

    }
}
