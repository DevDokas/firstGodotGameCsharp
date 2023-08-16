using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export]
	private const float MoveSpeed = 200.0f;
	

	
	
	public override void _PhysicsProcess(float delta ) 
	{
		var motion = new Vector2();

		float moveInput = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");

		motion.x = moveInput * MoveSpeed;
		motion.y = Input.GetActionStrength("jump");

		KinematicCollision2D collision = MoveAndCollide(motion * delta);
	
		motion.y = 0;
	
		motion.y += 9.8f * delta;
	}
}
