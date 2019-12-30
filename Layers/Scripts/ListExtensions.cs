using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extension class for list and array management.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Lists: Move an object from one index to another in a list. Does not work for Arrays.
    /// </summary>
    /// <typeparam name="T">Lists</typeparam>
    /// <param name="list">List to adjust</param>
    /// <param name="oldIndex">Old index of object.</param>
    /// <param name="newIndex">Index to move to.</param>
    public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
    {
        T item = list[oldIndex];
        list.RemoveAt(oldIndex);
        list.Insert(newIndex, item);
    }

    /// <summary>
    /// Lists: Replaces and object in a list. Does not work for Arrays.
    /// </summary>
    /// <typeparam name="T">Lists</typeparam>
    /// <param name="list">List to adjust</param>
    /// <param name="index">Index to replace at</param>
    /// <param name="item">Object to place into index.</param>
    public static void Replace<T>(this List<T> list, int index, T item)
    {
        list.RemoveAt(index);
        list.Insert(index, item);
    }

    /// <summary>
    /// Arrays: Returns if array contains an object. Similar to List<>.Contains(object)
    /// </summary>
    /// <typeparam name="T">Arrays</typeparam>
    /// <param name="array">Array to check</param>
    /// <param name="item">Item to look for</param>
    /// <returns>True: array contains object, False: array does not contain object or is null.</returns>
    public static bool Contains<T>(this T[] array, T item)
    {
        foreach(T t in array)
        {
            if(item.Equals(t))
            {
                return true;
            }
        }

        return false;
    }
}
