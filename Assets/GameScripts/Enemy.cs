using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
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
    public ParticleSystem boom;

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
        boom = transform.Find("greenboom").GetComponent<ParticleSystem>();
        anime = GetComponent<Animator>();
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
                    if(distance <= attackrange)
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
                    new WaitForSeconds(2);
                    boom.gameObject.active = true;
                    StartCoroutine(Death());
                    break;
                }
         
        }
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
