using System.Text.RegularExpressions;

namespace TestManagement
{
    /// <summary>
    /// テストドキュメントのバージョン
    /// </summary>
    public class TestDocumentVersion
    {
        #region Fields

        /// <summary>
        /// デフォルト
        /// </summary>
        public static readonly TestDocumentVersion Default = new(string.Empty);

		#endregion

		#region Constructors

		/// <summary>
		/// テストドキュメントのバージョンを初期化します。
		/// </summary>
		/// <param name="value">値</param>
		public TestDocumentVersion(string value)
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
        public static bool operator ==(TestDocumentVersion lhs, TestDocumentVersion rhs)
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
        public static bool operator !=(TestDocumentVersion lhs, TestDocumentVersion rhs)
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
            const string pattern = "^[0-9A-Za-z\\-\\.]{0,20}$";
            bool success = Regex.IsMatch(s, pattern);

            if (success)
            {
                message = string.Empty;
            }
            else
            {
                message = "テストバージョンは、半角数字20桁(ハイフン・ドット含む)で入力してください。";
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
                TestDocumentVersion other => Equals(other),
                _ => base.Equals(obj),
            };

            return result;
        }

        /// <summary>
        /// 現在のオブジェクトが、同じ型の別のオブジェクトと等しいかどうかを示します。
        /// </summary>
        /// <param name="other">このオブジェクトと比較するオブジェクト。</param>
        /// <returns>現在のオブジェクトが <c>other</c> パラメーターと等しい場合は <c>true</c>、それ以外の場合は <c>false</c> です。</returns>
        public bool Equals(TestDocumentVersion? other)
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