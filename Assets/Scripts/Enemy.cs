using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Death _death;
        [SerializeField] private Health _health;

        private bool _isWork = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Vampirism attacker))
            {
                _isWork = true;
                StartCoroutine(SetDamage(attacker.Damage));
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Vampirism attacker))
            {
                _isWork = false;
            }
        }

        public void Die()
        {
            Instantiate(_death, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        private IEnumerator SetDamage(int damage)
        {
            WaitForSecondsRealtime delay = new(1f);

            while(_isWork)
            {
                _health.SetDamage(damage);
                yield return delay;
            }
        }
    }
}