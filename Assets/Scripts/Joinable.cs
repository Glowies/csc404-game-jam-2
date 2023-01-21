using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joinable : MonoBehaviour
{
    public UnityEvent OnComplete;

    Joinable parentCube;
    int numChild;

    private void OnCollisionEnter(Collision other) {
        GameObject otherCube = other.gameObject;
        if (!other.gameObject.TryGetComponent(out Joinable myJoinable))
        {
            return;
        }
        
        if(myJoinable.HasParent())
        {
            return;
        }

        JoinCube(myJoinable);
    }

    public bool HasParent()
    {
        return parentCube != null;
    }
    public int CheckChildren(){
        List<Joinable> children = new List<Joinable>(GetComponentsInChildren<Joinable>());
        Debug.Log("Previous length is" + children.Count);
        return children.Count;
    }

    private void JoinCube(Joinable otherCube){
        if (HasParent()){
            return;
        }
        otherCube.transform.parent = transform;
        otherCube.parentCube = this;
        otherCube.TryGetComponent(out Rigidbody otherRigidbody);
        otherRigidbody.constraints = RigidbodyConstraints.FreezeAll;

        if (CheckChildren() == 4){
            OnComplete.Invoke();
            Debug.Log("Completed Puzzle!");
        }
    }
    // // Start is called before the first frame update
    // void Start()
    // {
    //     parentCube = 
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
