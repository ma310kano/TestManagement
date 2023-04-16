namespace TestManagement.Application.Data
{
    /// <summary>
    /// テストドキュメントデータ
    /// </summary>
	public class TestDocumentData
	{
		#region Constructors

		/// <summary>
		/// テストドキュメントデータを初期化します。
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">名称</param>
		/// <param name="version">バージョン</param>
		/// <param name="targets">対象のコレクション</param>
		public TestDocumentData(string id, string name, string version, IReadOnlyList<TestTargetData> targets)
		{
			Id = id;
			Name = name;
			Version = version;
			Targets = targets;
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
		/// 対象のコレクションを取得します。
		/// </summary>
		public IReadOnlyList<TestTargetData> Targets { get; }

		#endregion
		
        #region Methods

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列。</returns>
        public override string ToString()
		{
			return $"{nameof(TestDocumentData)} {{ {nameof(Id)} = {Id}, {nameof(Name)} = {Name}, {nameof(Version)} = {Version}, {nameof(Targets)} = {Targets.Count} }}";
		}

		#endregion
	}
}