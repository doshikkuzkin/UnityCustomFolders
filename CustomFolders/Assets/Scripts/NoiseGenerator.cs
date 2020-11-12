using System.IO;
using UnityEditor;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    [SerializeField] private int width = 512;
    [SerializeField] private int height = 512;
    
    [SerializeField] private float xOrigin;
    [SerializeField] private float yOrigin;

    [SerializeField] private float scale;

    private Texture2D noiseTexture;
    private Color[] pixels;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        noiseTexture = new Texture2D(width, height);
        pixels = new Color[noiseTexture.width * noiseTexture.height];
        _renderer.material.mainTexture = noiseTexture;
    }

    private void Update()
    {
        CalculateNoise();
    }

    private void CalculateNoise()
    {
        var y = 0f;
        while (y < noiseTexture.height)
        {
            var x = 0f;
            while (x < noiseTexture.width)
            {
                var xCoord = xOrigin + x / noiseTexture.width * scale; // 0 - 1
                var yCoord = yOrigin + y / noiseTexture.height * scale; // 0 - 1

                var smpl = Mathf.PerlinNoise(xCoord, yCoord);
                
                pixels[(int)y * noiseTexture.width + (int)x] = new Color(smpl, smpl, smpl);
                x++;
            }

            y++;
        }
        
        noiseTexture.SetPixels(pixels);
        noiseTexture.Apply();
    }

    [ContextMenu("Save")]
    private void SaveTexture()
    {
        var bytes = noiseTexture.EncodeToPNG();
        var path = Path.Combine(Application.dataPath, "Textures");
        path = Path.Combine(path, "tex.png");

        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
        
        File.WriteAllBytes(path, bytes);
        AssetDatabase.Refresh();
    }
}
