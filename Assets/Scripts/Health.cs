using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private UnityEvent _livesAreOver;
        [SerializeField] private UnityEvent _healthChanged;

        [SerializeField] private int _point;
        [SerializeField] private int _maxPoint;

        private uint _minPoint = uint.MinValue;

        public int MaxPoint { get; private set; }
        public int LivePoint { get; private set; }

        private void Awake()
        {
            MaxPoint = _maxPoint;
            LivePoint = _point;
        }

        public void AddPoints(int point)
        {
            if (point > _minPoint)
            {
                if (LivePoint + point > MaxPoint)
                    LivePoint = MaxPoint;
                else
                    LivePoint += point;

                _healthChanged.Invoke();
            }
        }

        public void DeletePoints(int point)
        {
            if (point > _minPoint)
                LivePoint -= point;

            if (LivePoint <= _minPoint)
                _livesAreOver.Invoke();

            _healthChanged.Invoke();
        }
    }
}