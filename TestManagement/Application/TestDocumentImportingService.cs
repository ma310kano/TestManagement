using TestManagement.Domain.Model;
using TestManagement.Port.Adapters;

namespace TestManagement.Application
{
	/// <summary>
	/// テストドキュメントのインポートサービス
	/// </summary>
	public class TestDocumentImportingService : ITestDocumentImportingService
	{
		#region Fields

		/// <summary>
		/// 読み込みする機能
		/// </summary>
		private readonly ITestDocumentLoader _loader;

		/// <summary>
		/// コンテキストのファクトリー
		/// </summary>
		private readonly ITestDocumentContextFactory _contextFactory;

		#endregion

		#region Constructors

		/// <summary>
		/// テストドキュメントの読み込みサービスを初期化します。
		/// </summary>
		/// <param name="loader">読み込みする機能</param>
		/// <param name="contextFactory">コンテキストのファクトリー</param>
		public TestDocumentImportingService(ITestDocumentLoader loader, ITestDocumentContextFactory contextFactory)
		{
			_loader = loader;
			_contextFactory = contextFactory;
		}

		#endregion

		#region Methods

		/// <summary>
		/// テストドキュメントをインポートします。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		public void Import(string filePath)
		{
			TestDocument document = _loader.Load(filePath);

			using ITestDocumentContext context = _contextFactory.CreateContext();

			try
			{
				context.Repository.Save(document);

				context.Commit();
			}
			catch
			{
				context.Rollback();
				throw;
			}
		}

		/// <summary>
		/// テストドキュメントをインポートします。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		public async Task ImportAsync(string filePath)
		{
			await Task.Run(() => Import(filePath));
		}

		#endregion
	}
}
