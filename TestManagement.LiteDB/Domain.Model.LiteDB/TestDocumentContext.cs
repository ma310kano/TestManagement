using LiteDB;

namespace TestManagement.Domain.Model.LiteDB
{
	/// <summary>
	/// テストドキュメントのコンテキスト
	/// </summary>
	public class TestDocumentContext : ITestDocumentContext
	{
		#region Fields

		/// <summary>
		/// データベース
		/// </summary>
		private readonly ILiteDatabase _database;

		/// <summary>
		/// リポジトリー
		/// </summary>
		private ITestDocumentRepository? _repository;

		/// <summary>
		/// 破棄したかどうか
		/// </summary>
		private bool disposedValue;

		#endregion

		#region Constructors

		/// <summary>
		/// テストドキュメントのコンテキストを初期化します。
		/// </summary>
		/// <param name="connectionString">接続文字列</param>
		public TestDocumentContext(string connectionString)
		{
			_database = new LiteDatabase(connectionString);
		}

		#endregion

		#region Properties

		/// <summary>
		/// リポジトリーを取得します。
		/// </summary>
		public ITestDocumentRepository Repository => _repository ??= new TestDocumentRepository(_database);

		#endregion

		/// <summary>
		/// コミットします。
		/// </summary>
		public void Commit()
		{
			_database.Commit();
		}

		/// <summary>
		/// ロールバックします。
		/// </summary>
		public void Rollback()
		{
			_database.Rollback();
		}

		/// <summary>
		/// アンマネージ リソースの解放またはリセットに関連付けられているアプリケーション定義のタスクを実行します。
		/// </summary>
		/// <param name="disposing">破棄かどうか</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_database.Dispose();
				}

				disposedValue = true;
			}
		}

		/// <summary>
		/// アンマネージ リソースの解放またはリセットに関連付けられているアプリケーション定義のタスクを実行します。
		/// </summary>
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
