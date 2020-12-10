using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum States
{
    Wandering = 0,
    Eating = 1,
    Sleeping = 2,
    Socializing = 3,
    HeadingToLocation = 4
}

public class TownspersonMovement : MonoBehaviour
{
    NavMeshAgent nav;
    public Vector2 secBetweenWanderMinMax;
    public float wanderRange;
    States states;
    float wanderTimer;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        Wander();
        states = States.Wandering;
    }

    private void Update()
    {
        if(wanderTimer > 0)
        {
            wanderTimer -= Time.deltaTime;
        }
        else
        {
            if(states == States.Wandering)
            Wander();
            else
            {
                float secBetweenWander = Random.Range(secBetweenWanderMinMax.x, secBetweenWanderMinMax.y);
            }
        }
    }

    public void ChangeState(States state)
    {
        states = state;
    }

    void Wander()
    {
        float secBetweenWander = Random.Range(secBetweenWanderMinMax.x, secBetweenWanderMinMax.y);
        float randomX = Random.Range(-wanderRange, wanderRange);
        float randomZ = Random.Range(-wanderRange, wanderRange);

        Vector3 wanderSpot = transform.position + new Vector3(randomX, 0, randomZ);
        if (Vector3.Distance(transform.position,wanderSpot) > 0.5f)
        {
            Move(wanderSpot);
        }

        wanderTimer = secBetweenWander;

        
    }

    public void Move(Vector3 dest)
    {
        nav.SetDestination(dest);
    }
}
