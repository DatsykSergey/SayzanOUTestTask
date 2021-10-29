using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int _velocityHash = Animator.StringToHash("Velocity");
        private readonly int _jumpHash = Animator.StringToHash("Jump");
        private readonly int _dieHash = Animator.StringToHash("Die");

        public void UpdateVelocity(float velocity)
        {
            _animator.SetFloat(_velocityHash, velocity);
        }

        public void Jump() => 
            _animator.SetTrigger(_jumpHash);
        
        public void Die() => 
            _animator.SetTrigger(_dieHash);
    }
}