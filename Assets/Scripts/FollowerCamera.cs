using UnityEngine;

namespace Assets.Scripts
{
    public class FollowerCamera : MonoBehaviour
    {
        [SerializeField] private Player _target;
        [SerializeField][Range(0, 4)] private float _speed;

        private Vector3 _cameraOffset = new Vector3(0, 2, -10);

        private void LateUpdate()
        {
            Vector3 newPosition = _target.transform.position;
            newPosition += _cameraOffset;

            transform.position = Vector3.MoveTowards(
                transform.position,
                newPosition,
                _speed * Time.deltaTime);
        }
    }
}