using System.Threading.Tasks;
using Controllers;

namespace Behaviours
{
    sealed class InputItializerAsync : IInitializationAsync
    {
        public async Task InitializationAsync()
        {
            var inputController = new InputLoader();

            await Task.Yield();
        }
    }
}
