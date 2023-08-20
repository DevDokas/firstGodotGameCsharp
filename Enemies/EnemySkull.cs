using Godot;
using System;

public class EnemySkull : KinematicBody2D
{
	private Sprite idleSprite;
	private Sprite walkSprite;
	private Sprite atackSprite;
	private const float moveSpeed = 75;
	private const float gravity = 100;
	private float previousX;
	private bool isFacingRight = true;
	
	
	private Vector2 motion = Vector2.Zero;
	private KinematicBody2D player;


	public override void _Ready(){
		player = GetNode<KinematicBody2D>("/root/Level_001/Player");
		idleSprite = GetNode<Sprite>("Idle");
		
		idleSprite.Visible = true;
		previousX = GlobalPosition.x;
	}
	public override void _PhysicsProcess(float delta){

		Vector2 directionToPlayer = (player.Position - Position).Normalized();
		motion = directionToPlayer * moveSpeed;

		if(IsOnFloor()){
			// motion.x = playerPosition.x * moveSpeed;
		} else if(IsOnWall()){

		} else if(IsOnCeiling()){

		} else{

		}

		motion = MoveAndSlide(motion);

	}
}
