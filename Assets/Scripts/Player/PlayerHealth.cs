using System;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private PlayerMovement _movement;
        
        public event Action Death;
        public bool IsLive { get; private set; }

        private void Awake()
        {
            IsLive = true;
        }

        public void Attack()
        {
            IsLive = false;
            Death?.Invoke();
            _animator.Die();
            _movement.TurnOff();
        }
        
    }
}