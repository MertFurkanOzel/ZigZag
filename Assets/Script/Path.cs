using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]GameObject CubeObject;
    [SerializeField] GameObject diamond;
    public int Chunkcount=2;
    public static int Cubeinchunk = 10;
    Chunk[] Chunks;
    private void Awake()
    {
        Cube.LastCube = null;
        Cube.IdinPath = 0;
        Diamonds.diamonds.Clear();
    }
    private void Start()
    {
        Chunks = new Chunk[Chunkcount];
        for (int i = 0; i < Chunkcount; i++)
        {
            Color32 target_color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
            GameObject path = new GameObject("Chunk"+i);
            Chunks[i] = new Chunk(CubeObject,path,diamond,target_color);
        }

    }
    public IEnumerator reset_chunk(GameObject chunk)
    {
        foreach (var item in Chunks)
        {
            if (item.parent == chunk)
            {
                yield return new WaitForSeconds(3f);
                item.reset_cubes(new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255));
            }
            yield return null;
        }
    }
}
