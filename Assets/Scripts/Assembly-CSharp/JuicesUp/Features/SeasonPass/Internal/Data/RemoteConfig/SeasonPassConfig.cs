using System;

namespace JuicesUp.Features.SeasonPass.Internal.Data.RemoteConfig
{
	[Serializable]
	internal class SeasonPassConfig
	{
		public bool IsEnabled;

		public int UnlockLevel;

		public int TokensEasy;

		public int TokensHard;

		public int TokensVeryHard;

		public bool MaxLivesPerkEnabled;

		public int MaxLivesPerkValue;

		public bool GoldenConveyorPerkEnabled;

		public int LuckyLoopRequiredTokens;

		public string LuckyLoopDefinitionJson;

		public override string ToString()
		{
			return null;
		}
	}
}
