using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MagnetGame.Controllers
{
    public class LevelControl : MonoBehaviour
    {
        int _levelIndex;
        List<Button> _levelButtons;

        private void Start()
        {
            _levelButtons = new List<Button>();
            foreach (Transform a in transform) _levelButtons.Add(a.gameObject.GetComponent<Button>());
            if (PlayerPrefs.GetInt("Level") == 0) PlayerPrefs.SetInt("Level", 1);
            LevelLock();

        }
        void LevelLock()
        {
            int levelIndex = PlayerPrefs.GetInt("Level");
            for (int i = levelIndex; i<this.transform.childCount;i++)
            {
                _levelButtons[i].interactable = false;
            }
        }
    }
}