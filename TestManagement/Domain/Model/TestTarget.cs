namespace TestManagement.Domain.Model
{
	/// <summary>
	/// テスト対象
	/// </summary>
	public class TestTarget
	{
		#region Methods

		/// <summary>
		/// テスト対象を初期化します。
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="items">項目のコレクション</param>
		public TestTarget(TestTargetName name, IReadOnlyList<TestItem> items)
		{
			Name = name;
			Items = items;
		}

		#endregion

		#region Properties

		/// <summary>
		/// 名称を取得します。
		/// </summary>
		public TestTargetName Name { get; }

		/// <summary>
		/// 項目のコレクションを取得します。
		/// </summary>
		public IReadOnlyList<TestItem> Items { get; }

		#endregion

		#region Methods

		/// <summary>
		/// 現在のオブジェクトを表す文字列を返します。
		/// </summary>
		/// <returns>現在のオブジェクトを表す文字列。</returns>
		public override string ToString()
		{
			return $"{nameof(TestTarget)} {{ {nameof(Name)} = {Name}, {nameof(Items)} = {Items.Count} }}";
		}

		#endregion
	}
}
