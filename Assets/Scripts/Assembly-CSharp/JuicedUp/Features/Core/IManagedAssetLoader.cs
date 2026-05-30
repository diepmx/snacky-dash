using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public interface IManagedAssetLoader
	{
		UniTask PreloadAsset(string assetKey, CancellationToken token);

		UniTask<TComponent> LoadAsset<TComponent>(string assetKey, Transform parent, CancellationToken token) where TComponent : MonoBehaviour;

		UniTask<TScriptable> LoadScriptableObject<TScriptable>(string assetKey, CancellationToken token) where TScriptable : ScriptableObject;

		void DestroyAllAssetsByKey(string assetKey);

		void UnloadAllAssetsByKey(string assetKey);
	}
}
