using Godot;
using System;

public partial class Tank : CharacterBody2D
{
	Camera2D camera;
    public override void _Ready()
    {
        camera = GetNodeOrNull<Camera2D>("Camera2D");
    }
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (Input.IsActionJustPressed("ZoomIn"))
        {
            if (camera.Zoom.X < 1)
                camera.Zoom *= 1.1f;
        }
        if (Input.IsActionJustPressed("ZoomOut"))
        {
            if (camera.Zoom.X > 0.5f)
                camera.Zoom *= 0.9f;
        }

        if (Input.IsActionPressed("TurnRight"))
        {
            Rotate(0.05f);
        }
        if (Input.IsActionPressed("TurnLeft"))
        {
            Rotate(-0.05f);
        }
        if (Input.IsActionPressed("Forward"))
        {
            Velocity = new Vector2(400, 0).Rotated(Rotation);
        }
        else if (Input.IsActionPressed("Backward"))
        {
            Velocity = -(new Vector2(400, 0).Rotated(Rotation));
        }
        else
        {
            Velocity = Vector2.Zero;
        }
        MoveAndSlide();
    }
}
