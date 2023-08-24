using Godot;
using System;

public class Level_001 : Node2D
{
    public HUD hud;
    public int score;

    public override void _Ready()
    {   
        GetNode<Area2D>("/root/Level_001/Apple").Connect("Coletado",this,"_on_Coletado");
        hud = GetNode<HUD>("HUD");
        new_game();

        hud.Visible = true;
    }

    public void new_game() 
    {
        score = 0;
    }

    public void add_score(int point) 
    {
        score += point;
        hud.atualiza_score(score);
    }

    public void _on_Coletado() {
        add_score(1);
    }
}
