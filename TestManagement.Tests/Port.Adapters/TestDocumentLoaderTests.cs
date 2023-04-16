using TestManagement.Domain.Model;

namespace TestManagement.Port.Adapters
{
    /// <summary>
    /// テストドキュメントのテスト
    /// </summary>
    public class TestDocumentLoaderTests
    {
        #region Methods

        [Fact]
        public void Method_Load_Passing()
        {
            ITestDocumentLoader loader = new TestDocumentLoader();

            TestDocument doc = loader.Load(".\\TestDocument.json");

            Assert.NotNull(doc);
        }

        #endregion
    }
}