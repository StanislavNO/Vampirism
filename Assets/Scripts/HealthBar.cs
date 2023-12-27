using UnityEngine;

namespace Assets.Scripts
{
    public class HealthBar : Bar
    {
        [SerializeField] private Health _health;

        private void Start()
        {
            RenderedHealth();
        }

        public void RenderedHealth()
        {
            OnValueChanged(_health.LivePoint, _health.MaxPoint);
        }
    }
}