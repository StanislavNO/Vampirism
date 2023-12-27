using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        private const string HorizontalInput = "Horizontal";

        [SerializeField] private float _speed;

        private Rigidbody2D _rigidBody;

        private float _inputX;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _inputX = Input.GetAxis(HorizontalInput);
        }

        private void FixedUpdate()
        {
            Vector2 movement = new Vector2(_inputX * _speed, _rigidBody.velocity.y);

            _rigidBody.velocity = movement;
        }
    }
}