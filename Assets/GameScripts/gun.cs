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
        if (Input.GetButton("Fire1"))
        {
            new WaitForSeconds(0.5f);
            var bulletVar = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            bulletVar.GetComponent<bullet>().SetRot(transform.eulerAngles);
            bulletVar.transform.SetParent(trash);
        }

    }
}
