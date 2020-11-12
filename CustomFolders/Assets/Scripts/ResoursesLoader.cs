using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResoursesLoader : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRendere;
        [SerializeField] private Transform prefabRoot;
        
        [SerializeField] private string[] icons = new string[3];

        private GameObject obj;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetupIcon(icons[0]);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetupIcon(icons[1]);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetupIcon(icons[2]);
            }
        }

        private void SetupIcon(string icon)
        {
            var config = Resources.Load<IconInfo>($"Configs/{icon}");
            var sprite = Resources.Load<Sprite>($"Icons/{config.IconName}");
            var prefab = Resources.Load<GameObject>($"Prefabs/{config.PrefabName}");

            if (obj != null)
            {
                Destroy(obj);
            }

            obj = Instantiate(prefab, prefabRoot);
            spriteRendere.sprite = sprite;
        }
    }
}