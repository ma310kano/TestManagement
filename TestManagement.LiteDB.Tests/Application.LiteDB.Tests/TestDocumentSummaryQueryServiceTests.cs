using Microsoft.Extensions.Configuration;
using TestManagement.Application.Data;

namespace TestManagement.Application.LiteDB.Tests
{
	/// <summary>
	/// テストドキュメント概要のクエリサービスのテスト
	/// </summary>
	public class TestDocumentSummaryQueryServiceTests
	{
		#region Methods

		/// <summary>
		/// Queryメソッドの疎通をテストします。
		/// </summary>
		[Fact]
		public void Method_Query_Passing()
		{
			IConfiguration configuration = new ConfigurationBuilder().
				SetBasePath(Directory.GetCurrentDirectory()).
				AddJsonFile("appsettings.json").
				Build();

			ITestDocumentSummaryQueryService service = new TestDocumentSummaryQueryService(configuration);

			IEnumerable<TestDocumentSummaryData> summaries = service.Query();
			Assert.NotNull(summaries);
		}

		#endregion
	}
}
