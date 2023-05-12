using LiteDB;
using Microsoft.Extensions.Configuration;
using TestManagement.Application.Data;

namespace TestManagement.Application.LiteDB
{
	/// <summary>
	/// テストドキュメントのクエリサービス
	/// </summary>
	public class TestDocumentQueryService : ITestDocumentQueryService
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
		/// テストドキュメントのクエリサービスを初期化します。
		/// </summary>
		static TestDocumentQueryService()
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

					List<TestTargetData> targets = new();
					{
						BsonArray targetSources = bson["Targets"].AsArray;
						foreach (BsonValue targetSource in targetSources)
						{
							string targetName = targetSource["Name"]["Value"].AsString;

							List<TestItemData> items = new();
							{
								BsonArray itemSources = targetSource["Items"].AsArray;
								foreach (BsonValue itemSource in itemSources)
								{
									string itemName = itemSource["Name"]["Value"].AsString;

									List<string> executionPrerequisites = itemSource["ExecutionPrerequisites"].AsArray.Select(x => x["Value"].AsString).ToList();
									List<string> executionProcedures = itemSource["ExecutionProcedures"].AsArray.Select(x => x["Value"].AsString).ToList();
									List<string> expectedResults = itemSource["ExpectedResults"].AsArray.Select(x => x["Value"].AsString).ToList();

									TestItemData item = new(itemName, executionPrerequisites, executionProcedures, expectedResults);
									items.Add(item);
								}
							}

							TestTargetData target = new(targetName, items);
							targets.Add(target);
						}
					}

					return new TestDocumentData(id, name, version, targets);
				});
		}

		/// <summary>
		/// テストドキュメントのクエリサービスを初期化します。
		/// </summary>
		/// <param name="configuration">設定</param>
		public TestDocumentQueryService(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("TestManagement") ?? throw new InvalidOperationException("接続文字列が取得できません。");
		}

		#endregion

		#region Methods

		/// <summary>
		/// テストドキュメントを問い合わせします。
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>問い合わせしたテストドキュメントを返します。</returns>
		public TestDocumentData QuerySingle(string id)
		{
			using ILiteDatabase database = new LiteDatabase(_connectionString, s_mapper);

			ILiteCollection<TestDocumentData> collection = database.GetCollection<TestDocumentData>("TestDocuments");

			BsonDocument idDoc;
			{
				IDictionary<string, BsonValue> dic = new Dictionary<string, BsonValue>
				{
					{ "Value", id }
				};

				idDoc = new(dic);
			}

			TestDocumentData document = collection.FindById(idDoc);

			return document;
		}

		/// <summary>
		/// テストドキュメントを問い合わせします。
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>問い合わせしたテストドキュメントを返します。</returns>
		public Task<TestDocumentData> QuerySingleAsync(string id)
		{
			return Task.Run(() => QuerySingle(id));
		}

		#endregion
	}
}
