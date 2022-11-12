using System.Collections.Generic;
using UnityEditor;
using Humanizer;

[InitializeOnLoad]
public class HumanizerNuGetPackageTester
{
    static HumanizerNuGetPackageTester()
    {
        var collection = new List<string> { "One", "Two", "Three" };
        var result = collection.Humanize();
        UnityEngine.Debug.Log(result);
    }
}