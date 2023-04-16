using Microsoft.Extensions.Configuration;

namespace TestManagement.Domain.Model.LiteDB
{
	/// <summary>
	/// テストドキュメントのコンテキストのファクトリー
	/// </summary>
	public class TestDocumentContextFactory : ITestDocumentContextFactory
	{
		#region Fields

		/// <summary>
		/// 接続文字列
		/// </summary>
		private readonly string _connectionString;

		#endregion

		#region Constructors

		/// <summary>
		/// テストドキュメントのコンテキストのファクトリーを初期化します。
		/// </summary>
		/// <param name="configuration">設定</param>
		public TestDocumentContextFactory(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("TestManagement") ?? throw new InvalidOperationException("接続文字列が取得できません。");
		}

		#endregion

		#region Methods

		/// <summary>
		/// コンテキストを作成します。
		/// </summary>
		/// <returns>作成したコンテキストを返します。</returns>
		public ITestDocumentContext CreateContext()
		{
			ITestDocumentContext context = new TestDocumentContext(_connectionString);

			return context;
		}

		#endregion
	}
}
