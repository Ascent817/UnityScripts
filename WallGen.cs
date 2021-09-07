using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallGen : MonoBehaviour
{
    Tilemap ts;
    int xSample;
    int ySample;

    int c = 1;

    public Transform player;

    Texture2D noiseTex;

    public Tile goldTile;
    public TilemapCollider2D tilecol;

    void Start()
    {
        ts = GetComponent<Tilemap>();

        noiseTex = GetComponent<PerlinNoise>().noiseTex;


        Invoke("WallGenNoise", 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        c++;
    }

    public void WallGenNoise()
    {
        noiseTex = GetComponent<PerlinNoise>().noiseTex;
        for (int i = -50; i < 50; i++)
        {
            for (int j = -50; j < 50; j++)
            {
                if (noiseTex.GetPixel(i, j).r > 0.5)
                {
                    ts.SetTile(new Vector3Int(i, j, 0), goldTile);
                }
                else
                {
                    ts.SetTile(new Vector3Int(i, j, 0), null);
                }

            }
        }
    }

}
