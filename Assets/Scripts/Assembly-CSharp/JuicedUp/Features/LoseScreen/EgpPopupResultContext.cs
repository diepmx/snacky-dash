using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.LoseScreen
{
	internal struct EgpPopupResultContext
	{
		public EgpPopupState State;

		public UniTaskCompletionSource TaskCompletionSource;

		public EgpPopupResultContext(EgpPopupState state, UniTaskCompletionSource taskCompletionSource = null)
		{
			State = default(EgpPopupState);
			TaskCompletionSource = null;
		}
	}
}
