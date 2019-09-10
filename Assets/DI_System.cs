using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DI_System : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DMG_i indicatorePrefab = null;
    [SerializeField] private RectTransform holder = null;
    [SerializeField] private new Camera camera = null;
    [SerializeField] private Transform Player = null;

    private Dictionary<Transform, DMG_i> Indicator = new Dictionary<Transform, DMG_i>();

    #region Delegates
    public static Action<Transform> CreateIndicator = delegate { };
    public static Func<Transform, bool> CheckIfObjectInSight = null;
    #endregion

    private void OnEnable()
    {
        CreateIndicator += Create;
        CheckIfObjectInSight += insight;
    }
    private void OnDisable()
    {
        CreateIndicator += Create;
        CheckIfObjectInSight += insight;
    }

    void Create(Transform target)
    {
        if(Indicator.ContainsKey(target))
        {
            Indicator[target].Restart();
            return;
        }
        DMG_i newIndicator = Instantiate(indicatorePrefab, holder);
        newIndicator.Register(target, Player, new Action(() => { Indicator.Remove(target); } ));

        Indicator.Add(target, newIndicator);

    }

    bool insight(Transform t)
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(t.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
