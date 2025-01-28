using System;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

namespace Behaviours
{
    interface ITarget
    {
        List<IAttacker> Attackers { get; set; }
        bool IsAllowedFocus { get; set; }
        ITarget GetTarget(IAttacker attacker);
        void TargetIsDead();
    }
}
