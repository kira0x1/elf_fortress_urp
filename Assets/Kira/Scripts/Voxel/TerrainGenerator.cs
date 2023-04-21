using UnityEngine;

namespace Kira.Terrain
{
    public class TerrainGenerator : MonoBehaviour
    {
        [SerializeField]
        private Tile tilePrefab;

        [SerializeField]
        private int tilesX = 32;
        [SerializeField]
        private int tilesY = 32;

        [SerializeField]
        private TerrainRegion[] regions;

        private MapGenerator mapGenerator;

        private void Start()
        {
            mapGenerator = FindObjectOfType<MapGenerator>();

            // float[,] noiseMap = mapGenerator.GetNoiseMap();
            // for (int x = 0; x < noiseMap.GetLength(0); x++)
            // {
            //     for (int y = 0; y < noiseMap.GetLength(1); y++)
            //     {
            //     }
            // }

            GenerateTerrain();
        }

        private void GenerateTerrain()
        {
            float scale = tilePrefab.transform.localScale.x;

            Vector3 startingPos = transform.position;
            startingPos.x -= scale * tilesX / 2f;
            startingPos.z -= scale * tilesY / 2f;

            Vector3 pos = startingPos;
            float[,] noiseMap = mapGenerator.GetNoiseMap();


            for (int y = 0; y < noiseMap.GetLength(0); y++)
            {
                for (int x = 0; x < noiseMap.GetLength(1); x++)
                {
                    float height = noiseMap[x, y] * 4f;
                    TerrainRegion region = regions[0];

                    foreach (TerrainRegion terrainRegion in regions)
                    {
                        if (height > terrainRegion.height)
                            region = terrainRegion;
                    }


                    Tile t = Instantiate(tilePrefab, transform);
                    t.SetRegion(region);
                    t.transform.position = pos;
                    pos.x += scale;
                    pos.y = height;
                    Debug.Log(height);
                }

                pos.z += scale;
                pos.x = startingPos.x;
            }
        }
    }
}