using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 correctPostion;
    private SpriteRenderer spriteRenderTile;
    public int number;
    private bool inRightPlace;
    // Start is called before the first frame update
    void Awake()
    {
        targetPosition = transform.position;
        correctPostion = transform.position;
        //spriteRenderTile = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.19f);
        if (targetPosition == correctPostion)
        {
           // spriteRenderTile.color = Color.green;
            inRightPlace = true;
        }
        else
        {
            //spriteRenderTile.color = Color.white;
            inRightPlace = false;
        }
        
    }
}
