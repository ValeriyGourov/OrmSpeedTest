using System.Collections.Generic;

using Domain.Enums;

namespace Domain
{
	public class Client /*: EntityBase*/
	{
		public int ClientId { get; set; }
		public string? Name { get; set; }
		public Dapperness DefaultDappernessLevel { get; set; }
		public List<Designer> Designers { get; set; } = new List<Designer>();
	}
}