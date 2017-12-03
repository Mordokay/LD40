using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragger : MonoBehaviour {

    private Vector2 _box_start_pos = Vector2.zero;
    private Vector2 _box_end_pos = Vector2.zero;

    bool isDrawing;
    public Texture myTexture;

    void Start () {
        isDrawing = false;
    }

    void Update()
    {
        // Called while the user is holding the mouse down.
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Called on the first update where the user has pressed the mouse button.
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isDrawing = true;
                _box_start_pos = Input.mousePosition;
            }
            else  // Else we must be in "drag" mode.
                _box_end_pos = Input.mousePosition;
        }
        else
        {
            // Handle the case where the player had been drawing a box but has now released.
            if (_box_end_pos != Vector2.zero && _box_start_pos != Vector2.zero)
                isDrawing = false;
            // Reset box positions.
            _box_end_pos = _box_start_pos = Vector2.zero;
        }
    }
    /// <summary>
    /// Draws the selection rectangle if the user is holding the mouse down.
    /// </summary>
    void OnGUI()
    {
        // If we are in the middle of a selection draw the texture.
        if (_box_start_pos != Vector2.zero && _box_end_pos != Vector2.zero)
        {
            // Create a rectangle object out of the start and end position while transforming it
            // to the screen's cordinates.
            var rect = new Rect(_box_start_pos.x, Screen.height - _box_start_pos.y,
                                _box_end_pos.x - _box_start_pos.x,
                                -1 * (_box_end_pos.y - _box_start_pos.y));
            // Draw the texture.
            GUI.DrawTexture(rect, myTexture);
        }
    }
}
