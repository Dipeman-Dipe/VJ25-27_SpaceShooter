using Unity.VisualScripting;
using UnityEngine;

interface ICollectable
{
   void Collect(); 
}
interface ICollectableWithPos : ICollectable
{
    Vector3 GetPos{get;}
}
interface ICollectableWithValue : ICollectable
{
    int GetValue {get;}
}

