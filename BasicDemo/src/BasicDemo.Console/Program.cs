using BasicDemo.Console;
using RulesEngine.Models;

Console.WriteLine("Basic Rules Engine Demo is started");

var ruleEngine = RuleWorker.GenerateRulesEngine(rules => {
    rules.Add(new Rule()
    {
        RuleName = "Amount Rule",
        SuccessEvent = "Amount is within tolerance.",
        ErrorMessage = "Amount must be under 500",
        Expression = "Amount < 500",
        RuleExpressionType = RuleExpressionType.LambdaExpression
    });

    rules.Add(new Rule()
    {
        RuleName = "IBAN_TR",
        SuccessEvent = "IBAN starts with TR",
        ErrorMessage = "IBAN has to start with 'TR'",
        Expression = "Iban.StartsWith(\"TR\")",
        RuleExpressionType = RuleExpressionType.LambdaExpression
    });
});

var response = await ruleEngine.ExecuteAllRulesAsync("Test Workflow", new
{
    Amount = 300,
    Iban = "US123"
});

if (response?.Any(x => !x.IsSuccess) == true)
{
    var detail = response.First(x => !x.IsSuccess);
    Console.WriteLine(detail.ExceptionMessage);
}

Console.ReadLine();