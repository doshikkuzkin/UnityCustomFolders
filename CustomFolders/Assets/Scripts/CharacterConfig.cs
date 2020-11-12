using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private string hairMaterial;
        [SerializeField] private string prefabName;

        public string HairMaterial => hairMaterial;
        public string PrefabName => prefabName;
    }
}