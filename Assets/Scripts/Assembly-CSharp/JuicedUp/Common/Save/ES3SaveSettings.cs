using UnityEngine;

namespace JuicedUp.Common.Save
{
	[CreateAssetMenu(fileName = "ES3SaveSettings", menuName = "JuicedUp/Save/ES3 Save Settings")]
	public class ES3SaveSettings : ScriptableObject
	{
		[SerializeField]
		private string _filePath;

		[SerializeField]
		private ES3.EncryptionType _encryptionType;

		[SerializeField]
		private string _encryptionPassword;

		public string FilePath => null;

		public ES3.EncryptionType EncryptionType => default(ES3.EncryptionType);

		public string EncryptionPassword => null;
	}
}
