using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragile : MonoBehaviour
{
    [SerializeField] bool on_bounce, on_hit, on_throw;

    public bool GetBounce()
    {
        return on_bounce;
    }

    public bool GetHit()
    {
        return on_hit;
    }

    public bool GetThrow()
    {
        return on_throw;
    }
}
