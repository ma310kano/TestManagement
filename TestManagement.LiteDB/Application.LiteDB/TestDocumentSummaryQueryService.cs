using LiteDB;
using Microsoft.Extensions.Configuration;
using TestManagement.Application.Data;

namespace TestManagement.Application.LiteDB
{
	/// <summary>
	/// テストドキュメント概要のクエリサービス
	/// </summary>
	public class TestDocumentSummaryQueryService : ITestDocumentSummaryQueryService
	{
		#region Fields

		/// <summary>
		/// マッパー
		/// </summary>
		private static readonly BsonMapper s_mapper;

		/// <summary>
		/// 接続文字列
		/// </summary>
		private readonly string _connectionString;

		#endregion

		#region Constructors

		/// <summary>
		/// テストドキュメント概要のクエリサービスを初期化します。
		/// </summary>
		static TestDocumentSummaryQueryService()
		{
			s_mapper = new BsonMapper();
			s_mapper.RegisterType(
				serialize: _ =>
				{
					return BsonValue.Null;
				},
				deserialize: bson =>
				{
					string id = bson["_id"]["Value"].AsString;
					string name = bson["Name"]["Value"].AsString;
					string version = bson["Version"]["Value"].AsString;
					int targetCount = bson["Targets"].AsArray.Count;

					return new TestDocumentSummaryData(id, name, version, targetCount);
				}
			);
		}

		/// <summary>
		/// テストドキュメント概要のクエリサービスを初期化します。
		/// </summary>
		/// <param name="configuration">設定</param>
		public TestDocumentSummaryQueryService(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("TestManagement") ?? throw new InvalidOperationException("接続文字列が取得できません。");
		}

		#endregion

		#region Methods

		/// <summary>
		/// テストドキュメント概要を問い合わせします。
		/// </summary>
		/// <returns>問い合わせしたテストドキュメント概要データのコレクションを返します。</returns>
		public IEnumerable<TestDocumentSummaryData> Query()
		{
			using ILiteDatabase database = new LiteDatabase(_connectionString, s_mapper);

			ILiteCollection<TestDocumentSummaryData> collection = database.GetCollection<TestDocumentSummaryData>("TestDocuments");

			List<TestDocumentSummaryData> summaries = collection.FindAll().ToList();

			return summaries;
		}

		/// <summary>
		/// テストドキュメント概要を問い合わせします。
		/// </summary>
		/// <returns>問い合わせしたテストドキュメント概要データのコレクションを返します。</returns>
		public async Task<IEnumerable<TestDocumentSummaryData>> QueryAsync()
		{
			return await Task.Run(Query);
		}

		#endregion
	}
}
