namespace TestManagement.Domain.Model
{
	/// <summary>
	/// テストドキュメントのコンテキスト
	/// </summary>
	public interface ITestDocumentContext : IDisposable
	{
		#region Properties

		/// <summary>
		/// リポジトリーを取得します。
		/// </summary>
		ITestDocumentRepository Repository { get; }

		#endregion

		#region Methods

		/// <summary>
		/// コミットします。
		/// </summary>
		void Commit();

		/// <summary>
		/// ロールバックします。
		/// </summary>
		void Rollback();

		#endregion
	}
}
