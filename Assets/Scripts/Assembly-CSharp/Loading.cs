using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using EasyButtons;
using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;
using VContainer;

public class Loading : IAsyncInitializable, IDisposable
{
	public static Loading instance;

	public int currentLevel;

	private IDataRepository<PlayerProgressData> _repository;

	private ILevelProvider _levelProvider;

	public bool ShouldGoDirectlyToLevel => false;

	[Inject]
	public void Construct(IDataRepository<PlayerProgressData> repository, ILevelProvider levelProvider)
	{
	}

	public int GetCurrentLevel()
	{
		return 0;
	}

	public bool IsInLoop()
	{
		return false;
	}

	public UniTask InitAsync(CancellationToken cancellationToken)
	{
		return default(UniTask);
	}

	public void SaveData()
	{
	}

	public void SetShouldGoDirectlyToLevel()
	{
	}

	[Button]
	public void ResetGame()
	{
	}

	private void Load()
	{
	}

	public void Dispose()
	{
	}
}
