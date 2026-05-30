namespace Voodoo.Live.Analytics
{
	public interface ITrackableEvent
	{
		void Track(IBlackboard blackboard);

		bool CanTrack(IBlackboard blackboard);
	}
}
