using System;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AttackPlayer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _maxDistanceToAttack = 1f;
        
        private PlayerHealth _target;
        public Transform Target => _target.transform;
        public Vector3 TargetPosition => _target.transform.position;

        public void Initialize(PlayerHealth player)
        {
            _target = player;
            _target.Death += PlayerDeath;
        }
        
        private void OnDestroy()
        {
            _target.Death -= PlayerDeath;
        }

        private void PlayerDeath()
        {
            enabled = false;
            _agent.destination = transform.position;
        }

        private void Update()
        {
            if (CanTouchTarget())
                _agent.destination = TargetPosition;
            else 
            {
                _agent.destination = transform.position;
                _target.Attack();
                enabled = false;
            }
        }

        private bool CanTouchTarget() => 
            Vector3.Distance(transform.position, TargetPosition) > _maxDistanceToAttack;
    }
}