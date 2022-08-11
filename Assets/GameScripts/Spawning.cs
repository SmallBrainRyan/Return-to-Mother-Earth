using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemy;
    public GameObject HQ;
    public GameObject ma;
    public int xPos;
    public int yPos;
    public int zPos;
    public GameObject trash;
    public GameObject trash2;
    public GameObject trash3;
    public Transform player;

    public float time = 5;
    private float timeleft;
    public float tIme = 30;
    private float tImeleft;
    public float tiMe = 30;
    private float Timeleft;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Astronaut").GetComponent<Transform>();
        timeleft = time;
        tImeleft = tIme;
        Timeleft = tiMe;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        tImeleft -= Time.deltaTime;
        Timeleft -= Time.deltaTime;
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

        if (Timeleft < 0 || trash.transform.childCount >= 5 && trash3.transform.childCount < 5)
        {
            Spawn3();
            Timeleft = tiMe;
        }
    }

    private void Spawn()
    {       
            xPos = (int)Random.Range(player.transform.position.x + 1, player.transform.position.x + 50);
            yPos = (int)Random.Range(player.transform.position.x + 1, player.transform.position.x + 50);
            zPos = (int)Random.Range(player.transform.position.x + 1, player.transform.position.x + 50);
            var group = Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);

            group.transform.SetParent(trash.transform);           
    }

    private void Spawn2()
    {
        xPos = (int)Random.Range(player.transform.position.x + 40, player.transform.position.x + 60);
        yPos = (int)Random.Range(player.transform.position.x + 40, player.transform.position.x + 200);
        zPos = (int)Random.Range(player.transform.position.x + 40, player.transform.position.x + 60);
        var home = Instantiate(HQ, new Vector3(xPos, yPos, zPos), Quaternion.identity);

        home.transform.SetParent(trash2.transform);
    }
        private void Spawn3()
    {
        xPos = (int)Random.Range(player.transform.position.x + 40, player.transform.position.x + 60);
        yPos = (int)Random.Range(player.transform.position.x + 40, player.transform.position.x + 60);
        zPos = (int)Random.Range(player.transform.position.x + 40, player.transform.position.x + 60);
        var home = Instantiate(ma, new Vector3(xPos, yPos, zPos), Quaternion.identity);

        home.transform.SetParent(trash3.transform);
    }
}
