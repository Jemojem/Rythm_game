using System;
using UnityEngine;

public abstract class Note : MonoBehaviour, IBounds
{
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected TrackConfig config;

    public Action<HitType> OnHit;
    public Action OnMiss;

    public Keys Key { get; set; }

    public abstract Bounds bounds { get; }

    public abstract bool TryPress(Vector3 hitLinePosition);
    public virtual bool TryHold(Vector3 hitLinePosition)
    {
        return false;
    }
    public virtual bool TryRelease(Vector3 hitLinePosition)
    {
        return false;
    }

    public enum Keys
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six
    }
}
