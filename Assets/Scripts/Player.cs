using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Vampirism _vampireAura;

        private void Awake()
        {
            _vampireAura.gameObject.SetActive(false);
        }
    }
}