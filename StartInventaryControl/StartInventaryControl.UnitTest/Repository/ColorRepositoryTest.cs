using NUnit.Framework;
using StartInventaryControl.Data;
using StartInventaryControl.Repository;
using StartInventaryControl.Repository.NHibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.UnitTest.Repository
{
    [TestFixture]
    public class ColorRepositoryTest
    {
        private static readonly string DB_FILE = @"..\..\..\resource\DB\SQLite\DB.sqlite";
        private static readonly string DB_FILE_TMP = DB_FILE + ".tmp";

        private readonly IColorRepository repository;

        public ColorRepositoryTest()
        {
            this.repository = new ColorRepository();
        }

        [SetUp]
        public void SetUp()
        {
            File.Copy(DB_FILE, DB_FILE_TMP, true);
        }

        [Test]
        public void AddColor_ColorIsNull_ThrowException()
        {
            var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(null));

            Assert.That(ex.Message, Is.EqualTo("A cor não pode estar nula ou vazia."));
        }

        [Test]
        public void AddColor_ColorAlreadyExists_ThrowException()
        {
            var color = new Color
            {
                Name = "AZUL",
            };

            var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(color));

            Assert.That(ex.Message, Is.EqualTo("Cor 'AZUL' já existe."));
        }

        [Test]
        public void AddColor_ColorIsValid_GetAllColorAdded()
        {
            var color = new Color
            {
                Name = "AZUL/BRANCO",
            };

            this.repository.Add(color);

            var colors = this.repository.GetAll();

            Assert.That(colors.Count    , Is.EqualTo(2));
            Assert.That(colors[0].Name  , Is.EqualTo("AZUL"));
            Assert.That(colors[1].Name  , Is.EqualTo("AZUL/BRANCO"));

        }

        [Test]
        public void UpdateColor_ColorIsNull_ThrowException()
        {
            var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(null));

            Assert.That(ex.Message, Is.EqualTo("A cor não pode estar nula ou vazia."));
        }

        [Test]
        public void UpdateColor_ColorUpdatedAlreadyExists_ThrowException()
        {
            var color = new Color
            {
                Name = "AZUL/BRANCO",
            };

            this.repository.Add(color);
            var colors = this.repository.GetAll();

            colors[1].Name = "AZUL";
            var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(colors[1]));

            Assert.That(ex.Message, Is.EqualTo("Cor 'AZUL' já existe."));
        }

        [Test]
        public void UpdateColor_ColorIsValid_GetColorUpdated()
        {
            var color = this.repository.GetAll()[0];
            Assert.That(color.Name, Is.EqualTo("AZUL"));

            color.Name = "VERMELHO";
            this.repository.Update(color);

            var colorUpdated = this.repository.GetAll()[0];
            Assert.That(color.Name, Is.EqualTo("VERMELHO"));
        }
    }
}
