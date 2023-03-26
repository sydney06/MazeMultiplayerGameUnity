using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float playerChasingRange;
    [SerializeField] private float playerCatchRange;
    [SerializeField] private Animator enemyAnimator;

    private Transform playerTarget;

    private bool isDone = false;
    private bool canBeginOp = false;

    private NavMeshAgent enemy;

    void Start()
    {
        StartCoroutine(DelayedInstance());
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {


        if (canBeginOp)
        {
            if (IsInChaseRange())
            {
                enemy.SetDestination(playerTarget.position);
                enemyAnimator.Play("Run");
            }

            if (!IsInChaseRange())
            {
                enemy.SetDestination(enemy.transform.position);
                enemyAnimator.Play("Idle");
            }

            if (IsInCatchRange())
            {
                if (!isDone)
                {
                    //caught player
                    playerTarget.gameObject.GetComponent<PlayerMovement>().isPlayerCaught = true;
                    enemyAnimator.Play("Idle");
                    isDone = true;
                }
            } 
        }
    }

    IEnumerator DelayedInstance()
    {
        yield return new WaitForSeconds(2);
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        canBeginOp = true;
    }

    protected bool IsInChaseRange()
    {
        float playerDistanceSqr = (playerTarget.position - transform.position).sqrMagnitude;

        return playerDistanceSqr <= playerChasingRange * playerChasingRange;
    }

    protected bool IsInCatchRange()
    {
        float playerDistanceSqr = (playerTarget.transform.position - transform.position).sqrMagnitude;

        return playerDistanceSqr <= playerCatchRange * playerCatchRange;
    }
}
