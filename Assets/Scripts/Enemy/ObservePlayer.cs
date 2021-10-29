using System;
using UnityEngine;

namespace Enemy
{
    public class ObservePlayer : MonoBehaviour
    {
        [SerializeField] private AttackPlayer _attack;
        [SerializeField] private float _radius = 1f;
        [SerializeField] private float _sphereCastRadius;

        private void Awake()
        {
            _attack.enabled = false;
        }

        private void Update()
        {
            if (InAttackRange())
            {
                Ray ray = RayToPlayer();

                if (Physics.SphereCast(ray, _sphereCastRadius, out RaycastHit hitInfo))
                {
                    if(hitInfo.transform == _attack.Target)
                    {
                        _attack.enabled = true;
                        enabled = false;
                    }
                }
            }
        }

        private bool InAttackRange() => 
            Vector3.Distance(transform.position, _attack.TargetPosition) <= _radius;

        private Ray RayToPlayer()
        {
            Vector3 directionToPlayer = (_attack.TargetPosition - transform.position).normalized;
            Ray ray = new Ray(transform.position, directionToPlayer);
            return ray;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}