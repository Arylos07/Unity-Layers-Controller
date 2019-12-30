// Written by Michael Cox. CCO license: free to use, modify, and distribute.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static helper class for Unity layers.
/// </summary>
public class Layers : MonoBehaviour
{
    /// <summary>
    /// Set state of culling mask on the main camera.
    /// </summary>
    /// <param name="layerName">Layer to set</param>
    /// <param name="visible">If true, this layer is visible. If false, this layer is not visible.</param>
    public static void ChangeCullingMask(string layerName, bool visible)
    {
        if(layerName != string.Empty)
        {
            if(visible == true)
            {
                Camera.main.cullingMask |= 1 << LayerMask.NameToLayer(layerName);
            }
            else if(visible == false)
            {
                Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer(layerName));
            }
        }
    }
    /// <summary>
    /// Set state of culling mask on designated camera.
    /// </summary>
    /// <param name="layerName">Layer to set.</param>
    /// <param name="visible">If true, this layer is visible. If false, this layer is not visible.</param>
    /// <param name="camera">Camera to set.</param>
    public static void ChangeCullingMask(string layerName, bool visible, Camera camera)
    {
        if (layerName != string.Empty)
        {
            if (visible == true)
            {
                camera.cullingMask |= 1 << LayerMask.NameToLayer(layerName);
            }
            else if (visible == false)
            {
                camera.cullingMask &= ~(1 << LayerMask.NameToLayer(layerName));
            }
        }
    }

    /// <summary>
    /// Returns state of defined layer on the main camera.
    /// </summary>
    /// <param name="layer">Layer to check</param>
    /// <returns>True = visible, false = not visible.</returns>
    public static bool IsLayerRendered(int layer)
    {
        return ((Camera.main.cullingMask & (1 << layer)) != 0);
    }
    /// <summary>
    /// Returns state of defined layer on the defined camera. True = visible, false = not visible.
    /// </summary>
    /// <param name="layer">Layer to check.</param>
    /// <param name="camera">Camera to check.</param>
    /// <returns>True = visible, false = not visible.</returns>
    public static bool IsLayerRendered(int layer, Camera camera)
    {
        return ((camera.cullingMask & (1 << layer)) != 0);
    }

    /// <summary>
    /// Manually set the layer of an object. Does not affect children.
    /// </summary>
    /// <param name="obj">Object to change layer.</param>
    /// <param name="newLayer">Integer of the new layer.</param>
    public static void SetLayer(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;
    }
    /// <summary>
    /// Manually set the layer of an object. Does not affect children.
    /// </summary>
    /// <param name="obj">Object to change layer.</param>
    /// <param name="newLayer">Name of the new layer.</param>
    public static void SetLayer(GameObject obj, string newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = LayerMask.NameToLayer(newLayer);
    }

    /// <summary>
    /// Set layer of object and all children.
    /// </summary>
    /// <param name="obj">Object to change.</param>
    /// <param name="newLayer">Integer of the new layer.</param>
    public static void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
    /// <summary>
    /// Set layer of object and all children.
    /// </summary>
    /// <param name="obj">Object to change.</param>
    /// <param name="newLayer">Name of the new layer.</param>
    public static void SetLayerRecursively(GameObject obj, string newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = LayerMask.NameToLayer(newLayer);

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, LayerMask.NameToLayer(newLayer));
        }
    }
    /// <summary>
    /// Set layer of object and children, but ignoring a specified child.
    /// </summary>
    /// <param name="obj">Object to change.</param>
    /// <param name="newLayer">Integer of new layer</param>
    /// <param name="ignoreObjectName">Name of object to ignore.</param>
    public static void SetLayerRecursively(GameObject obj, int newLayer, string ignoreObjectName)
    {
        if (null == obj)
        {
            return;
        }

        if (obj.name != ignoreObjectName)
        {
            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, newLayer, ignoreObjectName);
            }
        }
    }
    /// <summary>
    /// Set layer of object and children, but ignoring a specified child.
    /// </summary>
    /// <param name="obj">Object to change.</param>
    /// <param name="newLayer">Name of new layer</param>
    /// <param name="ignoreObjectName">Name of object to ignore.</param>
    public static void SetLayerRecursively(GameObject obj, string newLayer, string ignoreObjectName)
    {
        if (null == obj)
        {
            return;
        }

        if (obj.name != ignoreObjectName)
        {
            obj.layer = LayerMask.NameToLayer(newLayer);

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, LayerMask.NameToLayer(newLayer), ignoreObjectName);
            }
        }
    }
    /// <summary>
    /// Set layer of object and children, but ignoring an array specified children.
    /// </summary>
    /// <param name="obj">Object to change</param>
    /// <param name="newLayer">Integer of new layer.</param>
    /// <param name="ignoreObjectName">Array of names to ignore.</param>
    public static void SetLayerRecursively(GameObject obj, int newLayer, string[] ignoreObjectName)
    {
        if (null == obj)
        {
            return;
        }

        if (ignoreObjectName.Contains(obj.name))
        {
            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, newLayer, ignoreObjectName);
            }
        }
    }
    /// <summary>
    /// Set layer of object and children, but ignoring an array specified children.
    /// </summary>
    /// <param name="obj">Object to change</param>
    /// <param name="newLayer">Name of new layer.</param>
    /// <param name="ignoreObjectName">Array of names to ignore.</param>
    public static void SetLayerRecursively(GameObject obj, string newLayer, string[] ignoreObjectName)
    {
        if (null == obj)
        {
            return;
        }

        if (ignoreObjectName.Contains(obj.name))
        {
            obj.layer = LayerMask.NameToLayer(newLayer);

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, LayerMask.NameToLayer(newLayer), ignoreObjectName);
            }
        }
    }
    /// <summary>
    /// Set layer of object and children, but ignoring a list specified children.
    /// </summary>
    /// <param name="obj">Object to change</param>
    /// <param name="newLayer">Integer of new layer</param>
    /// <param name="ignoreObjectName">List of names to ignore.</param>
    public static void SetLayerRecursively(GameObject obj, int newLayer, List<string> ignoreObjectName)
    {
        if (null == obj)
        {
            return;
        }

        if (ignoreObjectName.Contains(obj.name))
        {
            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, newLayer, ignoreObjectName);
            }
        }
    }
    /// <summary>
    /// Set layer of object and children, but ignoring a list specified children.
    /// </summary>
    /// <param name="obj">Object to change</param>
    /// <param name="newLayer">Name of new layer</param>
    /// <param name="ignoreObjectName">List of names to ignore.</param>
    public static void SetLayerRecursively(GameObject obj, string newLayer, List<string> ignoreObjectName)
    {
        if (null == obj)
        {
            return;
        }

        if (ignoreObjectName.Contains(obj.name))
        {
            obj.layer = LayerMask.NameToLayer(newLayer);

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, LayerMask.NameToLayer(newLayer), ignoreObjectName);
            }
        }
    }
}
