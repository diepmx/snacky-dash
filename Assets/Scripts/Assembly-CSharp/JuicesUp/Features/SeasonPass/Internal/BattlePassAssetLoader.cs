using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal sealed class BattlePassAssetLoader : IBattlePassAssetLoader
	{
		public UniTask PreloadAsset(string key, CancellationToken ct)
		{
			return default(UniTask);
		}

		public UniTask<T> LoadAsset<T>(string key, Transform parent, CancellationToken ct) where T : MonoBehaviour
		{
			return default(UniTask<T>);
		}

		public UniTask<T> LoadScriptableObject<T>(string key, CancellationToken ct) where T : ScriptableObject
		{
			return default(UniTask<T>);
		}

		public void DestroyAllAssetsByKey(string key)
		{
		}

		public void UnloadAllAssetsByKey(string key)
		{
		}

		public void UnloadAllAssets()
		{
		}
	}
}
