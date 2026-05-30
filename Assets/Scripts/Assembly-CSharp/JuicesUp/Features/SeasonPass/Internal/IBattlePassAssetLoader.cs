using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal interface IBattlePassAssetLoader
	{
		UniTask PreloadAsset(string key, CancellationToken ct);

		UniTask<T> LoadAsset<T>(string key, Transform parent, CancellationToken ct) where T : MonoBehaviour;

		UniTask<T> LoadScriptableObject<T>(string key, CancellationToken ct) where T : ScriptableObject;

		void DestroyAllAssetsByKey(string key);

		void UnloadAllAssetsByKey(string key);

		void UnloadAllAssets();
	}
}
