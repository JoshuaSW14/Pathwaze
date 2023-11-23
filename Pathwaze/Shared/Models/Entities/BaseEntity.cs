namespace Pathwaze.Shared.Models.Entities;

public abstract class BaseEntity
{
	protected BaseEntity()
	{
		CreationDate = DateTime.UtcNow;
		LastUpdatedDate = DateTime.UtcNow;
		Deleted = false;
	}

	public DateTime CreationDate { get; set; }
	public Guid CreationUserId { get; set; }
	public DateTime LastUpdatedDate { get; set; }
	public Guid LastUpdatedUserId { get; set; }
	public bool Deleted { get; set; }
}

