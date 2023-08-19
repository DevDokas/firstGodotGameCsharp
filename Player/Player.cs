using Godot;
using System;

public class Player : KinematicBody2D
{
	private Sprite idleSprite;
	private Sprite walkSprite;
	private const float moveSpeed = 100;
	private const float gravity = 100;
	private const float jumpForce = -100;
	private const float maxJumpSpeed = 7;
	private int jumpsLeft = 2;
	private float previousX;
	private bool isFacingRight = true;

    private Vector2 motion = Vector2.Zero;

	public override void _Ready() {
		idleSprite = GetNode<Sprite>("Idle");
		walkSprite = GetNode<Sprite>("Walk");

		idleSprite.Visible = true;
		walkSprite.Visible = false;

		previousX = GlobalPosition.x;
		Console.WriteLine(previousX);
	}

	public override void _PhysicsProcess(float delta ) 
	{

		float moveInput = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");

		motion.x = moveInput * moveSpeed;

		if (IsOnFloor()) {
			jumpsLeft = 2;
			motion.y = 0;
			float currentX = GlobalPosition.x;
			bool isMoving = Mathf.Abs(currentX - previousX) > 1;
			

			previousX = currentX;

			idleSprite.Visible = !isMoving;
			walkSprite.Visible = isMoving;
			if (isMoving) {
				if (moveInput > 0 && !isFacingRight) {
					isFacingRight = true;
					idleSprite.FlipH = false;
					walkSprite.FlipH = false;
				}
				if (moveInput < 0 && isFacingRight) {
					isFacingRight = false;
					idleSprite.FlipH = true;
					walkSprite.FlipH = true;
				}
			}
			if (Input.IsActionPressed("jump")) {
				jumpsLeft--;
				motion.y += jumpForce;
			}
			if (Input.IsActionPressed("dash")) {
				motion.x *= 1.75f;
			}
			if (Input.IsActionPressed("dash") && Input.IsActionPressed("jump")) {
				motion.y += jumpForce/maxJumpSpeed;
				motion.x *= 1.75f;
			}
		} else if (IsOnWall()) {
			jumpsLeft = 0;
			if (jumpsLeft > 0 && Input.IsActionJustPressed("jump")) {
				jumpsLeft--;
				motion.y += jumpForce;
				motion.y += gravity * delta * 2;
/* 				if (!IsOnFloor() && !IsOnWall()) {
					jumpsLeft = 1;
					if (jumpsLeft > 0 && Input.IsActionJustPressed("jump")) {
						jumpsLeft--;
						motion.y = jumpForce;
					}	
				} */
			}
			motion.y += gravity * delta * 2;
			jumpsLeft = 1;
		} 
		else {
			motion.y += gravity * delta * 2;
			if (jumpsLeft > 0 && Input.IsActionJustPressed("jump")) {
				jumpsLeft--;
				motion.y = jumpForce;

			}
		}
	
		// Não deletar comentário abaixo
		// KinematicCollision2D collision = MoveAndCollide(motion * delta);
		motion = MoveAndSlide(motion, Vector2.Up);
	
	}
}
