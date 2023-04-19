using UnityEngine;

namespace Kira.Terrain
{
    public class MapGenerator : MonoBehaviour
    {
        public int mapWidth = 100;
        public int mapHeight = 100;
        public float noiseScale = 28;

        public int octaves = 4;
        [Range(0, 1)]
        public float persistance = 0.5f;
        public float lacunarity = 2f;

        public int seed;
        public Vector2 offset;

        public bool autoUpdate = true;

        public void GenerateMap()
        {
            float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
            MapDisplay display = FindObjectOfType<MapDisplay>();
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }

        public float[,] GetNoiseMap()
        {
            return Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        }

        private void OnValidate()
        {
            if (mapWidth < 1) mapWidth = 1;
            if (mapHeight < 1) mapHeight = 1;
            if (lacunarity < 1) lacunarity = 1;
            if (octaves < 0) octaves = 0;
        }
    }
}