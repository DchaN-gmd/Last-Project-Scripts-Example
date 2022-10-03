using System;
using System.Collections;
using UnityEngine;

public class DelaySystem : MonoBehaviour
{
    public static IEnumerator DelayFunction(float delay, Action function)
    {
        yield return new WaitForSeconds(delay);
        
        function?.Invoke();
    }

    public static IEnumerator DelayFunction(float delay, Action<object> function, object value)
    {
        yield return new WaitForSeconds(delay);

        function?.Invoke(value);
    }
}
