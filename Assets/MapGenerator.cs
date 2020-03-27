﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octave;
    [Range(0,1)]
    public float persistance;
    public float lacurnarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    /// <summary>
    /// Method makes the calls to generate noise map and display the noise map on the texture.
    /// </summary>
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octave, persistance, lacurnarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }

    /// <summary>
    /// Forces the public variables to be within the defined range
    /// </summary>
    private void OnValidate()
    {
        if(mapWidth < 1)
        {
            mapWidth = 1;
        }
        if(mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacurnarity < 1)
        {
            lacurnarity = 1;
        }
        if (octave < 0)
        {
            octave = 0;
        }
    }
}
