using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface INavigator
{
    void Follow(Vector3 targetPosition, float projectileSpeed, Transform projectileTransform);
}
