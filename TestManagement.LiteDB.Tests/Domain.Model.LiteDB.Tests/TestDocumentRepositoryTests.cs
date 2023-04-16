using LiteDB;

namespace TestManagement.Domain.Model.LiteDB.Tests
{
	/// <summary>
	/// テストドキュメントのコンテキストのテスト
	/// </summary>
	public class TestDocumentContextTests
	{
		#region Methods

		[Fact]
		public void Method_Save_Passing()
		{
			using ILiteDatabase database = new LiteDatabase(".\\TestDocument.db");

			ITestDocumentRepository repository = new TestDocumentRepository(database);

			TestDocument document;
			{
				TestDocumentKey id = new("Id");
				TestDocumentName name = new("名称");
				TestDocumentVersion version = new("1.0");
				List<TestTarget> targets = new ();

				document = new TestDocument(id, name, version, targets);
			}

			repository.Save(document);
		}

		#endregion
	}
}
