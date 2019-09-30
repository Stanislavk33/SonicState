using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SonicState.Contracts.Repositories;
using SonicState.Contracts.Services;
using SonicState.Models.ViewModels;
using SonicState.Repositories;
using SonicState.Services;
using System.Collections.Generic;

namespace SonicState.Tests
{
    [TestClass()]
    public class ChordSequenceServiceShould
    {
        private readonly ChordService chordService;
        private readonly Mock<IChordUnitRepository> mockChordUnitRepository = new Mock<IChordUnitRepository>();
        public ChordSequenceServiceShould()
        {
            this.chordService = new ChordService(mockChordUnitRepository.Object);
        }
        [TestMethod]
        public void ReturnChordSequence ()
        {
            //arrange
            //var mockValidator = new Mock<IChordUnitRepository>();
           // var mockChordUnitRepository = new Mock<ChordUnitRepository>();
           // var mockChordUnitDetails = new Mock<ChordUnitDetails>();

            var mockChordUnitCollection = new List<ChordUnitDetails>()
            {
                new ChordUnitDetails
                {
                    AudioId = "1",
                    Chord = "F#:7",
                    Time = 2.33
                },
                new ChordUnitDetails
                {
                    AudioId = "1",
                    Chord = "F#:7min",
                    Time = 3.33
                },
                new ChordUnitDetails
                {
                    AudioId = "1",
                    Chord = "F#:7",
                    Time = 4.33
                },
                new ChordUnitDetails
                {
                    AudioId = "1",
                    Chord = "F#:7min",
                    Time = 5.33
                },
                new ChordUnitDetails
                {
                    AudioId = "1",
                    Chord = "F#:7",
                    Time = 6.33
                }
            };
            string audioId = "1";

           mockChordUnitRepository.Setup(x => x.GenerateChordSequence(It.IsAny<string>())).Returns(mockChordUnitCollection);
           
            ////act  
            //var chordsequence = mockValidator.Object.GenerateChordSequence(audioId);
            //IChordUnitRepository chordService = 
            //chordService.GenerateChordSequence(audioId);
            //mockValidator.Setup(m => m.GenerateChordSequence(It.IsAny<string>())).Returns((ICollection<ChordUnitDetails> c )=> chordsequence )
            var result = chordService.GetChordSequence(audioId);

            //assert
            Assert.AreEqual(mockChordUnitCollection, result);

        }

}
}
