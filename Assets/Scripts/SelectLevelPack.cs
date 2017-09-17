using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelPack : MonoBehaviour {
	public Button buttonPrefab;

	void Start() {
		FillGrid ();
	}

	void FillGrid() {
		//PlayerPrefs.DeleteAll ();
		GameObject panel = GameObject.Find ("ButtonsPanel");
		for (int i = 0; i < GameManager.maxPacks; i++) {
			Button button = Instantiate (buttonPrefab);
			button.transform.SetParent (panel.transform,false);
			GameObject buttonUnlocked = button.transform.FindChild ("Unlocked").gameObject;
			GameObject buttonLocked = button.transform.FindChild ("Locked").gameObject;
			GameObject packCompletedImage = button.transform.FindChild ("PackCompleted").gameObject;
			buttonUnlocked.SetActive (false);
			buttonLocked.SetActive (true);
			int t = i+1;
			string packNameStr = "level_pack_" + t;
			string packCompletedStr = packNameStr + "completed";
			string starsCollectedStr = packNameStr + "stars";
			int packUnlocked = 0;
			int packCompleted=0;
			int starsCollected = 0;
			if (!PlayerPrefs.HasKey (packNameStr)) {
				if (i == 0) {
					packUnlocked = 1;
				}
				PlayerPrefs.SetInt (packNameStr, packUnlocked);
				PlayerPrefs.SetInt (packCompletedStr,packCompleted);
				PlayerPrefs.SetInt (starsCollectedStr,starsCollected);
			} else {
				packUnlocked = PlayerPrefs.GetInt (packNameStr);
				packCompleted = PlayerPrefs.GetInt (packCompletedStr);
				starsCollected = PlayerPrefs.GetInt (starsCollectedStr);
			}
			if (packUnlocked == 1) {
				buttonUnlocked.SetActive (true);
				GameObject text = buttonUnlocked.transform.FindChild ("StarsCollectedText").gameObject;
				text.GetComponent<Text> ().text = starsCollected + "/180";
				buttonLocked.SetActive (false);
			}
			if (packUnlocked == 0) {
				buttonUnlocked.SetActive (false);
				buttonLocked.SetActive (true);
			}
			if (packCompleted == 1) {
				packCompletedImage.SetActive (true);
			}
			if (packCompleted == 0) {
				packCompletedImage.SetActive (false);
			}
			GameObject packName = button.transform.FindChild ("PackName").gameObject;
			packName.GetComponent<Text> ().text = "Level Pack "+t.ToString ();
			// if (packUnlocked == 1) {
				button.onClick.AddListener (() => LoadLevel (t));
			// }
		}
	}

	void LoadLevel(int level) {
		GameManager.currentPack = level;
		SceneManager.LoadScene ("SelectLevel",LoadSceneMode.Single);
	}
}
