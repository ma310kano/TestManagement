namespace TestManagement.Domain.Model
{
    /// <summary>
    /// テスト項目
    /// </summary>
	public class TestItem
	{
		#region Constructors

		/// <summary>
		/// テスト項目を初期化します。
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="executionPrerequisites">実行前提条件のコレクション</param>
		/// <param name="executionProcedures">実行手順のコレクション</param>
		/// <param name="expectedResults">期待結果のコレクション</param>
		public TestItem(TestItemName name, List<ExecutionPrerequisite> executionPrerequisites, List<ExecutionProcedure> executionProcedures, List<ExpectedResult> expectedResults)
		{
			Name = name;
			ExecutionPrerequisites = executionPrerequisites;
			ExecutionProcedures = executionProcedures;
			ExpectedResults = expectedResults;
		}

		#endregion

		#region Properties

		/// <summary>
		/// 名称を取得します。
		/// </summary>
		public TestItemName Name { get; }

		/// <summary>
		/// 実行前提条件のコレクションを取得します。
		/// </summary>
		public List<ExecutionPrerequisite> ExecutionPrerequisites { get; }

		/// <summary>
		/// 実行手順のコレクションを取得します。
		/// </summary>
		public List<ExecutionProcedure> ExecutionProcedures { get; }

		/// <summary>
		/// 期待結果のコレクションを取得します。
		/// </summary>
		public List<ExpectedResult> ExpectedResults { get; }

		#endregion
		
        #region Methods

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列。</returns>
        public override string ToString()
		{
			return $"{nameof(TestItem)} {{ {nameof(Name)} = {Name}, {nameof(ExecutionPrerequisites)} = {ExecutionPrerequisites.Count}, {nameof(ExecutionProcedures)} = {ExecutionProcedures.Count}, {nameof(ExpectedResults)} = {ExpectedResults.Count} }}";
		}

		#endregion
	}
}