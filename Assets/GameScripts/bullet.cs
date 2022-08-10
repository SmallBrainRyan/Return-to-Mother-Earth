using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float deathtime = 5;
    private Rigidbody _rigidbody;

    void Start()
    {
        StartCoroutine(Death());
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rigidbody.velocity = transform.forward * 10;
    }

    public void SetRot(Vector3 ag)
    {
        transform.eulerAngles = ag;
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(deathtime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Alien"))
        {
            Destroy(gameObject);
        }
    }
}
