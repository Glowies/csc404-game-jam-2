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
        if (other.gameObject.TryGetComponent(out Joinable myJoinable)){
            JoinCube(myJoinable);
        }
        else{ return;}
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
        if (!HasParent()){
            otherCube.transform.parent = parentCube.transform;
            otherCube.parentCube = this;
        }
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
