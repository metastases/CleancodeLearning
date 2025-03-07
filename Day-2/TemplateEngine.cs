namespace TemplateEngine;

public class TemplateEngine
{
    string template = string.Empty;
    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

    public TemplateEngine()
    {

    }

    public void SetTemplate(string template)
    {
        this.template = template;
    }

    public void AddKeyValuePair(string key, string value)
    {
        keyValuePairs[key] = value;
    }

    public string Evaluate()
    {
        string result = template;
        foreach (var pair in keyValuePairs)
        {
            result = result.Replace("{" + pair.Key + "}", pair.Value);
        }

        return result;
    }
}
