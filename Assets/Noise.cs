﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    
    /// <summary>
    /// Generates a noise map using perlin noise
    /// </summary>
    /// <param name="mapWidth">Width of the final map</param>
    /// <param name="MapHeight">Height of the final map</param>
    /// <param name="seed">Seed value to generate a specific map</param>
    /// <param name="scale"></param>
    /// <param name="octaves"></param>
    /// <param name="persistance"></param>
    /// <param name="lacunarity"></param>
    /// <param name="offset"></param>
    /// <returns>Returns the noise map as a float array</returns>
    public static float[,] GenerateNoiseMap(int mapWidth, int MapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, MapHeight];
        System.Random prng;
        if (seed != 0)
        {
            prng = new System.Random(seed);
        }
        else
        {
            prng = new System.Random();
        }
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if(scale <= 0)
        {
            scale = 0.0001f;
        }
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHeight = MapHeight / 2f;

        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[x, y] = noiseHeight;
            }
        }

        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        return noiseMap;
    }
}
