using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	private void Despawn()
	{
		QueueFree();
	}
	private void HitBoxEntered(Area2D area)
	{
		area.GetParent().QueueFree();
		LinearVelocity = Vector2.Zero;
		GetNode<Sprite2D>("Sprite2D").Hide();
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Show();
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Boom");
        GetNode<Timer>("Timer").Stop();
	}
}
