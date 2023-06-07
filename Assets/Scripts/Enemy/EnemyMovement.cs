using Opsive.UltimateCharacterController.Traits;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float attackRange = 1f;

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider capsuleCollider;

    private Coroutine chaseCoroutine;
    private Coroutine attackCoroutine;
    private Action onAttack;

    private float distanceToPlayer;

    public EnemyState defaultState;
    private EnemyState _state;
    public EnemyState state 
    { 
        get
        {
            return _state;
        }
        set
        {
            OnStateChange?.Invoke(_state, value);
            _state = value;
        }
    }

    public delegate void StateChangeEvent(EnemyState oldState, EnemyState newState);
    public StateChangeEvent OnStateChange;

    private void Awake()
    {
        OnStateChange += HandleStateChange;
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < attackRange)
        {
            state = EnemyState.Attack;
        }
        else
        {
            state = EnemyState.Chase;
        }
    }

    public void Init(Transform player, Action onAttack)
    {
        this.player = player;
        this.onAttack = onAttack;

        state = EnemyState.Chase;
    }

    public void Death()
    {
        state = EnemyState.Death;
    }

    private void StartChasing()
    {
        if (chaseCoroutine == null)
        {
            chaseCoroutine = StartCoroutine(ChaseTarget());
        }
        else
        {
            Debug.LogWarning("Enemy is already chasing!");
        }
    }

    private IEnumerator ChaseTarget()
    {
        while (gameObject.activeSelf)
        {
            navMeshAgent.SetDestination(player.position);

            yield return null;
      
        }
    }

    private void HandleStateChange(EnemyState oldState, EnemyState newState)
    {
        if (oldState != newState)
        {
            if (chaseCoroutine != null)
            {
                StopCoroutine(chaseCoroutine);
            }

            switch (newState)
            {
                case EnemyState.Spawn:
                    WaitForInit();
                    break;
                case EnemyState.Idle:
                    animator.SetTrigger("Idle");
                    break;
                case EnemyState.Chase:
                    animator.SetTrigger("Run");
                    StartChasing();
                    break;
                case EnemyState.Attack:
                    animator.SetTrigger("Attack");
                    StopChasing();
                    if (attackCoroutine == null)
                    {
                        attackCoroutine = StartCoroutine(Attack());
                    }
                    break;
                case EnemyState.Death:
                    OnDeath();
                    break;
                default:
                    return;
            }
        }
    }

    private void OnDeath()
    {
        StopChasing();
        animator.enabled = false;
        this.enabled = false;
        capsuleCollider.enabled = false;
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);

        if (distanceToPlayer < attackRange)
        {
            onAttack?.Invoke();
        }

        attackCoroutine = null;
    }

    private void StopChasing()
    {
        if (chaseCoroutine != null)
        {
            StopCoroutine(chaseCoroutine);
            chaseCoroutine = null;
        }
    }

    private void WaitForInit()
    {
        StartCoroutine(WaitInit());
    }

    private IEnumerator WaitInit()
    {
        while (player == null)
        {
            yield return null;
        }

        state = EnemyState.Chase;
    }

    private void OnDisable()
    {
        _state = defaultState;
    }
}
