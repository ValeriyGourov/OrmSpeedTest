namespace Domain
{
	public class ContactInfo /*: EntityBase*/
	{
		public int ContactInfoId { get; set; }
		public string? Twitter { get; set; }
		public Designer? Designer { get; /*private*/ set; }
	}
}