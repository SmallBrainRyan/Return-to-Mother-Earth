using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public Transform trash;

    void Start()
    {
        spawnPoint = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bulletVar = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            bulletVar.GetComponent<bullet>().SetRot(transform.eulerAngles);
            bulletVar.transform.SetParent(trash);
        }

    }
}
