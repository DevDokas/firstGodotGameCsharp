using Godot;
using System;

public class HUD : CanvasLayer
{
    public Label score;

    public override void _Ready()
    {
        
    }

    public void atualiza_score(int valor) {
        score = GetNode<Label>("Score");
        score.Text = valor.ToString();
    }
}
