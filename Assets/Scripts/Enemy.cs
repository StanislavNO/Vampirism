using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private DeadBody _deadBody;

        public void Die()
        {
            Instantiate(_deadBody, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}