
using Xunit;
namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class HikerTest
    {
        [Fact(Skip = "TODO")]
        public void Foobar()
        {
            UnicodeFileToHtmlTextConverter converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
            Assert.Equal("fixme", converter.GetFilename());
        }
    }
}
