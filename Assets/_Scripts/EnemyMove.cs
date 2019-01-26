using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    PlayerHealth player;
    NavMeshAgent agent;
    [SerializeField] Enemy stats;
    [SerializeField] float attackRange;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();
    
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = stats.moveSpeed;
        agent.SetDestination(player.transform.position);

        float distToTarget = Vector3.Distance(player.transform.position, transform.position);
        if (distToTarget<= attackRange) {
            player.TakeDamage(stats.damageDealt);
        }
    }
}
