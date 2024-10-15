using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public Texture2D cursorTex;
    public LayerMask layer;
    private Vector2 pointerPosition = new();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay( pointerPosition );
        RaycastHit2D hit = Physics2D.GetRayIntersection( ray, Mathf.Infinity, layer );

        if( hit.collider != null )
        {
            Debug.Log( "J'ai survolé " + hit.collider.name );
            Cursor.SetCursor( cursorTex, new Vector2( cursorTex.width / 2, cursorTex.height / 2 ), CursorMode.Auto );
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
}
