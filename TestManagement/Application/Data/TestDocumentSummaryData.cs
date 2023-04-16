namespace TestManagement.Application.Data
{
    /// <summary>
    /// テストドキュメント概要のデータ
    /// </summary>
	public class TestDocumentSummaryData
	{
		#region Constructors

		/// <summary>
		/// テストドキュメント概要のデータを初期化します。
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">名称</param>
		/// <param name="version">バージョン</param>
		/// <param name="targetCount">対象数</param>
		public TestDocumentSummaryData(string id, string name, string version, int targetCount)
		{
			Id = id;
			Name = name;
			Version = version;
			TargetCount = targetCount;
		}

		#endregion

		#region Properties

		/// <summary>
		/// IDを取得します。
		/// </summary>
		public string Id { get; }

		/// <summary>
		/// 名称を取得します。
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// バージョンを取得します。
		/// </summary>
		public string Version { get; }

		/// <summary>
		/// 対象数を取得します。
		/// </summary>
		public int TargetCount { get; }

		#endregion
		
        #region Methods

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列。</returns>
        public override string ToString()
		{
			return $"{nameof(TestDocumentSummaryData)} {{ {nameof(Id)} = {Id}, {nameof(Name)} = {Name}, {nameof(Version)} = {Version}, {nameof(TargetCount)} = {TargetCount} }}";
		}

		#endregion
	}
}