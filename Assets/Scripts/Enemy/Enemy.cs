using Opsive.UltimateCharacterController.Traits;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyMovement movement;
    public NavMeshAgent agent;
    public float attackStrength = 10;

    private CharacterHealth playerHealth;

    internal void Init(Transform player)
    {
        playerHealth = player.GetComponent<CharacterHealth>();

        movement.Init(player, Attack);
    }

    public void Death(Vector3 position, Vector3 force, GameObject attacker)
    {
        movement.Death();
        agent.enabled = false;
        GameUIManager.Instance.IncreaseKillCount();
    }

    private void Attack()
    {
        playerHealth.Damage(attackStrength);
    }
}
