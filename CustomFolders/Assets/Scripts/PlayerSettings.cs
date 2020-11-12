using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerSettings : MonoBehaviour
    {
        [SerializeField] private Button femaleButton;
        [SerializeField] private Button maleButton;

        [SerializeField] private GameObject hairPanel;
        [SerializeField] private GameObject clothsPanel;

        [SerializeField] private Transform root;
        private GameObject obj;

        [SerializeField] private string[] characters = new string[2];

        private void Start()
        {
            hairPanel.SetActive(false);
            clothsPanel.SetActive(false);
            
            femaleButton.onClick.AddListener(() => ShowModel(characters[0]));
            maleButton.onClick.AddListener(() => ShowModel(characters[1]));
        }

        private void ShowModel(string characterName)
        {
            if (hairPanel.activeSelf == false || clothsPanel.activeSelf == false)
            {
                hairPanel.SetActive(true);
                clothsPanel.SetActive(true);
            }
            
            LoadCharacter(characterName);
        }

        private void LoadCharacter(string characterName)
        {
            var config = Resources.Load<CharacterConfig>($"Configs/{characterName}");
            var prefab = Resources.Load<GameObject>($"Characters/{config.PrefabName}");
            
            if (obj != null)
            {
                Destroy(obj);
            }
            
            obj = Instantiate(prefab, root);
        }
    }
}