using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class EnemySpawner : MonoBehaviour
{
    private const float V = 0.3f;

    [SerializeField]
    private GameObject orc;
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private StatementsSettings config;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Player player;

    private List<StatementStruct> statements;

    private void Awake()
    {
        UnityARSessionNativeInterface.ARAnchorAddedEvent += AddAnchor;
        //UnityARSessionNativeInterface.ARAnchorUpdatedEvent += UpdateAnchor;
        //InvokeRepeating("FixLook", 0.5f,0.5f);
        statements = config.statements;
    }


    private void AddAnchor(ARPlaneAnchor arPlaneAnchor)
    {
        if (statements.Count == 0)
            return;

        int index = Random.Range(0, statements.Count-1);

        Quaternion orcRotation = UnityARMatrixOps.GetRotation(arPlaneAnchor.transform);
        orcRotation.eulerAngles = new Vector3(orcRotation.x, orcRotation.y + 180, orcRotation.z);

        GameObject newOrc = Instantiate(orc, UnityARMatrixOps.GetPosition(arPlaneAnchor.transform), 
                                        orcRotation, 
                                        gameObject.transform);

        //newOrc.transform.position = new Vector3(newOrc.transform.position.x, newOrc.transform.position.y + 180, newOrc.transform.position.z);
        newOrc.transform.localScale = new Vector3(V, V, V);
        newOrc.transform.GetComponent<Orc>().Init(statements[index].isCorrect);
        newOrc.transform.GetComponent<Orc>().Died = UpdateScore;
              
        audioSource.clip = statements[index].audioClip;
        audioSource.Play();

        statements.RemoveAt(index);
    }

    private void UpdateScore(int score)
    {
        player.SetScore(score, statements.Count == 0); 
    }

    private void FixLook()
    {
        
        foreach (Transform tr in gameObject.transform)
        {
            if (tr.tag == "MainCamera")
                continue;

            Vector3 fixedPosition = new Vector3(mainCamera.transform.position.x, tr.position.y, mainCamera.transform.position.z);

            Vector3 lookVector = fixedPosition - tr.position;
            lookVector.y = tr.position.y;
            //lookVector.x = tr.position.x;
            //lookVector.z = tr.position.z;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            tr.rotation = Quaternion.Slerp(tr.rotation, rot, 0.5f);
        }

    }
        
}
