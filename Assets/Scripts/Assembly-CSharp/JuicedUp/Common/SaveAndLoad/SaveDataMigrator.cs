using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Save;
using JuicedUp.Common.Util;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Boosters.Tutorial;
using JuicedUp.Features.Core.Analytics;

namespace JuicedUp.Common.SaveAndLoad
{
	public class SaveDataMigrator : IAsyncInitializable
	{
		private const int CurrentMigrationVersion = 2;

		private const string MigrationVersionKey = "save_migration_version";

		private const int IngredientTypeCount = 8;

		private const string IngredientPopupPrefix = "Ingredient.PopupShown.";

		private const string LegacyBoosterStarterRewardPrefKey = "BoosterStarterRewardClaimed_";

		private readonly IDataRepository<PlayerProgressData> _progressRepo;

		private readonly IDataRepository<AnalyticsSaveData> _analyticsRepo;

		private readonly IDataRepository<AppRaterData> _appRaterRepo;

		private readonly IDataRepository<BoosterTutorialSaveData> _boosterTutorialRepo;

		public SaveDataMigrator(IDataRepository<PlayerProgressData> progressRepo, IDataRepository<AnalyticsSaveData> analyticsRepo, IDataRepository<AppRaterData> appRaterRepo, IDataRepository<BoosterTutorialSaveData> boosterTutorialRepo)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private static bool RunStep(string name, Action step)
		{
			return false;
		}

		private void MigrateShouldGoDirectlyToLevel()
		{
		}

		private void MigrateIngredientPopups()
		{
		}

		private void MigrateAnalyticsKeys()
		{
		}

		private void MigrateAnalyticsKey<TValue>(string legacyKey, ES3Settings settings, Action<AnalyticsSaveData, TValue> apply)
		{
		}

		private void MigrateAppRaterCount()
		{
		}

		private void MigrateBoosterStarterRewards()
		{
		}
	}
}
