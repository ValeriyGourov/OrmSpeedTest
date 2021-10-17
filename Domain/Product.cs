namespace Domain
{
	public class Product /*: EntityBase*/
	{
		public int ProductId { get; set; }
		public string? Description { get; set; }
		public int DesignerId { get; set; }
	}
}