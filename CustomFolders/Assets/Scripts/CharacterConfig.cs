using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private string character;
        [SerializeField] private string prefabName;

        public string Character => character;
        public string PrefabName => prefabName;
    }
}