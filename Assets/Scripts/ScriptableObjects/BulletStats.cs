using UnityEngine;

[CreateAssetMenu(menuName = "BulletStat", fileName = "New Bullet Stat")]
public class BulletStats : ScriptableObject
{
    [Range(0, 0.4f)] public float Speed = 0.1f;
    public float BlowStrength;
}
