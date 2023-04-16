using LiteDB;

namespace TestManagement.Domain.Model.LiteDB
{
	/// <summary>
	/// テストドキュメントのリポジトリー
	/// </summary>
	public class TestDocumentRepository : ITestDocumentRepository
	{
		#region Fields

		/// <summary>
		/// コレクション
		/// </summary>
		private readonly ILiteCollection<TestDocument> _collection;

		#endregion

		#region Constructors

		/// <summary>
		/// テストドキュメントのリポジトリーを初期化します。
		/// </summary>
		/// <param name="database">データベース</param>
		public TestDocumentRepository(ILiteDatabase database)
		{
			_collection = database.GetCollection<TestDocument>("TestDocuments");
		}

		#endregion

		#region Methods

		/// <summary>
		/// テストドキュメントを保存します。
		/// </summary>
		/// <param name="document">ドキュメント</param>
		public void Save(TestDocument document)
		{
			_collection.Upsert(document);
		}

		#endregion
	}
}
