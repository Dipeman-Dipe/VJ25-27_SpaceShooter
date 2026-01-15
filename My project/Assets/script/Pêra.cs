using UnityEngine;

public class Pêra : Fruta
{
    public override void Coletar()
    {
       print ("Peguei uma Pêra");
       base.Coletar(); 
    }
}