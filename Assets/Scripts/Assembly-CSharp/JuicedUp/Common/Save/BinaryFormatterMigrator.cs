using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Common.Save
{
	public static class BinaryFormatterMigrator
	{
		private sealed class LegacyTypeBinder : SerializationBinder
		{
			private readonly string _legacyTypeName;

			private readonly Type _targetType;

			public LegacyTypeBinder(string legacyTypeName, Type targetType)
			{
			}

			public override Type BindToType(string assemblyName, string typeName)
			{
				return null;
			}
		}

		private const string LegacyCurrencyPath = "/money_data_0_6.dat";

		private const string LegacyMoneyDataPath = "/moneydata.dat";

		private const string LegacyPlayerDataPath = "/playerdata.dat";

		public static void MigrateIfNeeded(IDataRepository<PlayerProgressData> repository)
		{
		}

		private static void MigratePlayerProgress(IDataRepository<PlayerProgressData> repository)
		{
		}

		public static void MigrateCurrency(Dictionary<CurrencyId, int> balances)
		{
		}

		private static void DeleteLegacyMoneyData()
		{
		}

		private static void DeleteFile(string path)
		{
		}
	}
}
