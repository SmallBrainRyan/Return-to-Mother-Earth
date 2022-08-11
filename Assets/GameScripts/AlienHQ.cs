using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHQ : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int zPos;
    private int enemycount;
    public GameObject trash;

    public float time = 1;
    public float timeleft = 1;

    [Header("Damage")]
    public int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft < 0 && trash.transform.childCount < 3)
        {
            Spawn();
            timeleft = time;
        }

        if (currentHealth == 0)
        {
            StartCoroutine(Death());
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("bullet"))
        {
            Damage(1);
        }
    }
    void Damage(int damage)
    {
        currentHealth -= damage;
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    private void Spawn()
    {
        xPos = (int)Random.Range(this.transform.position.x + 1, this.transform.position.x + 10);
        zPos = (int)Random.Range(this.transform.position.x + 1, this.transform.position.x + 10);
        var group = Instantiate(enemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

        group.transform.SetParent(trash.transform);


    }
}
