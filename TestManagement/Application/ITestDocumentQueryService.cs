using TestManagement.Application.Data;

namespace TestManagement.Application
{
	/// <summary>
	/// テストドキュメントのクエリサービス
	/// </summary>
	public interface ITestDocumentQueryService
	{
		#region Methods

		/// <summary>
		/// テストドキュメントを問い合わせします。
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>問い合わせしたテストドキュメントを返します。</returns>
		TestDocumentData QuerySingle(string id);

		/// <summary>
		/// テストドキュメントを問い合わせします。
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>問い合わせしたテストドキュメントを返します。</returns>
		Task<TestDocumentData> QuerySingleAsync(string id);

		#endregion
	}
}
