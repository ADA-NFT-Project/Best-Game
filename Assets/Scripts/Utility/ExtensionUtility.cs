using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class ExtensionUtility
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool hasState(this Animator anim, string stateName, int layer = 0) {
 
        int stateID = Animator.StringToHash(stateName);
        return anim.HasState(layer, stateID);
 
    }
}
