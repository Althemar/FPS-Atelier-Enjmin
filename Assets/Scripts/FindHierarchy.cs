using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindHierarchy {

	public static Transform FindChildWithTag(Transform parent, string tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).transform.tag == tag)
            {
                return parent.GetChild(i);
            }
        }
        return null;
    }

    public static Transform FindChildWithComponent<ComponentType>(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).GetComponent<ComponentType>() != null)
            {
                return parent.GetChild(i);
            }
        }
        return null;
    }
}
