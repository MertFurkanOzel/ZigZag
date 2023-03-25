using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Diamonds
{
    public static List<GameObject> diamonds=new List<GameObject>();

    public static GameObject give_diamond()
    {
        foreach (var item in diamonds)
        {
            if(!item.activeInHierarchy)
            {
                return item;
            }
        }
        return null;
    }
    public static void destroy_diamond(GameObject dia)
    {
        dia.SetActive(false);
        diamonds.Add(dia);
    }
}
