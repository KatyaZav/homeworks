using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble 
{
    public void Add(float health);
    public void Remove(float damage);
}
