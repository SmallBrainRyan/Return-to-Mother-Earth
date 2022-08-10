using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aliendelete : MonoBehaviour
{
    private Transform player;
    public Transform enemy;

    private float distance;
    public float attackrange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Astronaut").GetComponent<Transform>();
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (distance >= attackrange)
        {
            new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}
