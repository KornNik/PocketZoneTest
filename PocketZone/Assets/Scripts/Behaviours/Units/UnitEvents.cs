using System;

namespace Behaviours
{
    class UnitEvents
    {
        public Action GettingHit;
        public Action<bool> Moving;
        public Action Died;
        public Action Revived;
        public Action HealthIsEnd;
        public Action Attacking;
        public Action<HealthStruct> HealthChanged;
    }
}
