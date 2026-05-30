using Voodoo.Sauce.ThermalState.Description;

namespace Voodoo.Sauce.ThermalState
{
	internal class ThermalStateService
	{
		private readonly IThermalStateProvider _thermalStateProvider;

		private readonly IThermalStateDescriptor _thermalStateDescriptor;

		internal ThermalStateService()
		{
		}

		internal int GetThermalState()
		{
			return 0;
		}

		internal (int, string) GetThermalStateWithDescription()
		{
			return default((int, string));
		}
	}
}
