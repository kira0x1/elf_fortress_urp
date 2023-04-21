using UnityEngine;

namespace Kira.Terrain
{
    [System.Serializable]
    public class TerrainRegion
    {
        public TerrainType terrainType;
        [Range(0, 1)] public float height;
        public Color color;
    }
}