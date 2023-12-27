using UnityEngine.Tilemaps;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private UnityEvent _jumpedUp;
        [SerializeField] private float _height;

        private bool _isJumping;
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
                _rigidBody.AddForce(transform.up * _height, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out TilemapCollider2D _))
            {
                _isJumping = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out TilemapCollider2D _))
            {
                _isJumping = true;
                _jumpedUp.Invoke();
            }
        }
    }
}