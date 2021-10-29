using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;

        private readonly int _velocityHash = Animator.StringToHash("Velocity");

        private void Update()
        {
            _animator.SetFloat(_velocityHash,_agent.velocity.magnitude / _agent.speed);
        }
    }
}