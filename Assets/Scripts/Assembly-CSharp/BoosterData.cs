using System;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

[Serializable]
public class BoosterData
{
	public string booster_name;

	public BoosterId boosterType;

	public int booster_Price;

	public int numberForPrice;

	public Sprite booster_sprite;

	public Sprite booster_locked_sprite;

	public Sprite booster_inactive_sprite;

	public string booster_info;

	public int levelToUnlock;

	[Tooltip("When the pre-use animation should gate this booster. OnActivation gates the activation event (used by boosters that fire instantly, e.g. Shrink/Shuffle). OnFocusOpen gates the focus-mode opening (used by boosters that open a focus UI, e.g. Tunnel/Cannon). None disables pre-use animation for this booster.")]
	public BoosterPreUseAnimationGate preUseAnimationGate;
}
