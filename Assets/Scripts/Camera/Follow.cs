using UnityEngine;

namespace Camera
{
    public class Follow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
    
        private Vector3 _offset;

        private void Awake()
        {
            _offset = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, 0.8f);
        }
    }
}