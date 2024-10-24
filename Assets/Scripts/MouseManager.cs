using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    
    public Texture2D resizeCursorTex;
    public Texture2D moveCursorTex;
    public LayerMask layer;
    private Vector2 pointerPosition = new();
    private Transform objectToMove;
    private CircleShape objectToResize;

    public List<Object> scenes = new();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCursor();

        if ( objectToMove != null )
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( pointerPosition );
            worldPos.z = 0f;
            objectToMove.position = worldPos;
        }
    }

    private void ChangeCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay( pointerPosition );
        RaycastHit2D hit = Physics2D.GetRayIntersection( ray, Mathf.Infinity, layer );

        if ( hit.collider != null )
        {
            if ( hit.collider.CompareTag( "Resize" ) )
            {
                Cursor.SetCursor( resizeCursorTex, new Vector2( resizeCursorTex.width / 2, resizeCursorTex.height / 2 ), CursorMode.Auto );
            }
            else if ( hit.collider.CompareTag( "Arrow" ) )
            {
                Cursor.SetCursor( moveCursorTex, new Vector2( moveCursorTex.width / 2, moveCursorTex.height / 2 ), CursorMode.Auto );
            }
        }
        else
        {
            Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto );
        }
    }

    public void PointerMove( InputAction.CallbackContext context )
    {
        switch ( context.phase )
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:

                pointerPosition = context.ReadValue<Vector2>();

                break;
            case InputActionPhase.Canceled:
                break;
            default:
                break;
        }
    }

    public void OnPointerPressed( InputAction.CallbackContext context )
    {
        switch ( context.phase )
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                Ray ray = Camera.main.ScreenPointToRay( pointerPosition );
                RaycastHit2D hit = Physics2D.GetRayIntersection( ray, Mathf.Infinity, layer );

                if ( hit.collider != null )
                {
                    if( hit.collider.CompareTag("Resize") )
                    {
                        objectToResize = hit.collider.GetComponent<CircleShape>();
                    }else if( hit.collider.CompareTag( "Arrow" ) )
                    {
                        objectToMove = hit.transform.parent;
                    }
                }
                break;
            case InputActionPhase.Canceled:

                objectToResize = null;
                objectToMove = null;

                break;
            default:
                break;
        }
    }
}
