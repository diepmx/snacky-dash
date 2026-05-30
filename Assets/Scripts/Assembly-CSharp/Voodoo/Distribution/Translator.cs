using System;
using TMPro;
using UnityEngine;

namespace Voodoo.Distribution
{
	[Serializable]
	[RequireComponent(typeof(TMP_Text))]
	[DisallowMultipleComponent]
	public class Translator : MonoBehaviour
	{
		public string key;

		[SerializeField]
		private TMP_Text _textMesh;

		private FontSnapshot _fontSnapshot;

		private string[] _args;

		private TMP_Text TextMesh => null;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void SetArgs(params string[] args)
		{
		}

		public virtual void Translate(string language)
		{
		}

		private void Translate()
		{
		}

		private void UpdateRightToLeft()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
