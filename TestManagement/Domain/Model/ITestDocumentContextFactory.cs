namespace TestManagement.Domain.Model
{
	/// <summary>
	/// テストドキュメントのコンテキストのファクトリー
	/// </summary>
	public interface ITestDocumentContextFactory
	{
		#region Methods

		/// <summary>
		/// コンテキストを作成します。
		/// </summary>
		/// <returns>作成したコンテキストを返します。</returns>
		ITestDocumentContext CreateContext();

		#endregion
	}
}
