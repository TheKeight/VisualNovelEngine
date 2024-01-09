﻿using UnityEngine;
using VisualNovel.Entities;

namespace VisualNovel.Client.UX
{
    public sealed class ScenePositionManager : PositionManager
    {
        [SerializeField] private Transform _minPoint;
        [SerializeField] private Transform _maxPoint;
        [SerializeField] private float _zPosition = 0f;

        public override void ChangePosition(Transform tr, ScenePositionSO position)
        {
            Vector3 min = _minPoint.position;
            Vector3 max = _maxPoint.position;

            Vector3 pos = new Vector3
            {
                x = Mathf.Lerp(min.x, max.x, position.PositionX),
                y = Mathf.Lerp(min.y, max.y, position.PositionY),
                z = _zPosition
            };

            tr.position = pos;
        }
    }
}