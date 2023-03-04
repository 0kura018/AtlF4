using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToPoint : MonoBehaviour
{
    [SerializeField] private Vector3 goToPointPosition1;
    [SerializeField] private Vector3 goToPointPosition2;
    [SerializeField] private GameObject goToPointObject;
    [SerializeField] private Quaternion goToPointQuaterion;
    private bool itsFirst;

}
