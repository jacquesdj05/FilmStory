using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomiser
{
    // http://csharphelper.com/blog/2014/07/randomize-arrays-in-c/
    public static void RandomiseArray<T>(T[] items)
    {
        System.Random rand = new System.Random();

        // For each spot in the array, pick a random item to swap into that spot.
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = rand.Next(i, items.Length);
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }

    // https://stackoverflow.com/questions/273313/randomize-a-listt
    public static void RandomiseList<T>(this IList<T> list)
    {
        System.Random rand = new System.Random();

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
