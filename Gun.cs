using Godot;
using System;

public partial class Gun : Node2D
{
    PackedScene bullet;
    public override void _Ready()
    {
        bullet = ResourceLoader.Load<PackedScene>("res://bullet.tscn");
    }
    public override void _Process(double delta)
	{
		LookAt(GetGlobalMousePosition());

        if (Input.IsActionJustPressed("Shoot"))
        {
            var newBullet = bullet.Instantiate<RigidBody2D>();
            newBullet.Position = GetNode<Marker2D>("Marker2D").GlobalPosition;

            var velocity = new Vector2(600,0);
            newBullet.LinearVelocity = velocity.Rotated(GlobalRotation);
            newBullet.Rotation = GlobalRotation;

            GetParent().GetParent().AddChild(newBullet);
        }
	}
}
