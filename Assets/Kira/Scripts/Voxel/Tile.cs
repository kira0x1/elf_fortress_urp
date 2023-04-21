using UnityEngine;

namespace Kira.Terrain
{
    public enum TerrainType
    {
        DEEP_WATER,
        SHALLOW_WATER,
        DIRT,
        GRASS,
        SAND,
        ROCK
    }

    public class Tile : MonoBehaviour
    {
        private TerrainRegion region;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetRegion(TerrainRegion region)
        {
            this.region = region;
            meshRenderer.material.color = region.color;
        }
    }
}