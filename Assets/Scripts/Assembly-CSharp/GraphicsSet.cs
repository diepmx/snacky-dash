using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewGraphicsSet", menuName = "Game/Graphics Set")]
public class GraphicsSet : ScriptableObject
{
	[FormerlySerializedAs("pillMaster")]
	[Header("Pill Prefab Reference")]
	public PillController _pillController;

	public GameObject snakeHead;

	[Header("All Graphic Variants")]
	public List<GraphicData> graphicDatas;

	private Dictionary<PillKind, GraphicData> lookupDict;

	private void OnEnable()
	{
	}

	public GraphicData GetGraphicData(PillKind pillKind)
	{
		return null;
	}

	public Material GetMaterialCrate(PillKind pillKind)
	{
		return null;
	}

	public Material GetMaterialPillInSnake(PillKind pillKind)
	{
		return null;
	}
}
