using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;

    /// <summary>
    /// Takes in a texture and draws it to the map texture
    /// </summary>
    /// <param name="noiseMap">The noise Map to draw on the texture</param>
    public void DrawTexture(Texture2D texture)
    {
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
