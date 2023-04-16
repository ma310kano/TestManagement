namespace TestManagement.Domain.Model
{
    /// <summary>
    /// テストドキュメント
    /// </summary>
    public class TestDocument : IEquatable<TestDocument>
    {
        #region Constructors

        /// <summary>
        /// テストドキュメントを初期化します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <param name="version">バージョン</param>
        /// <param name="targets">対象のコレクション</param>
        public TestDocument(TestDocumentKey id, TestDocumentName name, TestDocumentVersion version, IReadOnlyList<TestTarget> targets)
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
        public TestDocumentKey Id { get; }

        /// <summary>
        /// 名称を取得します。
        /// </summary>
        public TestDocumentName Name { get; }

        /// <summary>
        /// バージョンを取得します。
        /// </summary>
        public TestDocumentVersion Version { get; }

        /// <summary>
        /// 対象のコレクションを取得します。
        /// </summary>
        public IReadOnlyList<TestTarget> Targets { get; }

        #endregion
        
        #region Operators

        /// <summary>
        /// オペランドが等しい場合には <c>true</c> を返し、それ以外の場合は <c>false</c> を返します。
        /// </summary>
        /// <param name="lhs">左辺</param>
        /// <param name="rhs">右辺</param>
        /// <returns>オペランドが等しい場合は、 <c>true</c>。それ以外の場合は、 <c>false</c>。</returns>
        public static bool operator ==(TestDocument lhs, TestDocument rhs)
        {
            if (lhs is null) return rhs is null;

            bool result = lhs.Equals(rhs);

            return result;
        }

        /// <summary>
        /// オペランドが等しくない場合には <c>true</c> を返し、それ以外の場合は <c>false</c> を返します。
        /// </summary>
        /// <param name="lhs">左辺</param>
        /// <param name="rhs">右辺</param>
        /// <returns>オペランドが等しくない場合は、 <c>true</c>。それ以外の場合は、 <c>false</c>。</returns>
        public static bool operator !=(TestDocument lhs, TestDocument rhs)
        {
            bool result = !(lhs == rhs);

            return result;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// 指定されたオブジェクトが現在のオブジェクトと等しいかどうかを判断します。
        /// </summary>
        /// <param name="obj">現在のオブジェクトと比較するオブジェクト。</param>
        /// <returns>指定したオブジェクトが現在のオブジェクトと等しい場合は <c>true</c>。それ以外の場合は <c>false</c>。</returns>
        public override bool Equals(object? obj)
        {
            bool result = obj switch
            {
                TestDocument other => Equals(other),
                _ => base.Equals(obj),
            };

            return result;
        }

        /// <summary>
        /// 現在のオブジェクトが、同じ型の別のオブジェクトと等しいかどうかを示します。
        /// </summary>
        /// <param name="other">このオブジェクトと比較するオブジェクト。</param>
        /// <returns>現在のオブジェクトが <c>other</c> パラメーターと等しい場合は <c>true</c>、それ以外の場合は <c>false</c> です。</returns>
        public bool Equals(TestDocument? other)
        {
            if (other is null) return false;

            bool result = Id == other.Id;

            return result;
        }

        /// <summary>
        /// 既定のハッシュ関数として機能します。
        /// </summary>
        /// <returns>現在のオブジェクトのハッシュ コード。</returns>
        public override int GetHashCode()
        {
            int result = HashCode.Combine(Id);

            return result;
        }

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列。</returns>
        public override string ToString()
        {
            return $"{nameof(TestDocument)} {{ {nameof(Id)} = {Id}, {nameof(Name)} = {Name}, {nameof(Version)} = {Version}, {nameof(Targets)} = {Targets.Count} }}";
        }

        #endregion
    }
}