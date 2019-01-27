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

    [SerializeField] Transform throwPoint;
    [SerializeField] Transform throwPrefab;
    [SerializeField] bool canFire = true;
    [SerializeField] float fireDelay;

    bool canPlayAudio = true;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponentInChildren<Animator>();
        player = FindObjectOfType<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update() {
        transform.LookAt(player.transform);
        float distToTarget = Vector3.Distance(player.transform.position, transform.position);

        if (currentMode != Modes.CHASING && canPlayAudio) {
            canPlayAudio = false;
            StartCoroutine(PlayGrunt());
        }
        //Debug.Log(distToTarget + " away");
        switch (currentMode) {
            case Modes.CHASING:
                //Debug.Log("chasing");

                agent.speed = stats.moveSpeed;
                if (currentMode != Modes.THROWING) {
                    agent.SetDestination(player.transform.position);
                }

                if (distToTarget <= attackRange) {

                    anim.SetBool("attacking", true);
                    anim.SetBool("throwing", false);

                    currentMode = Modes.ATTACKING;
                }
                else if (distToTarget <= throwRange) {

                    anim.SetBool("attacking", false);
                    anim.SetBool("throwing", true);
                    agent.Stop();
                    currentMode = Modes.THROWING;
                }
                break;
            case Modes.THROWING:
                Debug.Log("Throwing");
                Fire();
                //TODO instatiate projectile

                if (distToTarget > throwRange) {

                    anim.SetBool("attacking", false);
                    anim.SetBool("throwing", false);
                    currentMode = Modes.CHASING;
                }
                if (distToTarget <= attackRange) {

                    anim.SetBool("attacking", true);
                    anim.SetBool("throwing", false);

                    currentMode = Modes.ATTACKING;
                }
                break;
            case Modes.ATTACKING:


                Debug.Log("attacking");

                player.TakeDamage(stats.damageDealt);
                if (distToTarget > attackRange) {

                    anim.SetBool("attacking", false);
                    anim.SetBool("throwing", false);
                    currentMode = Modes.CHASING;
                }
                break;
            default:
                break;
        }

    }

    public void Fire() {

        if (canFire) {
            canFire = false;
            StartCoroutine(resetFireDelay());
        }
    }

    

    private IEnumerator resetFireDelay() {
        yield return new WaitForSeconds(fireDelay);
        Instantiate(throwPrefab, throwPoint.position, throwPoint.rotation);
        canFire = true;
    }

    IEnumerator PlayGrunt() {
        SoundManager.instance.PlayClip(SoundManager.instance.enemyGrunt);
        yield return new WaitForSeconds(7);
        canPlayAudio = true;
    }
}