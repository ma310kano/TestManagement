using System.Text.Json;
using TestManagement.Domain.Model;

namespace TestManagement.Port.Adapters
{
	/// <summary>
	/// テストドキュメントを読み込む機能
	/// </summary>
	public class TestDocumentLoader : ITestDocumentLoader
	{
		#region Methods

		/// <summary>
		/// テストドキュメントを読み込みます。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>読み込んだテストドキュメントを返します。</returns>
		public TestDocument Load(string filePath)
		{
			using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

			TestDocument doc = JsonSerializer.Deserialize<TestDocument>(stream) ?? throw new InvalidOperationException("テストドキュメントが読み込みできませんでした。");

			return doc;
		}

		#endregion
	}
}
