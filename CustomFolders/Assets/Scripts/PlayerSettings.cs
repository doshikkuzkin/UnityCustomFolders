using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerSettings : MonoBehaviour
    {
        [SerializeField] private Button femaleButton;
        [SerializeField] private Button maleButton;

        [SerializeField] private Button blondButton;
        [SerializeField] private Button darkButton;

        [SerializeField] private Button blueButton;
        [SerializeField] private Button greenButton;
        [SerializeField] private Button redButton;
        
        [SerializeField] private Button blackButton;
        [SerializeField] private Button brownButton;

        [SerializeField] private GameObject hairPanel;
        [SerializeField] private GameObject clothsPanel;
        [SerializeField] private GameObject legsPanel;

        [SerializeField] private Transform root;
        private GameObject obj;
        private CharacterConfig characterConfig;

        [SerializeField] private string[] characters = new string[2];

        private void Start()
        {
            hairPanel.SetActive(false);
            clothsPanel.SetActive(false);
            legsPanel.SetActive(false);
            
            femaleButton.onClick.AddListener(() => ShowModel(characters[0]));
            maleButton.onClick.AddListener(() => ShowModel(characters[1]));
            
            blondButton.onClick.AddListener(() => ChangeColor("Blond", "Hair"));
            darkButton.onClick.AddListener(() => ChangeColor("Dark", "Hair"));
            
            blueButton.onClick.AddListener(() => ChangeColor("Blue", "Torso"));
            redButton.onClick.AddListener(() => ChangeColor("Red", "Torso"));
            greenButton.onClick.AddListener(() => ChangeColor("Green", "Torso"));
            
            blackButton.onClick.AddListener(() => ChangeColor("Black", "Legs"));
            brownButton.onClick.AddListener(() => ChangeColor("Brown", "Legs"));
        }

        private void ShowModel(string characterName)
        {
            if (hairPanel.activeSelf == false || clothsPanel.activeSelf == false || legsPanel.activeSelf == false)
            {
                hairPanel.SetActive(true);
                clothsPanel.SetActive(true);
                legsPanel.SetActive(true);
            }
            
            LoadCharacter(characterName);
            ChangeColor("Blond", "Hair");
            ChangeColor("Blue", "Torso");
            ChangeColor("Black", "Legs");
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
            characterConfig = config;
        }

        private void ChangeColor(string color, string folder)
        {
            var material = Resources.Load<Material>($"Materials/{folder}/{characterConfig.HairMaterial}");
            var directory = Application.streamingAssetsPath;
            var characterFolder = $"Colors/{characterConfig.PrefabName}/{folder}";
            var path = Path.Combine(directory, characterFolder);
            var file = Path.Combine(path, $"{color}.tga");
            
            var texture2D = TGALoader.LoadTGA(file);
            
            material.mainTexture = texture2D;
        }
    }
}