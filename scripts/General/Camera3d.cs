using Godot;
using Incorgnito.scripts.characters.player;

public partial class Camera3d : Camera3D
{
	public Vector3 offset = Vector3.Zero;
	
	[Export] public Player3d Player3dNode { get; set; }


	public override void _Ready()
	{
		offset = Position;
	}

	public override void _Process(double delta)
	{
		Position = Player3dNode.Position + offset;
	}
}
