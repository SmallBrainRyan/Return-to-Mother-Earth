using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Mama : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float rotatespeed;
    private Transform player;

    [Header("Tracking")]
    public float sightrange;
    public float attackrange;

    private float distance;

    private Animator anime;

    [Header("Attack")]
    public float time = 2;
    public float timeleft = 2;

    [Header("Damage")]
    public int maxHealth = 100;
    public int currentHealth = 100;

    private enum State
    {
        Idle,
        Walk,
        Attack
    }

    private State currentState = State.Idle;



    private void Start()
    {
        player = GameObject.Find("Astronaut").GetComponent<Transform>();
        anime = GetComponent<Animator>();

        currentHealth = maxHealth;
    }
    void Update()
    {
        float time = Time.deltaTime;

        distance = Vector3.Distance(player.transform.position, this.transform.position);

        switch (currentState)
        {
            case State.Idle:
                {
                    anime.SetBool("Move", false);

                    if (distance <= sightrange)
                    {
                        currentState = State.Walk;
                    }
                    break;
                }
            case State.Walk:
                {
                    transform.LookAt(player.position);

                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * time);

                    anime.SetBool("Move", true);
                    if (distance <= attackrange)
                    {
                        currentState = State.Attack;
                    }
                    if (distance >= sightrange)
                    {
                        currentState = State.Idle;
                    }
                    break;
                }
            case State.Attack:
                {
                    if (distance >= attackrange)
                    {
                        currentState = State.Walk;
                    }
                    StartCoroutine(Death());
                    break;
                }
        }

    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("bullet"))
        {
            Damage(1);
        }

        if (currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
    }
    void Damage(int damage)
    {
        currentHealth -= damage;
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
