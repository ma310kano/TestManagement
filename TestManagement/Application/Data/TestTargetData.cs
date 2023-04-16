namespace TestManagement.Application.Data
{
    /// <summary>
    /// テスト対象データ
    /// </summary>
	public class TestTargetData
	{
		#region Constructors

		/// <summary>
		/// テスト対象データを初期化します。
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="items">項目のコレクション</param>
		public TestTargetData(string name, IReadOnlyList<TestItemData> items)
		{
			Name = name;
			Items = items;
		}

		#endregion

		#region Properties

		/// <summary>
		/// 名称を取得します。
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// 項目のコレクションを取得します。
		/// </summary>
		public IReadOnlyList<TestItemData> Items { get; }

		#endregion
		
        #region Methods

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列。</returns>
        public override string ToString()
		{
			return $"{nameof(TestTargetData)} {{ {nameof(Name)} = {Name}, {nameof(Items)} = {Items.Count} }}";
		}

		#endregion
	}
}