using AireLogic_TechTest.Songs;
using FluentAssertions;
using NUnit.Framework;

namespace AireLogic_TechTest.Tests
{
    [TestFixture]
    internal class LyricsTest
    {
        [Test]
        public void ShouldSplitLyricsStringByCharacter()
        {
            string testLyrics = "Paroles de la chanson Running Up That Hill par Kate Bush\r\nIt doesn't hurt me (Ye-yeah, yeah, yo)\nDo you want to feel how it feels? (Ye-yeah, yeah, yo)\nDo you want to know, know that it doesn't hurt me ? (Ye - yeah, yeah, yo)\nDo you want to hear about the deal that I'm making? (Ye-yeah, yeah, yo)\n\nYou\nIt's you and me\n\nAnd if I only could\nI'd make a deal with God\nAnd I'd get him to swap our places\nBe running up that road\nBe running up that hill\n\nBe running up that building\nSay, if I only could, oh\n\nYou don't wanna hurt me (Ye-yeah, yeah, yo)\nBut see how deep the bullet lies (Ye-yeah, yeah, yo)\nUnaware, I'm tearing you asunder(Ye-yeah, yeah, yo)\nOh, there is thunder in our hearts(Ye-yeah, yeah, yo)\nIs there so much hate for the ones we love ? (Ye - yeah, yeah, yo)\nOh, tell me, we both matter, don't we? (Ye-yeah, yeah, yo)\n\nYou\nIt's you and me\nIt's you and me, won't be unhappy\n\n\nAnd if I only could\nI'd make a deal with God\nAnd I'd get him to swap our places\nBe running up that road\nBe running up that hill\nBe running up that building(Ye - yo)\nSay, if I only could, oh\n\nYou(Ye - yeah, yeah, yo)\nIt's you and me\nIt's you and me, won't be unhappy (Ye-yeah, yeah, yo)\n\nOh, come on, baby (Ye-yeah)\nOh, come on, darling (Ye-yo)\nLet me steal this moment from you now\nOh, come on, angel (Yeah)\n\nCome on, come on, darling\nLet's exchange the experience(Ye-oh, ooh, ooh)\n\nAnd if I only could\nI'd make a deal with God\nAnd I'd get him to swap our places\nI'd be running up that road\nBe running up that hill\nWith no problems\nSay, if I only could\nI'd make a deal with God\nAnd I'd get him to swap our places\nI'd be running up that road\nBe running up that hill\nWith no problems\nSay, if I only could\nI'd make a deal with God\nAnd I'd get him to swap our places\n\nI'd be running up that road\nBe running up that hill\nWith no problems\n\nSay, if I only could\nBe running up that hill\nWith no problems\nIf I only could, be running up that hill\nIf I only could, be running up that hill";
            var testSong = new Model.Songs();
            testSong.Lyrics = testLyrics;

            var result = Lyrics.SplitLyricsByCharacter(testSong);
            result.Length.Should().Be(342);
        }
        
    }
}
