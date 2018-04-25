// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

using System;
using System.Linq;
//using FestivalManager.Core.Controllers;      //Uncomment these 4 rows so you can do tests locally
//using FestivalManager.Entities;              //Uncomment these 4 rows so you can do tests locally
//using FestivalManager.Entities.Instruments;  //Uncomment these 4 rows so you can do tests locally
//using FestivalManager.Entities.Sets;         //Uncomment these 4 rows so you can do tests locally
using NUnit.Framework;

namespace FestivalManager.Tests
{

    [TestFixture]
    public class SetControllerTests
    {
        private SetController setController;
        private Stage stage;

        [SetUp]
        public void Initialize()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }

        [Test]
        public void TestSongsCount()
        {
            this.stage.AddSong(new Song("Song", new TimeSpan(0, 20, 20)));

            Assert.That(this.stage.Songs.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestDidNotPerform()
        {
            this.stage.AddSet(new Short("short"));
            this.stage.AddPerformer(new Performer("someone", 27));
            this.stage.AddSong(new Song("song", new TimeSpan(0, 10, 0)));

            Assert.That(this.setController.PerformSets(), Is.EqualTo("1. short:\r\n-- Did not perform"));
        }

        [Test]
        public void TestCanPerform()
        {
            this.stage.AddSet(new Medium("medium"));
            var set = this.stage.Sets.First();

            this.stage.AddPerformer(new Performer("someone", 27));
            var performer = this.stage.Performers.First();
            performer.AddInstrument(new Drums());

            this.stage.AddSong(new Song("song", new TimeSpan(0, 10, 0)));

            set.AddSong(this.stage.Songs.First());
            set.AddPerformer(performer);

            Assert.IsTrue(set.CanPerform());
        }

        [Test]
        public void TestSuccessfulSet()
        {
            this.stage.AddSet(new Short("medium"));
            var set = this.stage.Sets.First();

            this.stage.AddPerformer(new Performer("someone", 27));
            var performer = this.stage.Performers.First();
            performer.AddInstrument(new Drums());

            this.stage.AddSong(new Song("song", new TimeSpan(0, 10, 0)));

            set.AddSong(this.stage.Songs.First());
            set.AddPerformer(performer);

            var result = setController.PerformSets();

            Assert.That(result, Is.EqualTo("1. medium:\r\n-- 1. song (10:00)\r\n-- Set Successful"));
        }

        [Test]
        public void TestSetControllerCorrectOutput()
        {
            this.stage.AddSet(new Long("Long"));
            var set = this.stage.Sets.First();
            this.stage.AddPerformer(new Performer("someone", 27));
            var performer = this.stage.Performers.First();
            performer.AddInstrument(new Drums());
            this.stage.AddSong(new Song("song", new TimeSpan(0, 10, 0)));
            this.stage.AddSong(new Song("second", new TimeSpan(0, 10, 0)));
            set.AddSong(this.stage.Songs.First());
            set.AddSong(this.stage.Songs.First(s => s.Name == "second"));
            set.AddPerformer(performer);

            var result = this.setController.PerformSets();

            Assert.That(result, Is.EqualTo("1. Long:\r\n-- 1. song (10:00)\r\n-- 2. second (10:00)\r\n-- Set Successful"));
        }

        [Test]
        public void TestSomething()
        {
            this.stage.AddSet(new Long("Long set"));
            this.stage.AddPerformer(new Performer("Performer", 27));
            this.stage.AddSong(new Song("Song", new TimeSpan(0, 10, 0)));

            var performer = this.stage.Performers.First();
            performer.AddInstrument(new Guitar());

            var mySet = this.stage.Sets.First();
            mySet.AddPerformer(this.stage.Performers.First());
            mySet.AddSong(this.stage.Songs.First());

            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();

            var expected = "1. Long set:\r\n-- Did not perform";

            Assert.AreEqual(expected, this.setController.PerformSets());

        }
    }
}