using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    public GameObject chunk;
    public Cube[] cubes = new Cube[Path.Cubeinchunk];
    public GameObject parent;
    public Chunk(GameObject CubeObject,GameObject parent, GameObject diamond,Color32 target_color)
    {
        this.parent = parent;
        for (int i = 0; i < Path.Cubeinchunk; i++)
        {       
            cubes[i] = new Cube(CubeObject,parent.transform,i+1,diamond,target_color);
        }

    }
    public void reset_cubes(Color32 target_color)
    {
        foreach (var item in cubes)
        {
            item.reset(target_color);
        }
    }
}
