using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository repository;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Name", 10);
        repository = new HeroRepository();
    }

    [Test]
    public void Ctor_ShouldCreateAnEmptyList()
    {
        repository = new HeroRepository();

        var expectedCount = 0;

        Assert.AreEqual(expectedCount, repository.Heroes.Count);
    }

    [Test]
    public void Ctor_ShouldCreateValidHero()
    {
        var expectedHeroName = "Name";
        var expectedHeroLevel = 10;

        Assert.AreEqual(expectedHeroLevel, hero.Level);
        Assert.AreEqual(expectedHeroName, hero.Name);
    }

    [Test]
    public void Create_ShouldThrowExceptionWhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => repository.Create(null));
    }

    [Test]
    public void Create_ShouldThrowExceptionWhenHeroNameExists()
    {
        repository.Create(hero);
        Assert.Throws<InvalidOperationException>(() => repository.Create(new Hero("Name",15)));
    }

    [Test]
    public void Create_ShouldAddHeroToRepository()
    {
        repository.Create(hero);
        Assert.AreEqual(1, repository.Heroes.Count);
    }

    [Test]
    public void Create_ShouldReturnString()
    {
        var expectedString = $"Successfully added hero {hero.Name} with level {hero.Level}";
        Assert.AreEqual(expectedString, repository.Create(hero));
    }

    [Test]
    [TestCase(null)]
    [TestCase("     ")]
    [TestCase(" ")]
    public void Remove_ShouldThrowExceptionIfNameIsNullOrWhitespace(string name)
    {
        Assert.Throws<ArgumentNullException>(() => repository.Remove(name));
    }

    [Test]
    public void Remove_ShouldRemoveHeroIfFound()
    {
        repository.Create(hero);
        repository.Remove(hero.Name);

        Assert.AreEqual(0, repository.Heroes.Count);
    }

    [Test]
    public void Remove_ShouldReturnFalseIfNameNotFound()
    {
        repository.Create(hero);
        Assert.AreEqual(false, repository.Remove("Ivan"));
    }

    [Test]
    public void Remove_ShouldReturnTrueIfNameFound()
    {
        repository.Create(hero);
        Assert.AreEqual(true, repository.Remove(hero.Name));
    }

    [Test]
    public void GetHeroWithHighestLevel_ShouldReturnProperHero()
    {
        var hero2 = new Hero("Ivan", 100);
        repository.Create(hero);
        repository.Create(hero2);

        Assert.AreEqual(hero2, repository.GetHeroWithHighestLevel());
    }

    [Test]
    [TestCase("Ivan")]
    public void GetHero_ShouldReturnNullIfRepositoryIsEmpty(string name)
    {
        Assert.AreEqual(null, repository.GetHero(name));
    }

    [Test]
    public void GetHero_ShouldReturnHero()
    {
        repository.Create(hero);
        Assert.AreEqual(hero, repository.GetHero(hero.Name));
    }
}