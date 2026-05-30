using UniRx;

namespace JuicedUp.Common.Network
{
	public interface INetworkConnectionProvider
	{
		ReactiveProperty<bool> IsOnline { get; }
	}
}
