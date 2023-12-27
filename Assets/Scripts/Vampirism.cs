using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Vampirism : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDuration = 6;

        private bool _isWork = false;
        private float _steepAttack = 1;
        private int _countEnemy;
        private int _countAttack = 1;

        public int Damage => _damage;

        private void OnEnable()
        {
            _isWork = false;
            StartCoroutine(StartAbility());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy _))
            {
                _countEnemy++;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy _))
            {
                _countEnemy--;
            }
        }

        private IEnumerator StartAbility()
        {
            WaitForSecondsRealtime delay = new(_steepAttack);
            int vampirePoints = 1;

            _isWork = true;

            while (_isWork)
            {
                _countAttack++;

                _health.AddPoint(vampirePoints * _countEnemy);

                yield return delay;

                if (_countAttack >= _attackDuration)
                {
                    _countAttack -= _countAttack;
                    _isWork = false;
                }
            }

            gameObject.SetActive(false);
        }
    }
}