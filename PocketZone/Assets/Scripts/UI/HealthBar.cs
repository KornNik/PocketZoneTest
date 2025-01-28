using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    sealed class  HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        private void Awake()
        {
            SetHealthToDefault();
        }
        private void OnEnable()
        {
            
        }
        private void OnDisable()
        {
            
        }

        private void OnHealthChanged(float healthRate)
        {
            _healthBar.fillAmount = healthRate;
        }
        private void SetHealthToDefault()
        {
            _healthBar.fillAmount = 1f;
        }
    }
}
