using Godot;
using System;

public class Player : KinematicBody2D
{
	private const float moveSpeed = 100;
	private const float gravity = 100;
	private const float jumpForce = -100;
	private const float maxJumpTime = 0.2f;
	private float currentJumpTime = 0;
    private Vector2 motion = Vector2.Zero;

	public override void _PhysicsProcess(float delta ) 
	{

		float moveInput = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");

		motion.x = moveInput * moveSpeed;

		if (IsOnFloor()) {
			motion.y = 0;
			if (Input.IsActionPressed("jump")) {
				if (currentJumpTime < maxJumpTime) {
					motion.y += jumpForce;
					currentJumpTime += delta;
				}
			}
		} else {
			motion.y += gravity * delta * 2;
		}
	
		KinematicCollision2D collision = MoveAndCollide(motion * delta);
		motion = MoveAndSlide(motion, Vector2.Up);
	
	}
}
