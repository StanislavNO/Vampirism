using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Vampirism : MonoBehaviour
    {
        [SerializeField] private Health _player;
        [SerializeField] private int _vampirismPoints;
        [SerializeField] private float _steepAttack = 1;
        [SerializeField] private float _attackDuration = 6;

        private List<Health> _enemies;
        private bool _isWork;
        private float _attackTime;
        private float _timeCounter;

        private void OnEnable()
        {
            _enemies = new();
            _isWork = true;
            _attackTime = 0;
            _timeCounter = 0;
        }

        private void Update()
        {
            if (_isWork)
            {
                _timeCounter += Time.deltaTime;
                _attackTime += Time.deltaTime;

                if (_timeCounter >= _steepAttack)
                {
                    _timeCounter -= _timeCounter;

                    for (int i = 0; i < _enemies.Count; i++)
                    {
                        _player.AddPoints(_vampirismPoints);
                        _enemies[i].DeletePoints(_vampirismPoints);
                    }
                }

                if (_attackTime >= _attackDuration)
                {
                    _isWork = false;
                    gameObject.SetActive(false);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
                _enemies.Add(enemy.GetComponent<Health>());
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
                DeleteEnemy(enemy);
        }

        public void DeleteEnemy(Enemy enemy)
        {
            Health enemyHealth = enemy.GetComponent<Health>();

            _enemies.Remove(enemyHealth);
        }
    }
}