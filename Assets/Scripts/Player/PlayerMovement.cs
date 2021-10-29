using Input;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private float _maxVelocity = 1f;
        
        private Transform _camera;
        private IPlayerInput _input;
        private bool _pressedJoystick;
        private Vector3 _desiredVelocity;

        private float InterpolateVelocity =>
            _rigidbody.velocity.magnitude / _maxVelocity;

        public void Initialize(IPlayerInput input, Transform camera)
        {
            _input = input;
            _camera = camera;
        }

        public void TurnOff()
        {
            enabled = false;
            _rigidbody.velocity = Vector3.zero;
        }

        private void Update()
        {
            _desiredVelocity = CalculateMoveDirection() * _maxVelocity;
            
            _animator.UpdateVelocity(InterpolateVelocity);

            if (_input.IsPressed && _pressedJoystick == false)
            {
                _pressedJoystick = true;
            }
            
            if (_input.IsPressed == false && _pressedJoystick)
            {
                _pressedJoystick = false;
                _desiredVelocity = Vector3.zero;
                _animator.Jump();
            }
        }

        private void FixedUpdate()
        {
            if (_desiredVelocity.magnitude != 0f)
            {
                UpdateRotation();
                UpdateMoveVelocity();
            }
        }

        private Vector3 CalculateMoveDirection()
        {
            Vector3 moveDirection = new Vector3(_input.Horizontal, 0f, _input.Vertical);
            Vector3 cameraProject = Vector3.ProjectOnPlane(_camera.forward, Vector3.up);
            moveDirection = Quaternion.LookRotation(cameraProject, Vector3.up) * moveDirection;
            
            return moveDirection;
        }

        private void UpdateRotation() => 
            transform.forward = _desiredVelocity.normalized;

        private void UpdateMoveVelocity() => 
            _rigidbody.velocity = _desiredVelocity;
    }
}