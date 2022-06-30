using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SimpleRandomWalkParameters_",menuName = "PCG/SimpleRAndomWalkData")]
public class SimpleRandomWalkSO : ScriptableObject
{
    public int iterations = 12, walkLength = 12;
    public bool startRandomlyEachIteration = true;
}
