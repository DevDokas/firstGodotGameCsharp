using Godot;
using System;

public class Apple : Area2D
{

    [Signal] public delegate void Coletado();
    public KinematicBody2D player;

    public override void _Ready()
    {
        player = GetNode<KinematicBody2D>("/root/Level_001/Player");
        Connect("body_entered", this, "_on_Area2D_area_entered");
    }

    private void _on_Area2D_area_entered(Node body) {
        if (body is KinematicBody2D otherKinematic) {
            if (otherKinematic == player) {
                QueueFree();
                EmitSignal(nameof(Coletado));
            }
        }
    }
}
