using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TilesScript[] tiles;
    private Camera mainCamera;
    [SerializeField] private Transform emptySpace;
    private static int emptySpaceIndex = 5;
    private bool _isFinished;
    // Start is called before the first frame update
    void Start()
    {

        var a = GameObject.Find("Cube1").GetComponent<Renderer>();
        a.material.SetColor("_Color", Color.yellow);

        mainCamera = Camera.main;
        _isFinished = false;
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit))
            {
                //if (hit.rigidbody != null)
                //{
                    Debug.Log(hit.transform.name);
                    //hit.rigidbody.AddForceAtPosition(ray.direction * 1f, hit.point);
                    if (Vector3.Distance(emptySpace.position,hit.transform.position) < 1.5f )
                    {
                        Vector3 lastEmptySpacePosition = emptySpace.position;
                        TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                        emptySpace.position = thisTile.targetPosition;
                        thisTile.targetPosition = lastEmptySpacePosition;
                        int tileIndex = findIndex(thisTile);
                        tiles[emptySpaceIndex] = tiles[tileIndex];
                        tiles[tileIndex] = null;
                        emptySpaceIndex = tileIndex;


                    }
                //}
            }
            
        }
    }




    public int findIndex(TilesScript ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }




}
