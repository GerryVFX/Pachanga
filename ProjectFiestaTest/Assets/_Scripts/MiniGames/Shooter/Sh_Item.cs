using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sh_Item : MonoBehaviour
{
    public Sh_ItemInfo itemInfo;
    public GameObject itemGO;
    public abstract void Use();
}
