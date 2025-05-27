using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using System;


public class TerrainGen : MonoBehaviour
{
    public float seed;
    public float scale = 100;
    private Terrain terrain;
    private TerrainData terrainData;
    private int terrainRes;
    private float[,] map;
    private float[,,] textureMap;
    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrainData = terrain.terrainData;
        terrainRes = terrainData.heightmapResolution;
        map = new float[terrainRes, terrainRes];
        GenerateTerrainData();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GenerateTerrainData();
        }
    }
    void GenerateTerrainData()
    {
        seed = Random.Range(-10000, 10000);
        for (int z = 0; z < terrainRes; z++)
        {
            for (int x = 0; x < terrainRes; x++)
            {
                var px = (x + seed) / scale;
                var pz = (z + seed) / scale;
                //map[x, z] = (noise.snoise(new float2(px, pz)) + 1) / 2;
                //map[x, z] = Mathf.PerlinNoise(px, pz) * 4 - 1; w scale 50
                map[x, z] = Mathf.PerlinNoise(px, pz) * 2 - 0.75f;
            }
        }
        terrainData.SetHeights(0, 0, map);
        terrain.Flush();
    }
}
