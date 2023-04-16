using TestManagement.Application.Data;

namespace TestManagement.Application
{
	/// <summary>
	/// テストドキュメント概要のクエリサービス
	/// </summary>
	public interface ITestDocumentSummaryQueryService
	{
		#region Methods

		/// <summary>
		/// テストドキュメント概要を問い合わせします。
		/// </summary>
		/// <returns>問い合わせしたテストドキュメント概要データのコレクションを返します。</returns>
		IEnumerable<TestDocumentSummaryData> Query();

		/// <summary>
		/// テストドキュメント概要を問い合わせします。
		/// </summary>
		/// <returns>問い合わせしたテストドキュメント概要データのコレクションを返します。</returns>
		Task<IEnumerable<TestDocumentSummaryData>> QueryAsync();

		#endregion
	}
}
