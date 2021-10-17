using System.Collections.Generic;
using System.Linq;

using Domain;
using Domain.Enums;

namespace Database
{
	public static class TestData
	{
		public const int UnnamedDesignersNumber = 30000;

		public static Client[] Clients { get; }
		public static ContactInfo[] ContactInfos { get; }
		public static ContactInfo[] UnnamedContactInfos { get; }
		public static ContactInfo[] AllContactInfos { get; }
		public static Product[] Products { get; }
		public static Designer[] Designers { get; }
		public static Designer[] UnnamedDesigners { get; }
		public static Designer[] AllDesigners { get; }
		public static MiniDesigner[] AllMiniDesigners { get; }


		static TestData()
		{
			Client julie = new() { Name = "Julie" };
			Client geoffrey = new() { Name = "Geoffrey" };
			Client magnus = new() { Name = "Magnus" };

			Clients = new Client[] { julie, geoffrey, magnus };

			ContactInfo contactInfo1 = new() { Twitter = "@threadbare" };
			ContactInfo contactInfo2 = new() { Twitter = "@theemperor" };
			ContactInfo contactInfo3 = new() { Twitter = "@casacasual" };

			ContactInfos = new ContactInfo[] { contactInfo1, contactInfo2, contactInfo3 };

			Product product1 = new() { Description = "Super Skinny Jeans" };
			Product product2 = new() { Description = "Shiny Shirt" };
			Product product3 = new() { Description = "Really Really Sheer Shirt" };
			Product product4 = new() { Description = "Barely There Pants" };
			Product product5 = new() { Description = "Yoga Pants" };
			Product product6 = new() { Description = "More Yoga Pants" };

			Products = new Product[] { product1, product2, product3, product4, product5, product6 };

			Designers = new Designer[]
			{
				new()
				{
					LabelName = "Top Funky Creations",
					Founder = "Guy Vanchey",
					Dapperness = Dapperness.PrettyDapper,
					ContactInfo = contactInfo1,
					Clients = new List<Client> { geoffrey, magnus },
					Products = new List<Product> { product1, product2 }
				},
				new()
				{
					LabelName = "Emperor's Clothes",
					Founder = "Hans C. Anderson",
					Dapperness = Dapperness.SuperDapper,
					ContactInfo = contactInfo2,
					Clients = new List<Client> { magnus },
					Products = new List<Product> { product3, product4 }
				},
				new()
				{
					LabelName = "Casa Casual",
					Founder = "Julie Lerman",
					Dapperness = Dapperness.Dapperless,
					ContactInfo = contactInfo3,
					Clients = new List<Client> { julie },
					Products = new List<Product> { product5, product6 }
				}
			};

			UnnamedDesigners = new Designer[UnnamedDesignersNumber];
			UnnamedContactInfos = new ContactInfo[UnnamedDesignersNumber];

			for (int i = 0; i < UnnamedDesignersNumber; i++)
			{
				UnnamedDesigners[i] = new Designer
				{
					LabelName = $"Label{i}",
					Founder = $"Founder{i}",
					Dapperness = Dapperness.KindaDapper,
					ContactInfo = UnnamedContactInfos[i] = new ContactInfo { Twitter = $"Label{i}" }
				};
			}

			AllContactInfos = ContactInfos
				.Union(UnnamedContactInfos)
				.ToArray();
			AllDesigners = Designers
				.Union(UnnamedDesigners)
				.ToArray();

			void FiilClientDesigners(Client client) => client.Designers.AddRange(Designers.Where(designer => designer.Clients.Contains(client)));
			FiilClientDesigners(julie);
			FiilClientDesigners(geoffrey);
			FiilClientDesigners(magnus);
			//julie.Designers.AddRange(Designers.Where(designer => designer.Clients.Contains(julie)));

			AllMiniDesigners = AllDesigners
				.Select(item => new MiniDesigner
				{
					Id = item.Id,
					Name = item.LabelName,
					FoundedBy = item.Founder
				})
				.ToArray();
		}
	}
}
