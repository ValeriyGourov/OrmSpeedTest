using System.Collections.Generic;
using System.Linq;

using Domain.Enums;

namespace Domain
{
	public class Designer /*: EntityBase*/
	{
		public int Id { get; set; }
		public string? LabelName { get; set; }
		public string? Founder { get; set; }
		public Dapperness Dapperness { get; set; }
		//has to be many to many
		public List<Client> Clients { get; set; } = new List<Client>();
		public List<Product> Products { get; set; } = new List<Product>();

		public ContactInfo? ContactInfo { get; set; }
	}

	public static class DesignerExtensions
	{
		public static Designer Buid(this Designer designer, IEnumerable<Product> products)
		{
			designer.Products = products.ToList();
			return designer;
		}

		public static Designer Buid(this Designer designer, ContactInfo contactInfo)
		{
			contactInfo.Designer = designer;
			designer.ContactInfo = contactInfo;
			return designer;
		}

		public static Designer Buid(this Designer designer, IEnumerable<Client> clients)
		{
			designer.Clients = clients.ToList();

			foreach (Client client in clients)
			{
				client.Designers.Add(designer);
			}

			return designer;
		}
	}
}
