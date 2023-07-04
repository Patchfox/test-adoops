using FluentAssertions;
using NUnit.Framework;
using AzAdo;

namespace Tests
{
	public class AzAdoConnectionObjectTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ValidClassicOrganizationUrlParseTest()
		{
			var conn = AzAdoConnectObject.CreateFromUrl("https://3pager.visualstudio.com");

			conn.OrganizationName.Should().BeEquivalentTo("3pager");
			conn.ProjectName.Should().BeNullOrEmpty();
			conn.OrganizationUrl.Should().BeEquivalentTo("https://dev.azure.com/3pager");
			conn.ProjectUrl.Should().BeNullOrEmpty();
		}

		[Test]
		public void InValidClassicOrganizationUrlParseTest()
		{
			var conn = AzAdoConnectObject.CreateFromUrl("https://visualstudio.com/3pager/3pager");

			conn.OrganizationName.Should().BeNullOrEmpty();
			conn.ProjectName.Should().BeNullOrEmpty();
			conn.OrganizationUrl.Should().BeNullOrEmpty();
			conn.ProjectUrl.Should().BeNullOrEmpty();
		}

		[Test]
		public void ValidClassicProjectUrlParseTest()
		{
			var conn = AzAdoConnectObject.CreateFromUrl("https://3pager.visualstudio.com/3pager");

			conn.OrganizationName.Should().BeEquivalentTo("3pager");
			conn.ProjectName.Should().BeEquivalentTo("3pager");
			conn.OrganizationUrl.Should().BeEquivalentTo("https://dev.azure.com/3pager");
			conn.ProjectUrl.Should().BeEquivalentTo("https://dev.azure.com/3Pager/3pager");
		}

		[Test]
		public void ValidOrganizationUrlParseTest()
		{
			var conn = AzAdoConnectObject.CreateFromUrl("https://dev.azure.com/3pager/");

			conn.OrganizationName.Should().BeEquivalentTo("3pager");
			conn.ProjectName.Should().BeNullOrEmpty();
			conn.OrganizationUrl.Should().BeEquivalentTo("https://dev.azure.com/3pager");
			conn.ProjectUrl.Should().BeNullOrEmpty();
		}

		[Test]
		public void ValidProjectUrlParseTest()
		{
			var conn = AzAdoConnectObject.CreateFromUrl("https://dev.azure.com/3pager/3pager");

			conn.OrganizationName.Should().BeEquivalentTo("3pager");
			conn.ProjectName.Should().BeEquivalentTo("3pager");
			conn.OrganizationUrl.Should().BeEquivalentTo("https://dev.azure.com/3pager");
			conn.ProjectUrl.Should().BeEquivalentTo("https://dev.azure.com/3Pager/3pager");
		}
	}
}