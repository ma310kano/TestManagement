namespace TestManagement.Domain.Model
{
	/// <summary>
	/// テストドキュメントのリポジトリー
	/// </summary>
	public interface ITestDocumentRepository
	{
		#region Methods

		/// <summary>
		/// テストドキュメントを保存します。
		/// </summary>
		/// <param name="document">ドキュメント</param>
		void Save(TestDocument document);

		#endregion
	}
}
