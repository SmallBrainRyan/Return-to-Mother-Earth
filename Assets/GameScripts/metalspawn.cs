using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalspawn : MonoBehaviour
{
    public GameObject metal;
    public int xPos;
    public int zPos;
    public Transform player;


    public float time = 10;
    private float timeleft;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Astronaut").GetComponent<Transform>();
        timeleft = time;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= 1 * Time.deltaTime;
        if (timeleft < 0)
        {
            Spawn();
            timeleft = time;
        }
    }
    private void Spawn()
    {
        xPos = (int)Random.Range(player.transform.position.x + 20, player.transform.position.x + 100);
        zPos = (int)Random.Range(player.transform.position.x + 20, player.transform.position.x + 100);
        Instantiate(metal, new Vector3(xPos, 2, zPos), Quaternion.identity);
    }
}
