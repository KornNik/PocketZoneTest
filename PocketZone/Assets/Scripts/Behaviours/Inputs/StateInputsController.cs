using Helpers;
using Helpers.Extensions;

namespace Behaviours
{
    abstract class StateInputsController : IInitialization
    {
        protected UnitController _controller;
        protected InputActions _inputs;

        protected StateInputsController()
        {
            _inputs = Services.Instance.Inputs.ServicesObject;
        }

        public void Initialization()
        {
            _controller = Services.Instance.PlayerController.ServicesObject;
        }

        public abstract void UpdateInputs();
    }
}
