using RulesEngine.Models;

namespace BasicDemo.Console
{
    public static class RuleWorker
    {
        public static RulesEngine.RulesEngine GenerateRulesEngine(Action<List<Rule>> rules)
        {
            List<Rule> mainRules = new List<Rule>();
            rules(mainRules);

            var workflows = new List<Workflow>();

            Workflow testWorkflow = new Workflow();
            testWorkflow.WorkflowName = "Test Workflow";
            testWorkflow.Rules = mainRules;

            workflows.Add(testWorkflow);

            return new RulesEngine.RulesEngine(workflows.ToArray());
        }
    }
}
