using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemy;
    public GameObject HQ;
    public int xPos;
    public int zPos;
    private int enemycount;
    public GameObject trash;
    public GameObject trash2;
    public Transform player;

    public float time = 5;
    private float timeleft;
    public float tIme = 30;
    private float tImeleft;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Astronaut").GetComponent<Transform>();
        timeleft = time;
        tImeleft = tIme;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        tImeleft -= Time.deltaTime;
        if (timeleft<0 && trash.transform.childCount < 10)
        {
            Spawn();
            timeleft = time;
        }

        if (tImeleft < 0 || trash.transform.childCount >= 8 && trash2.transform.childCount < 3)
        {
            Spawn2();
            tImeleft = tIme;
        }
    }

    private void Spawn()
    {       
            xPos = (int)Random.Range(player.transform.position.x + 1f, player.transform.position.x + 50f);
            zPos = (int)Random.Range(player.transform.position.x + 1, player.transform.position.x + 50);
            var group = Instantiate(enemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

            group.transform.SetParent(trash.transform);           
    }

    private void Spawn2()
    {
        xPos = (int)Random.Range(this.transform.position.x + 40, this.transform.position.x + 60);
        zPos = (int)Random.Range(this.transform.position.x + 40, this.transform.position.x + 60);
        var home = Instantiate(HQ, new Vector3(xPos, 0, zPos), Quaternion.identity);

        home.transform.SetParent(trash2.transform);
    }
}
