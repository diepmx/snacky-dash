using UnityEngine.Scripting;
using Voodoo.Sauce.Debugger;

[Preserve]
public class AdnDebuggerScreen : CustomDebugger
{
	private bool _isTestAdsEnabled;

	private bool _isDebugModeEnabled;

	public override bool ReSetupScreenOnShown => false;

	public override string GetTitle()
	{
		return null;
	}

	public override int GetOrderIndex()
	{
		return 0;
	}

	public override void SetupScreen(Screen screen)
	{
	}
}
