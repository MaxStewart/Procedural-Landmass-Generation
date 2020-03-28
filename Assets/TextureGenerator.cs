using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{

    /// <summary>
    /// Takes in a color map and creates a 2D map texture with region colors
    /// </summary>
    /// <param name="colorMap">The color map to draw the Texture from</param>
    /// <param name="width">Width of Map</param>
    /// <param name="height">Height of Map</param>
    /// <returns>Returns the 2D color map texture</returns>
    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point; // Fix blury texture
        texture.wrapMode = TextureWrapMode.Clamp; // So map wont wrap round to other side
        texture.SetPixels(colorMap);
        texture.Apply();
        return texture;
    }

    /// <summary>
    /// Takes in a height map array and creates a 2D map texture
    /// </summary>
    /// <param name="heightMap">The height map to create the map from</param>
    /// <returns>Returns a 2D color map texture</returns>
    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        Color[] colorMap = new Color[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }

        return TextureFromColorMap(colorMap, width, height);
    }
}
