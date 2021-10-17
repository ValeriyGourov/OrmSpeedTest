using System;
using System.Linq;
using System.Threading.Tasks;

using Database;

using Domain;
using Domain.Enums;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure.EqualityComparers;
using UnitTestInfrastructure.Extentions;

namespace UnitTestInfrastructure
{
	public static class TestsMethods
	{
		public static async Task GetAllDesigners(Func<Task<Designer[]>> queryMethod)
		{
			// Arrange.
			Designer[] expected = TestData.AllDesigners;

			// Act.
			Designer[] actual = await queryMethod();

			// Assert.
			CollectionAssert.That.AreEquivalent(expected, actual, DesignerEqualityComparer.Instance);
		}

		public static async Task GetAllDesignersWithProducts(Func<Task<Designer[]>> queryMethod)
		{
			// Arrange.
			Designer[] expected = TestData.AllDesigners;
			Designer[] expectedWithProducts = TestData.Designers;

			// Act.
			Designer[] actual = await queryMethod();
			Designer[] actualWithProducts = actual
				.Where(designer => designer.Products.Count > 0)
				.ToArray();

			// Assert.
			CollectionAssert.That.AreEquivalent(expected, actual, DesignerEqualityComparer.Instance);

			CollectionAssert.That.AreEquivalent(
				expectedWithProducts,
				actualWithProducts,
				DesignerEqualityComparer.Instance,
				$"Актуальная коллекция элементов типа '{nameof(Designer)}' с заполненными коллекциями '{nameof(Designer.Products)}' не эквивалентна ожидаемой.");

			foreach (Designer expectedDesigner in expectedWithProducts)
			{
				Designer actualDesigner = actualWithProducts.First(DesignerEqualityComparer.Instance.GetPredicate(expectedDesigner));

				CollectionAssert.That.AreEquivalent(
					expectedDesigner.Products,
					actualDesigner.Products,
					ProductEqualityComparer.Instance,
					$"Актуальная коллекция '{nameof(Designer.Products)}' не эквивалентна ожидаемой.");
			}
		}

		public static async Task GetAllDesignersWithContactInfo(Func<Task<Designer[]>> queryMethod)
		{
			// Arrange.
			Designer[] expected = TestData.AllDesigners;
			ContactInfo[] expectedContactInfos = TestData.AllContactInfos;
			Designer[] expectedContactInfoDesigners = TestData.AllDesigners;

			// Act.
			Designer[] actual = await queryMethod();
			ContactInfo[] actualContactInfos = actual
				.Select(designer => designer.ContactInfo)
				.Where(contactInfo => contactInfo is not null)
				.ToArray();
			Designer[] actualContactInfoDesigners = actualContactInfos
				.Select(contactInfo => contactInfo.Designer)
				.Where(designer => designer is not null)
				.ToArray();

			// Assert.
			CollectionAssert.That.AreEquivalent(expected, actual, DesignerEqualityComparer.Instance);
			CollectionAssert.That.AreEquivalent(expectedContactInfos, actualContactInfos, ContactInfoEqualityComparer.Instance);
			CollectionAssert.That.AreEquivalent(expectedContactInfoDesigners, actualContactInfoDesigners, DesignerEqualityComparer.Instance);
		}

		public static async Task GetAllDesignersWithClients(Func<Task<Designer[]>> queryMethod)
		{
			// Arrange.
			Designer[] expected = TestData.AllDesigners;
			Designer[] expectedWithClients = TestData.Designers;
			Client[] expectedClients = TestData.Clients;

			// Act.
			Designer[] actual = await queryMethod();
			Designer[] actualWithClients = actual
				.Where(designer => designer.Clients.Count > 0)
				.ToArray();
			Client[] actualClients = actualWithClients
				.SelectMany(designer => designer.Clients)
				.Distinct(ClientEqualityComparer.Instance)
				.ToArray();

			// Assert.
			CollectionAssert.That.AreEquivalent(expected, actual, DesignerEqualityComparer.Instance);

			CollectionAssert.That.AreEquivalent(
				expectedWithClients,
				actualWithClients,
				DesignerEqualityComparer.Instance,
				$"Актуальная коллекция элементов типа '{nameof(Designer)}' с заполненными коллекциями '{nameof(Designer.Clients)}' не эквивалентна ожидаемой.");

			foreach (Designer expectedDesigner in expectedWithClients)
			{
				Designer actualDesigner = actualWithClients.First(DesignerEqualityComparer.Instance.GetPredicate(expectedDesigner));

				CollectionAssert.That.AreEquivalent(
					expectedDesigner.Clients,
					actualDesigner.Clients,
					ClientEqualityComparer.Instance,
					$"Актуальная коллекция '{nameof(Designer.Clients)}' не эквивалентна ожидаемой.");
			}

			//foreach (Client expectedClient in expectedClients)
			//{
			//	Client actualClient = actualClients.First(ClientEqualityComparer.Instance.GetPredicate(expectedClient));

			//	CollectionAssert.That.AreEquivalent(
			//		expectedClient.Designers,
			//		actualClient.Designers,
			//		DesignerEqualityComparer.Instance,
			//		$"Актуальная коллекция '{nameof(Client.Designers)}' не эквивалентна ожидаемой.");
			//}
		}

		public static async Task GetProjectedDesigners(Func<Task<MiniDesigner[]>> queryMethod)
		{
			// Arrange.
			MiniDesigner[] expected = TestData.AllMiniDesigners;

			// Act.
			MiniDesigner[] actual = await queryMethod();

			// Assert.
			CollectionAssert.That.AreEquivalent(expected, actual, MiniDesignerEqualityComparer.Instance);
		}

		public static async Task GetFilteredDesigners(Func<Task<Designer[]>> queryMethod)
		{
			// Arrange.
			Designer[] expected = TestData.AllDesigners
				.Where(designer => designer.Dapperness == Dapperness.PrettyDapper)
				.ToArray();

			// Act.
			Designer[] actual = await queryMethod();

			// Assert.
			CollectionAssert.That.AreEquivalent(expected, actual, DesignerEqualityComparer.Instance);
		}

		public static async Task GetFilteredAndOrderedDesigners(Func<Task<Designer[]>> queryMethod)
		{
			// Arrange.
			Designer[] expected = TestData.AllDesigners
				.Where(designer => designer.Dapperness == Dapperness.KindaDapper)
				.OrderBy(designer => designer.LabelName)
				.ToArray();

			// Act.
			Designer[] actual = await queryMethod();

			// Assert.
			CollectionAssert.That.AreEquivalent(expected, actual, DesignerEqualityComparer.Instance);
		}
	}
}
