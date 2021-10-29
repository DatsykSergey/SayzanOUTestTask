using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _jumpSpeed = 1f;
        
        public void StartJump()
        {
            _rigidbody.velocity = transform.forward * _jumpSpeed;
        }

        public void EndJump()
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}