using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public interface IAssetLoader
	{
		UniTask<GameObject> LoadPrefabAsync(string key, CancellationToken cancellationToken);

		GameObject LoadPrefab(string key);

		UniTask<T> LoadAssetAsync<T>(string key, CancellationToken cancellationToken) where T : Object;

		T LoadAsset<T>(string key) where T : Object;

		void UnloadAsset(Object asset);
	}
}
