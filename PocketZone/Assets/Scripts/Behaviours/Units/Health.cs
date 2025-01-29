using Data;

namespace Behaviours
{
    struct HealthStruct
    {
        public float HealthRate;
        public float CurrentHealth;
        public float MaxHealth;

        public HealthStruct(float healthRate, float currentHealth, float maxHealth)
        {
            HealthRate = healthRate;
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }
    }
    sealed class Health
    {
        private float _currentHealth;

        private UnitData _unitData;
        private UnitEvents _unitEvents;


        public Health(UnitData unitData, UnitEvents unitEvents)
        {
            _unitData = unitData;
            _unitEvents = unitEvents;
            _currentHealth = _unitData.Health;
        }

        public void TakeDamage(float damage)
        {
            if (_currentHealth > 0)
            {
                var damagedHealth = _currentHealth - damage;
                if (damagedHealth < 0)
                {
                    ChangeHealthValue(0);
                    _unitEvents.HealthIsEnd?.Invoke();
                }
                else
                {
                    ChangeHealthValue(damagedHealth);
                }
            }
        }
        public void TakeHeal(float heal)
        {
            if (_currentHealth < _unitData.Health)
            {
                var healedHealth = _currentHealth + heal;
                if (healedHealth <= _unitData.Health)
                {
                    ChangeHealthValue(healedHealth);
                }
                else
                {
                    ChangeHealthValue(_unitData.Health);
                }
            }
        }
        public void ResetHealth()
        {
            ChangeHealthValue(_unitData.Health);
        }
        public float GetHealthRate()
        {
            if(_unitData.Health == 0) { return 0; }
            var healthRate = _currentHealth / _unitData.Health;
            return healthRate;
        }
        public float GetMaxHealth()
        {
            var maxHealth = _unitData.Health;
            return maxHealth;
        }

        private void ChangeHealthValue(float value)
        {
            _currentHealth = value;
            _unitEvents.HealthChanged?.Invoke(new HealthStruct
                (GetHealthRate(), _currentHealth, _unitData.Health));
        }
    }
}
