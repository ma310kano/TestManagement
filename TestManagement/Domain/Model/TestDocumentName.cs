namespace TestManagement.Domain.Model
{
    /// <summary>
    /// テストドキュメント名
    /// </summary>
    public class TestDocumentName : IEquatable<TestDocumentName>
    {
        #region Fields

        /// <summary>
        /// 空
        /// </summary>
        public static readonly TestDocumentName Empty = new(string.Empty);

		#endregion

		#region Constructors

		/// <summary>
		/// テストドキュメント名を初期化します。
		/// </summary>
		/// <param name="value">値</param>
		public TestDocumentName(string value)
        {
            bool success = Validate(value, out string message);
            if (!success) throw new ArgumentException(message, nameof(value));

            Value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 値を取得します。
        /// </summary>
        public string Value { get; }

        #endregion
        
        #region Operators

        /// <summary>
        /// オペランドが等しい場合には <c>true</c> を返し、それ以外の場合は <c>false</c> を返します。
        /// </summary>
        /// <param name="lhs">左辺</param>
        /// <param name="rhs">右辺</param>
        /// <returns>オペランドが等しい場合は、 <c>true</c>。それ以外の場合は、 <c>false</c>。</returns>
        public static bool operator ==(TestDocumentName lhs, TestDocumentName rhs)
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
        public static bool operator !=(TestDocumentName lhs, TestDocumentName rhs)
        {
            bool result = !(lhs == rhs);

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 文字列を検証します。
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="message">メッセージ</param>
        /// <returns>検証に成功した場合は、 <c>true</c>。それ以外の場合は、 <c>false</c>。</returns>
        public static bool Validate(string s, out string message)
        {
            bool success = s.Length <= 20;

            if (success)
            {
                message = string.Empty;
            }
            else
            {
                message = "テスト名は、20桁以下で入力してください。";
            }

            return success;
        }
        
        /// <summary>
        /// 指定されたオブジェクトが現在のオブジェクトと等しいかどうかを判断します。
        /// </summary>
        /// <param name="obj">現在のオブジェクトと比較するオブジェクト。</param>
        /// <returns>指定したオブジェクトが現在のオブジェクトと等しい場合は <c>true</c>。それ以外の場合は <c>false</c>。</returns>
        public override bool Equals(object? obj)
        {
            bool result = obj switch
            {
                TestDocumentName other => Equals(other),
                _ => base.Equals(obj),
            };

            return result;
        }

        /// <summary>
        /// 現在のオブジェクトが、同じ型の別のオブジェクトと等しいかどうかを示します。
        /// </summary>
        /// <param name="other">このオブジェクトと比較するオブジェクト。</param>
        /// <returns>現在のオブジェクトが <c>other</c> パラメーターと等しい場合は <c>true</c>、それ以外の場合は <c>false</c> です。</returns>
        public bool Equals(TestDocumentName? other)
        {
            if (other is null) return false;

            bool result = Value == other.Value;

            return result;
        }

        /// <summary>
        /// 既定のハッシュ関数として機能します。
        /// </summary>
        /// <returns>現在のオブジェクトのハッシュ コード。</returns>
        public override int GetHashCode()
        {
            int result = HashCode.Combine(Value);

            return result;
        }

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列。</returns>
        public override string ToString()
        {
            return Value;
        }

        #endregion
    }
}