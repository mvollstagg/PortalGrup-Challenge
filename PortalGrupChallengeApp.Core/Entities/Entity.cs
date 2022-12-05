namespace PortalGrupChallengeApp.Core.Entities;
public class Entity : IEntity
{
	public int Id { get; set; }

	public string GuId { get; set; }

	public Entity()
	{
		GuId = Guid.NewGuid().ToString().Replace("-", "");
	}
}
