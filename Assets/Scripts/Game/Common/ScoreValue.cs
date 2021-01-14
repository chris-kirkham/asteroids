using UnityEngine;

/// <summary>
/// Represents the score value of the attached GameObject.
/// </summary>
public class ScoreValue : MonoBehaviour
{
    [SerializeField] private float value = 0;

    public float GetValue()
    {
        return value;
    }
}
