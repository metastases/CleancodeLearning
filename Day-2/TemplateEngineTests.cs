namespace TemplateEngine.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Sateesh")]
    [TestCase("Sunil")]
    public void ShouldParseOneVariable(string name)
    {
        //Arrange
        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.SetTemplate("Hello {name}");
        templateEngine.AddKeyValuePair("name",name);

        //Act
        string result = templateEngine.Evaluate();

        //Assert
        Assert.That(result, Is.EqualTo("Hello "+ name));
    }

    [TestCase("Sateesh", "25")]
    [TestCase("Sunil", "30")]
    public void ShouldParseTwoVariables(string name, string age)
    {
        //Arrange
        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.SetTemplate("Hello {name} {age}");
        templateEngine.AddKeyValuePair("name", name);
        templateEngine.AddKeyValuePair("age", age);

        //Act
        string result = templateEngine.Evaluate();

        //Assert
        Assert.That(result, Is.EqualTo("Hello " + name + " "+ age));
    }
}