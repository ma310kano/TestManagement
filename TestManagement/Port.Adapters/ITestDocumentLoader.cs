using TestManagement.Domain.Model;

namespace TestManagement.Port.Adapters
{
	/// <summary>
	/// テストドキュメントを読み込む機能
	/// </summary>
	public interface ITestDocumentLoader
	{
		#region Methods

		/// <summary>
		/// テストドキュメントを読み込みます。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>読み込んだテストドキュメントを返します。</returns>
		TestDocument Load(string filePath);

		#endregion
	}
}