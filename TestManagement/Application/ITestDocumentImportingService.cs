namespace TestManagement.Application
{
	/// <summary>
	/// テストドキュメントのインポートサービス
	/// </summary>
	public interface ITestDocumentImportingService
	{
		#region Methods

		/// <summary>
		/// テストドキュメントをインポートします。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		void Import(string filePath);

		/// <summary>
		/// テストドキュメントをインポートします。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		Task ImportAsync(string filePath);

		#endregion
	}
}
