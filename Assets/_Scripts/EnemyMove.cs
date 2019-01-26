using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Animator anim;
    public enum Modes { CHASING, THROWING, ATTACKING }
    [SerializeField] Modes currentMode = Modes.CHASING;
    PlayerHealth player;
    NavMeshAgent agent;
    [SerializeField] Enemy stats;
    [SerializeField] float attackRange;
    [SerializeField] float throwRange;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = FindObjectOfType<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();
    
    }

    // Update is called once per frame
    void Update()
    {
        float distToTarget = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(distToTarget + " away");
        switch (currentMode) {
            case Modes.CHASING:
                //Debug.Log("chasing");
                anim.SetBool("attacking", false);
                anim.SetBool("throwing", false);
                agent.speed = stats.moveSpeed;
                agent.SetDestination(player.transform.position);

                
                if (distToTarget <= attackRange) {
                    currentMode = Modes.ATTACKING;
                }
                else if (distToTarget <= throwRange) {
                    currentMode = Modes.THROWING;
                }
                break;
            case Modes.THROWING:
                Debug.Log("Throwing");
                anim.SetBool("attacking", false);
                anim.SetBool("throwing", true);
                //TODO instatiate projectile

                if (distToTarget > throwRange) {
                    currentMode = Modes.CHASING;
                }
                break;
            case Modes.ATTACKING:
                Debug.Log("attacking");
                anim.SetBool("attacking", true);
                anim.SetBool("throwing", true);
                player.TakeDamage(stats.damageDealt);
                if (distToTarget > attackRange) {
                    currentMode = Modes.CHASING;
                }
                break;
            default:
                break;
        }
  
    }
}
