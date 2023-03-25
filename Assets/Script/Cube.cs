using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube
{
    public GameObject cube;
    public GameObject diamond;
    public Vector3 CubePosition;
    public Vector3 CubeScale;
    public Direction direction;
    public int IdinChunk;
    public static int IdinPath;
    public static Cube LastCube;
    public Transform parent;
    private Color32 targetcolor;
    public Color32 cubecolor;

    public Cube(GameObject cube_object, Transform parent,int IdinChunk, GameObject diamond,Color32 targetcolor)
    {
        IdinPath++;
        this.parent = parent;
        this.IdinChunk = IdinChunk;
        this.diamond = diamond;
        this.targetcolor = targetcolor;
        Color32 startcolor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        //Color32 startcolor = new Color32(100, 120, 130, 255);
        if (LastCube == null)
        {
            CubeScale = new Vector3(4, 1, 4);
            CubePosition = Vector3.zero;
            cubecolor = startcolor;
        }
        else
        {
            cubecolor = Color.Lerp(LastCube.cubecolor, this.targetcolor, .034f);
            direction = (Direction)(((int)LastCube.direction + 1) % 2);
            set_cube_position();
            add_diamond();
        }
        cube = Object.Instantiate(cube_object, CubePosition, Quaternion.identity);
        cube.GetComponent<MeshRenderer>().material.color = cubecolor;
        cube.transform.localScale = CubeScale;  
        cube.name = $"Cube{IdinChunk}";
        cube.transform.parent = parent;
        LastCube = this;
    }
    public void reset(Color32 newtargetcolor)
    {
        IdinPath++;
        targetcolor = newtargetcolor;
        set_cube_position();
        add_diamond();
        cube.transform.position = CubePosition;
        cube.transform.localScale = CubeScale;
        cubecolor = Color.Lerp(LastCube.cubecolor, this.targetcolor, .034f);
        cube.GetComponent<MeshRenderer>().material.color = cubecolor;
        LastCube = this;
    }
    private void set_cube_position()
    {
        CubeScale = Random_Scale.Random_scale_gen(direction);
        CubePosition = (direction) switch
        {
            not 0 => LastCube.CubePosition + new Vector3(LastCube.CubeScale.x / 2 + CubeScale.x / 2, 0, LastCube.CubeScale.z / 2 - CubeScale.z / 2),
            _ => LastCube.CubePosition + new Vector3(LastCube.CubeScale.x / 2 - CubeScale.x / 2, 0, LastCube.CubeScale.z / 2 + CubeScale.z / 2)
        };
    }
    private void add_diamond()
    {
        if(Random.Range(0,((IdinPath-1)*2)+1)%2!=0)//%33 => lim inf %50
        {
            GameObject dia;
            Vector3 diaPos = CubePosition;
            diaPos.y+= .8f;
            if(direction!=0)
            {
                diaPos.x = Random.Range(CubePosition.x - CubeScale.x/2, CubePosition.x+ CubeScale.x / 2-CubeScale.z/2);
            }
            else
            {
                diaPos.z = Random.Range(CubePosition.z - CubeScale.z/2, CubePosition.z+ CubeScale.z / 2-CubeScale.x/2);

            }
            if (Diamonds.give_diamond()!=null)
            {
                dia = Diamonds.give_diamond();
                dia.SetActive(true);
                dia.transform.position = diaPos;
            }
            else
            {
                dia = Object.Instantiate(diamond, diaPos,Quaternion.Euler(-90, 0, 0));
            }
            dia.transform.parent = GameObject.Find("Diamonds").transform;
        }
    }
}
public enum Direction { left,right}
