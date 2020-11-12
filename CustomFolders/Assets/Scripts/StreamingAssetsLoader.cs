using System;
using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public class StreamingAssetsLoader : MonoBehaviour
    {
        [SerializeField] private ImageData baseIcon;

        private void Start()
        {
            baseIcon.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }
            
            baseIcon.gameObject.SetActive(true);
            
            var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
            print($"Streaming path: {Application.streamingAssetsPath}");
            
            var allFiles = directoryInfo.GetFiles("*.*");

            foreach (var fileInfo in allFiles)
            {
                Debug.Log($"File name: {fileInfo.Name}");
                if (fileInfo.Name.Contains("meta")) continue;

                var imageData = Instantiate(baseIcon, baseIcon.transform.parent);
                var bytes = File.ReadAllBytes(fileInfo.FullName);
                var texture2D = new Texture2D(1, 1);
                texture2D.LoadImage(bytes);
                
                var rect = new Rect(0, 0, texture2D.width, texture2D.height);
                var pivot = new Vector2(0.5f, 0.5f);
                var sprite = Sprite.Create(texture2D, rect, pivot);
                imageData.image.sprite = sprite;
                imageData.text.text = fileInfo.Name;
            }

            baseIcon.gameObject.SetActive(false);
        }
    }
}